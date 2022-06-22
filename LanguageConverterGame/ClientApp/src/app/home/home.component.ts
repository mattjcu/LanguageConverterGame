import { Component, OnInit } from '@angular/core';
import { Store } from "@ngrx/store";
import {Message } from "../models/Message"
import { FormGroup, FormControl } from '@angular/forms';
import { Observable, Subscription, interval } from 'rxjs';
import { startWith, tap } from 'rxjs/operators';
import { MessageState } from '../models/app-state.model';
import { selectAllMessages } from '../state/messageBoard/message.reducer';
import { MessageService } from 'src/app/services/message.service';
import * as MessageActions from '../state/messageBoard/message.actions';
import * as fromAuth from '../state/auth/auth.reducer';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  messageForm =  new FormGroup({
      message : new FormControl('')
  });
  timeInterval: Subscription;
  userName: string;
  message: string;
  translate: boolean;
  messages: Observable<Message[]>;
  translatedMessage: string;
  jwtToken$ = this.store.select(fromAuth.selectToken);
  user$ = this.store.select(fromAuth.selectUser).subscribe(data => this.userName = data);
  constructor(private store: Store<MessageState>, private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.load();
    this.setUpPoll();
  }

  ngOnDestroy(): void {
    this.timeInterval.unsubscribe();
  }

  onSubmit(): void {
    const msg = new Message({message : this.message, userName : this.userName});
    this.store.dispatch(MessageActions.AddMessage({payload: { message: msg }}))
    this.translatedMessage="";
    this.messageForm.reset();
 }

 load(): void {
  this.messages = this.store.select(selectAllMessages);
  this.store.dispatch(MessageActions.LoadMessage());
  this.messageForm.get('message').valueChanges.subscribe(data => {
    this.message = data;});
 }

 translateMessage(): void {
    const msg = new Message({message: this.message, userName: this.userName});
    this.messageService.translateMessage(msg.message).subscribe(message => this.translatedMessage = message.translatedMessage)
 }

 setUpPoll(): void{
  this.timeInterval = interval(5000)
  .pipe(
  startWith(0), 
   tap(() => this.store.dispatch(MessageActions.LoadMessage()))
   ).subscribe((res) => this.messages = this.store.select(selectAllMessages));
 }

}
