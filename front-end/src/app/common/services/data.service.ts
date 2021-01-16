import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class DataService {

  private data: any;
  private employeeInfo: any;
  public employeeEmitterEvent = new EventEmitter<any>();

  constructor() { }

  setData(data: any) {
    this.data = data;
  }

  getData() {
    return this.data;
  }

  setEmployee(employeeInfo: any) {
    this.employeeInfo = employeeInfo;
    this.employeeEmitterEvent.emit(employeeInfo);
  }

  getEmployee() {
    return this.employeeInfo;
  }
}

