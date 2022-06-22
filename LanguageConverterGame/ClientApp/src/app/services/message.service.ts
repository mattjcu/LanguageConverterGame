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
export class MessageService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getMessages(): Observable<any> {
    return this.http.get(this.baseUrl + '/MessageBoard' , httpOptions);
  }
  createMessage(userName:string, message: string): Observable<any> {
    return this.http.post(this.baseUrl+'/MessageBoard?userName=' + userName, {
      message
    }, httpOptions);
  }

  translateMessage(message: string): Observable<any> {
    return this.http.post(this.baseUrl + '/MessageBoard/Translate', {
        message
    }, httpOptions);
  }
}
