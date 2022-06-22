import { createAction, props } from '@ngrx/store';

export const registerRequest = createAction(
  '[Register] Registration Request',
  props<{ userName: string, passWord: string }>()
);

export const registerSuccess = createAction(
    '[Register] Registration Success'
  );


  export const registerFailure = createAction(
    '[Register] Registration Failure',
    props<{ error: string}>()
  );