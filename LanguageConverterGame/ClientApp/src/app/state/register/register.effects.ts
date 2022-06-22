import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, of, map, tap, switchMap } from 'rxjs';
import * as RegisterActions from './register.actions';
import { UserService } from 'src/app/services/user.service';


@Injectable()
export class RegisterEffects {
    registerRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(RegisterActions.registerRequest),
      switchMap(action =>
        this.userService.register(action.userName, action.passWord)
        .pipe(map(response => RegisterActions.registerSuccess()),
        tap(() => this.router.navigate(['/'])),
          catchError((error: any) => of(RegisterActions.registerFailure(error))))
    )
  ));

  constructor(
    private actions$: Actions,
    private userService: UserService,
    private router: Router
  ) {}
}
