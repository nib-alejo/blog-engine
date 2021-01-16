import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { DataService } from './data.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class HttpService {

  constructor(
    private httpClient: HttpClient,
    private dataService: DataService,
  ) { }


  public dataservice(requestInfo: any): Observable<any> {

    let httpRequest: HttpRequest<any> = new HttpRequest(
      requestInfo.method,
      (requestInfo.service || environment.blogEngineWS) + requestInfo.operation,
      requestInfo.body,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
        params: requestInfo.parameters
      }
    );

    return this.httpClient.request(httpRequest)
      .pipe(
        tap((httpResponse) => {
          return httpResponse;
        }),
        catchError((httpErrorResponse: HttpErrorResponse) => {
          window.alert('Ocurrió un fallo en el procesamiento de la aplicación.');
          return throwError(httpErrorResponse);
        })
      );
  }
}
