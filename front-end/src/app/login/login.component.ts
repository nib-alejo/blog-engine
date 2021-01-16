import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../common/services/data.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  public loginForm: FormGroup;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService
  ) {

    this.loginForm = new FormGroup({
      email: new FormControl({ value: 'shakespeare@yahoo.com', disabled: false }, [Validators.required, Validators.email]),
      password: new FormControl({ value: '123456', disabled: false }, [Validators.required])
    });
  }

  onSubmit() {

    if (this.loginForm.valid) {

      if (this.loginForm.get('email')?.value === 'shakespeare@yahoo.com' && this.loginForm.get('password')?.value === '123456') {

        const employee = {
          Id: '7EF2BFD1-E504-462C-9D3A-4B5544A93740',
          Person: {
            Id: '04A31FF9-67B1-4A9D-B970-A565C2D3EDDE',
            Name: 'William Shakespeare',
            Email: 'shakespeare@yahoo.com'
          },
          Role: {
            Id: '6B700700-BFF1-44C8-AB03-24C16E21BD40',
            Description: 'Writer'
          }
        }

        this.dataService.setEmployee(employee);
        this.router.navigate(['../writer'], { relativeTo: this.activatedRoute });
      }
      else if (this.loginForm.get('email')?.value === 'perkins@gmail.com' && this.loginForm.get('password')?.value === '123456') {

        const employee = {
          Id: '7EF2BFD1-E504-462C-9D3A-4B5544A93740',
          Person: {
            Id: '04A31FF9-67B1-4A9D-B970-A565C2D3EDDE',
            Name: 'Maxwell Perkins',
            Email: 'perkins@gmail.com'
          },
          Role: {
            Id: '48225690-4F58-4838-8042-4BA174A8D3A8',
            Description: 'Editor',
          }
        }

        this.dataService.setEmployee(employee);
        this.router.navigate(['../editor'], { relativeTo: this.activatedRoute });
      }
      else {
        window.alert('Invalid credential');
      }
    }
    else {

      Object.entries(this.loginForm.controls).forEach(([key, formControl]: [string, AbstractControl]) => {
        formControl.markAsTouched();
      });
    }
  }
}
