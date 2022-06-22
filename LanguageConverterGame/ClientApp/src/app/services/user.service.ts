import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type' : 'application/json', 'Access-Control-Allow-Origin': '*'})
};
@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseUrl;
  constructor(private http : HttpClient) { }
  getAllUsers(): Observable<any> {
    return this.http.get(this.baseUrl + '/User' , httpOptions);
  }

  getActiveUsers(): Observable<any> {
    return this.http.get(this.baseUrl + "/User/active" , httpOptions);
  }

  register(username: string, password: string): Observable<any>{
    return this.http.post(this.baseUrl + '/User', {
      username, password
    }, httpOptions);
  }


}
