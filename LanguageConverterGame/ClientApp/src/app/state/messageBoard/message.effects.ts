import { Injectable } from '@angular/core';
import {switchMap} from 'rxjs/operators';
import {Actions, createEffect, ofType } from '@ngrx/effects';
import { map} from 'rxjs';
import { MessageService } from 'src/app/services/message.service';
import * as MessageActions from './message.actions';



@Injectable()
export class MessageEffects {

  constructor(
    private actions$: Actions,
    private messageService: MessageService
  ) { }

  loadAllMessages$ = createEffect(() => this.actions$.pipe(
    ofType(MessageActions.LoadMessage),
    switchMap(() =>
      this.messageService.getMessages().pipe(
        map(data => MessageActions.LoadMessageSuccess({ payload: { messages: data } }))
      )
    )
  ));

  createMessage$ = createEffect(() =>
  this.actions$.pipe(
    ofType(MessageActions.AddMessage),
    switchMap(action =>
      this.messageService
        .createMessage(action.payload.message.userName, action.payload.message.message)
        .pipe(map(response=> MessageActions.LoadMessage())))));
        
}
