import {createReducer, on, createFeatureSelector, createSelector } from "@ngrx/store"
import { loginFailure, loginRequest, loginSuccess } from "./auth.actions"


export interface State {
    token: string
    userName: string,
    passWord: string,
    loginError?: string
}

export const initialState: State = {
    token: null,
    passWord: null,
    userName: null
}

const _authReducer = createReducer(
    initialState,
    on(loginRequest,(state, {userName, passWord}) => {
        return {
            ...state,
            userName: userName,
            passWord: passWord,
            loginError: null
        }
    }),
    on(loginSuccess, (state, {userName, passWord, token}) => {
        return {
            ...state,
            token: token,
            passWord: passWord,
            userName: userName
        }
    }),
    on(loginFailure, (state, {error}) => {
        return {
            ...state,
            loginError: error,
            token: null,
            user: null,
        }
    })
);

export function authReducer(state, action) {
    return _authReducer(state,action);
}

export const selectAuthState = createFeatureSelector<State>('auth');

export const selectToken = createSelector(selectAuthState, state => state.token);
export const selectUser = createSelector(selectAuthState, state => state.userName);
export const selectError = createSelector(selectAuthState, state => state.loginError);