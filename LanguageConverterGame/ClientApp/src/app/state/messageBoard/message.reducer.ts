import { createFeatureSelector, createSelector, createReducer, on, Action } from '@ngrx/store';
import * as fromActions from '../messageBoard/message.actions';
import { MessageState } from 'src/app/models/app-state.model';
import * as fromAdapter from '../messageBoard/message.adapter';

export const initialState: MessageState = fromAdapter.adapter.getInitialState({ 
    selectedMessageId: ''
});


const _messageReducer = createReducer(
  initialState,
  on(fromActions.AddMessage, (state, {payload}) => fromAdapter.adapter.addOne(payload.message, state)),
  on(fromActions.LoadMessageSuccess, (state, {payload}) => {
    state = fromAdapter.adapter.removeAll({ ...state, selectedMessageId: '' });
    return fromAdapter.adapter.addMany(payload.messages, state);
  })
);

export function messageReducer(state: any, action: Action) {
  return _messageReducer(state, action);
}


export const getMessageState = createFeatureSelector<MessageState>('message');
export const selectAllMessages = createSelector(getMessageState, fromAdapter.selectAllMessage);