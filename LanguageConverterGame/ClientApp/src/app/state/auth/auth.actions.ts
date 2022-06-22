import { createAction, props } from '@ngrx/store';

export const loginRequest = createAction(
  '[Auth] Login Request',
  props<{ userName: string, passWord: string }>()
);

export const loginSuccess = createAction(
    '[Auth] Login Success',
    props<{ userName: string,passWord: string, token: string}>()
  );


  export const loginFailure = createAction(
    '[Auth] Login Failure',
    props<{ error: string}>()
  );