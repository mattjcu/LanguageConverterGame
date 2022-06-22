import { Component, OnInit } from '@angular/core';
import {Store} from '@ngrx/store';
import * as RegisterActions from '../state/register/register.actions';
import * as fromRegister from '../state/register/register.reducer';
import * as fromAuth from '../state/auth/auth.reducer';
@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['/register.component.css']
})

export class RegisterComponent implements OnInit {
    form: User ={
        userName: "",
        passWord: "",
    }
    errorMessage$ = this.store.select(fromRegister.selectError);
    jwtToken$ = this.store.select(fromAuth.selectToken);
    user$ = this.store.select(fromAuth.selectUser);
    constructor(private store: Store){}
    ngOnInit(): void {}
    onSubmit(): void {
        const { userName, passWord } = this.form
        this.store.dispatch(RegisterActions.registerRequest({userName,passWord}))
    }


}
