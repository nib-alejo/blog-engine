import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { DataService } from '../common/services/data.service';
import { v4 as uuidv4 } from 'uuid';
import { HttpService } from '../common/services/http.service';
import { Enum } from '../common/constants';

@Component({
  selector: 'blog',
  templateUrl: './blog.component.html'
})
export class BlogComponent {

  public employee: any;
  public action: string = '';
  public blog: any;
  public blogForm: FormGroup;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private httpService: HttpService
  ) {

    this.employee = this.dataService.getEmployee();

    if (this.dataService.getData()) {
      this.action = this.dataService.getData().action;
    }
    else {
      this.router.navigate(['../'], { relativeTo: this.activatedRoute });
    }


    this.blogForm = new FormGroup({
      author: new FormControl({ value: undefined, disabled: true }, [Validators.required]),
      title: new FormControl({ value: undefined, disabled: this.action === 'select' ? true : false }, [Validators.required]),
      article: new FormControl({ value: undefined, disabled: this.action === 'select' ? true : false }, [Validators.required]),
      publishDate: new FormControl({ value: undefined, disabled: true }, [Validators.required])
    });

    this.setForm();
  }


  setForm() {

    if (this.action === 'create') {
      this.blogForm.get('author')?.setValue(this.employee.Person.Name);
    }
    else {

      this.blog = this.dataService.getData().blog;

      this.blogForm.get('author')?.setValue(this.blog.author.person.name);
      this.blogForm.get('title')?.setValue(this.blog.title);
      this.blogForm.get('article')?.setValue(this.blog.article);

      if (this.blog.publishDateTicks) {
        this.blogForm.get('publishDate')?.setValue(new Date(this.blog.publishDateTicks));
      }
    }
  }


  getForm(): any {

    let blog: any;

    if (['update', 'select'].includes(this.action)) {

      blog = this.blog;

      blog.title = this.blogForm.get('title')?.value;
      blog.article = this.blogForm.get('article')?.value;
    }
    else {

      blog = {

        id: uuidv4(),
        state: { id: Enum.BlogState.InCreation.Id },
        author: { id: this.dataService.getEmployee().Id },
        title: this.blogForm.get('title')?.value,
        article: this.blogForm.get('article')?.value,
        dateTicks: Date.now()
      }
    }

    return blog;
  }


  onSubmit() {

    if (this.blogForm.valid) {

      if (this.action === 'create') {
        this.insertBlog();
      }
      else {
        this.updateBlog();
      }
    }
    else {

      Object.entries(this.blogForm.controls).forEach(([key, formControl]: [string, AbstractControl]) => {

        if (formControl.enabled) {
          formControl.markAsTouched();
        }
      });
    }
  }


  onSubmitBlog() {

    this.blog.state.id = Enum.BlogState.PendingToCheck.Id;
    this.updateBlog();
  }

  onApproveBlog() {
    
    this.httpService.dataservice({
      method: 'PUT',
      operation: 'Blog/ApproveOrReject',
      parameters: new HttpParams().set('id', this.blog.id).append('action', '0')
    }).toPromise().then((httpResponse: any) => {
      this.router.navigate(['../editor'], { relativeTo: this.activatedRoute });
    });
  }

  onRejectBlog() {
    
    this.httpService.dataservice({
      method: 'PUT',
      operation: 'Blog/ApproveOrReject',
      parameters: new HttpParams().set('id', this.blog.id).append('action', '1')
    }).toPromise().then((httpResponse: any) => {
      this.router.navigate(['../editor'], { relativeTo: this.activatedRoute });
    });
  }

  onDeleteBlog() {
    this.deleteBlog(this.blog.id)
  }

  insertBlog() {

    this.httpService.dataservice({
      method: 'POST',
      operation: 'Blog',
      body: [this.getForm()]
    }).toPromise().then((httpResponse: any) => {
      this.router.navigate(['../writer'], { relativeTo: this.activatedRoute });
    });
  }


  updateBlog() {

    this.httpService.dataservice({
      method: 'PUT',
      operation: 'Blog',
      body: [this.getForm()]
    }).toPromise().then((httpResponse: any) => {

      if (this.employee.Role.Id === '6B700700-BFF1-44C8-AB03-24C16E21BD40') {
        this.router.navigate(['../writer'], { relativeTo: this.activatedRoute });
      }
      else {
        this.router.navigate(['../editor'], { relativeTo: this.activatedRoute });
      }
    });
  }


  deleteBlog(blogId: string) {

    this.httpService.dataservice({
      method: 'DELETE',
      operation: 'Blog',
      parameters: new HttpParams().set('id', blogId)
    }).toPromise().then((httpResponse: any) => {
      this.router.navigate(['../editor'], { relativeTo: this.activatedRoute });
    });
  }
}
