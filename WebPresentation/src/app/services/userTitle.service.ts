import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUserTitle } from '../models/userTitle.model';

@Injectable({ providedIn: 'root' })
export class UserTitleService {
  constructor(private http: HttpClient) {}

  async getUserTitle() {
    return await this.http
      .get<{ [id: number]: IUserTitle }>(environment.apiUrl + 'userTitle')
      .pipe(
        map((responseData) => {
          const userTitlesArray = [];
          for (const key in responseData) {
            if (responseData.hasOwnProperty(key)) {
              userTitlesArray.push({ ...responseData[key] });
            }
          }
          return userTitlesArray;
        }),
        catchError((errorRes) => {
          return throwError(errorRes);
        })
      )
      .toPromise();
  }
}
