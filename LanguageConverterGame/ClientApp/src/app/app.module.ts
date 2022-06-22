import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { StoreModule } from '@ngrx/store';
import { authReducer } from './state/auth/auth.reducer';
import { registerReducer } from './state/register/register.reducer';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from './state/auth/auth.effects';
import { RegisterEffects} from './state/register/register.effects'
import { messageReducer } from './state/messageBoard/message.reducer';
import { MessageEffects } from './state/messageBoard/message.effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    StoreModule.forRoot({auth: authReducer, register: registerReducer, message: messageReducer}),
    EffectsModule.forRoot([AuthEffects, RegisterEffects, MessageEffects]),
    StoreDevtoolsModule.instrument({maxAge: 10})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }