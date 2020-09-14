
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpRequest, HttpResponse } from "@angular/common/http";

import {  Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { IBookAssignInterface } from './assignbook/BookAssign.interface';
import { debuglog } from 'util';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private SERVER_URL = "http://localhost:61487";

  constructor(private httpClient: HttpClient) { }

 

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

  public sendGetRequest(){
    return this.httpClient.get(this.SERVER_URL).pipe(catchError(this.handleError));
  }

  public getbooks(){  
		return this.httpClient.get(this.SERVER_URL + '/api/book').pipe(catchError(this.handleError));  
  }
  public getbookbyid(id: number){  
		return this.httpClient.get(this.SERVER_URL + '/api/book/'+id+'/book').pipe(catchError(this.handleError));  
  }
  public getusers(){  
		return this.httpClient.get(this.SERVER_URL + '/api/users').pipe(catchError(this.handleError));
  }  
    
  assignBook(assignBook: IBookAssignInterface): Observable<any> {
    let headers = new Headers();
    var data = JSON.stringify(assignBook);
    headers.append('Content-Type', 'application/json');
  // let options = new HttpRequest({ headers: headers });
  
  
      return this.httpClient
        .post(
          this.SERVER_URL + '/api/assignBook', data, {
            responseType: 'json',
            observe: 'body',
            headers: {
              'Content-Type': 'application/json'
            }
          }
        )
        .pipe(map(res => {
          var ress = res;
          return res;
        }));
            //.catch(this.handleError));
}

returnBook(assignBook: IBookAssignInterface): Observable<any> {
  let headers = new Headers();
  var data = JSON.stringify(assignBook);
  headers.append('Content-Type', 'application/json');
// let options = new HttpRequest({ headers: headers });


    return this.httpClient
      .put(
        this.SERVER_URL + '/api/assignBook/'+assignBook.id+'/return', data, {
          responseType: 'json',
          observe: 'body',
          headers: {
            'Content-Type': 'application/json'
          }
        }
      )
      .pipe(map(res => {
        var ress = res;
        return res;
      }));
          //.catch(this.handleError));
}

checkassigned(assignBook: IBookAssignInterface): Observable<any> {
  let headers = new Headers();
  var data = JSON.stringify(assignBook);
  headers.append('Content-Type', 'application/json');
// let options = new HttpRequest({ headers: headers });


    return this.httpClient
      .post(
        this.SERVER_URL + '/api/assignBook/checkassigned', data, {
          responseType: 'json',
          observe: 'body',
          headers: {
            'Content-Type': 'application/json'
          }
        }
      )
      .pipe(map(res => {
        var ress = res;
        return res;
      }));
          //.catch(this.handleError));
}

}