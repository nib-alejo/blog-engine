import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { DataService } from '../common/services/data.service';
import { HttpService } from '../common/services/http.service';
import { Enum } from '../common/constants';

@Component({
  selector: 'editor',
  templateUrl: './editor.component.html'
})
export class EditorComponent {

  public blogsToCheckList: any[] = [];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService,
    private httpService: HttpService
  ) {

    this.loadForm();
  }

  loadForm() {

    this.getBlogByState(Enum.BlogState.PendingToCheck.Id).then((data) => {
      this.blogsToCheckList = data;
    });

  }

  onBlog(blog: any) {

    this.dataService.setData({
      action: 'select',
      blog: blog
    });

    this.router.navigate(['../blog'], { relativeTo: this.activatedRoute });
  }

  getBlogByState(blogState: string): Promise<any> {

    return new Promise((resolve) => {

      this.httpService.dataservice({
        method: 'GET',
        operation: 'Blog',
        parameters: new HttpParams().set('stateId', blogState)
      }).subscribe((httpResponse: any) => {
        if (httpResponse.body !== undefined) {
          resolve(httpResponse.body);
        }
      });
    });
  }
}
