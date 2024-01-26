import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }
  async login(StudentNo: string, Password: string, UserName: string, callBackFunction?: () => void): Promise<any> {
    const url = `/api/${"controller"}/${"action"}`; // Replace 'api' with your actual base URL
    const observable: Observable<any> = this.httpClient.post(url, { UserName, Password });

    await firstValueFrom(observable);

    if (callBackFunction) {
      callBackFunction();
    }
}
}
