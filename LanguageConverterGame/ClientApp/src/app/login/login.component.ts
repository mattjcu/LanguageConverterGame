import {Component, OnInit } from '@angular/core';
import {Store} from "@ngrx/store";
import * as AuthActions from '../state/auth/auth.actions';
import * as fromAuth from '../state/auth/auth.reducer';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    form: User ={
        userName: "",
        passWord: "",
    }
    errorMessage$ = this.store.select(fromAuth.selectError);
    jwtToken$ = this.store.select(fromAuth.selectToken);
    user$ = this.store.select(fromAuth.selectUser);
    constructor(private store: Store) { }
    ngOnInit(): void {}
    onSubmit(): void {
      const { userName, passWord } = this.form
      this.store.dispatch(AuthActions.loginRequest({userName,passWord}))
    }
    reloadPage(): void {
      window.location.reload();
    }

}