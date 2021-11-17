import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUserType } from '../models/userType.model';

@Injectable({ providedIn: 'root' })
export class UserTypeService {
  constructor(private http: HttpClient) {}

  async getUserType() {
    return await this.http
      .get<{ [id: number]: IUserType }>(environment.apiUrl + 'userType')
      .pipe(
        map((responseData) => {
          const userTypesArray = [];
          for (const key in responseData) {
            if (responseData.hasOwnProperty(key)) {
              userTypesArray.push({ ...responseData[key] });
            }
          }
          return userTypesArray;
        }),
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }
}
