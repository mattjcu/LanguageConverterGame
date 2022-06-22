import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, of, exhaustMap, map, tap } from 'rxjs';
import * as AuthActions from '../auth/auth.actions';
import { AuthService } from 'src/app/services/auth.service';


@Injectable()
export class AuthEffects {
  loginRequest$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginRequest),
      exhaustMap(action =>
        this.authService
          .login(action.userName, action.passWord)
          .pipe(map(response=> AuthActions.loginSuccess(response)),
          catchError((error: any) => of(AuthActions.loginFailure(error))))
    )
  ));

  loginSuccess$ = createEffect(
    () =>
      this.actions$.pipe(
        ofType(AuthActions.loginSuccess),
        tap(() => {
          this.router.navigateByUrl('/');
        })
      ),
    { dispatch: false }
  );

  constructor(
    private actions$: Actions,
    private authService: AuthService,
    private router: Router
  ) {}
}
