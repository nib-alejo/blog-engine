import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../common/services/data.service';


@Component({
  selector: 'landing',
  templateUrl: './landing.component.html'
})
export class LandingComponent {

  public employee: any;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private dataService: DataService
  ) {

    this.employee = this.dataService.getEmployee();
    this.onEmployeeEmitter();
  }

  onLogin() {

    if (this.employee) {
      this.dataService.setEmployee(null);
      this.router.navigate(['./'], { relativeTo: this.activatedRoute });  
    }
    else {
      this.router.navigate(['./login'], { relativeTo: this.activatedRoute });  
    }
  }

  onEmployeeEmitter() {

    this.dataService.employeeEmitterEvent.subscribe((employee: any) => {
      this.employee = employee;
    });
  }
}
