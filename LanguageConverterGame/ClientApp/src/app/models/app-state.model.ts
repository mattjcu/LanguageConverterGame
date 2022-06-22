import { EntityState } from '@ngrx/entity';
import {Message } from "../models/Message"
export interface AppState {
	messageState: MessageState;
}

export interface MessageState extends EntityState<Message> {
}