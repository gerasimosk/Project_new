import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { IUser } from '../models/user.model';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserService implements OnDestroy {

  constructor(private http: HttpClient) {}

  async getUsers(pageNumber: number, pageSize: number, fullName: string) {
    const params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
      .set('fullName', fullName);

    return await this.http
      .get<{ [id: number]: IUser }>(environment.apiUrl + 'user', { params })
      .pipe(
        map((responseData) => {
          const usersArray = [];
          for (const key in responseData) {
            if (responseData.hasOwnProperty(key)) {
              usersArray.push({ ...responseData[key] });
            }
          }
          return usersArray;
        }),
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }

  async getUser(id: number) {
    return await this.http
      .get(environment.apiUrl + 'user/' + id)
      .pipe(
        map((responseData) => {
          return responseData as IUser;
        }),
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }

  updateUser(user: IUser) {
    try {
      return this.http
        .put(environment.apiUrl + 'user', user)
        .pipe(catchError((errorRes) => throwError(errorRes)))
        .toPromise();
    } catch (error) {
      return error;
    }
  }

  addUser(user: IUser) {
    try {
      return this.http
        .post(environment.apiUrl + 'user', user)
        .pipe(catchError((errorRes) => throwError(errorRes)))
        .toPromise();
    } catch (error) {
      return error;
    }
  }

  async deleteUser(id: number) {
    await this.http
      .delete(environment.apiUrl + 'user/' + id)
      .pipe(
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }

  async getCountOfUsers(fullName: string) {
    const params = new HttpParams().set('fullName', fullName);

    return await this.http
      .get(environment.apiUrl + 'user/count', { params })
      .pipe(
        map((responseData) => {
          return responseData as number;
        }),
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }

  ngOnDestroy(): void {}
}
