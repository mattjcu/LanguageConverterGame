import { EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import {Message } from "../../models/Message";
  
export const adapter: EntityAdapter<Message> = createEntityAdapter<Message>({
});
  
export const {
   selectAll: selectAllMessage,
} = adapter.getSelectors();
  