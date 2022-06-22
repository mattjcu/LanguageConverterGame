import {createReducer, on, createFeatureSelector, createSelector } from "@ngrx/store"
import { registerSuccess, registerFailure, registerRequest } from "./register.actions"


export interface State {
    userName: string,
    passWord: string,
    registerError?: string
}

export const initialState: State = {
    userName: null,
    passWord: null,
}

const _registerReducer = createReducer(
    initialState,
    on(registerRequest,(state, {userName, passWord}) => {
        return {
            ...state,
            userName: userName,
            passWord: passWord,
            loginError: null
        }
    }),
    on(registerSuccess, (state, {}) => {
        return {
            ...state
        }
    }),
    on(registerFailure, (state, {error}) => {
        return {
            ...state,
            registerError: error,
            user: null,
        }
    })
);

export function registerReducer(state, action) {
    return _registerReducer(state,action);
}

export const selectAuthState = createFeatureSelector<State>('register');
export const selectUser = createSelector(selectAuthState, state => state.userName);
export const selectError = createSelector(selectAuthState, state => state.registerError);