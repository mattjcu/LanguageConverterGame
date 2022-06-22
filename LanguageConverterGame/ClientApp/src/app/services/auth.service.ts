import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type' : 'application/json', 'Access-Control-Allow-Origin': '*'})
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  login(username:string, password: string): Observable<any> {
    return this.http.post(this.baseUrl+'/Login', {
      username, password
    }, httpOptions);
  }
}
