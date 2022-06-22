import { createAction, props } from '@ngrx/store';
import {Message } from "../../models/Message";

export enum MessageActionTypes {
  LoadMessage = '[Message] Load Messages',
  LoadMessageSuccess = '[Message] Load Messages Success',
  AddMessage = '[Message] Add Messages',
  TranslateMessage = '[Message] Translate Message',
  TranslatedMessageSuccess = '[Message] Translate Message Success'
}

export const LoadMessage = createAction(MessageActionTypes.LoadMessage);
export const LoadMessageSuccess = createAction(MessageActionTypes.LoadMessageSuccess,
  props<{payload: { messages: Message[] }}>());

  export const AddMessage = createAction(MessageActionTypes.AddMessage,
    props<{payload: { message: Message}}>());
