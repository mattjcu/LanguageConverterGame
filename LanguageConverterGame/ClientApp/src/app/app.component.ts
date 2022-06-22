import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromAuth from '../app/state/auth/auth.reducer';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  jwtToken$ = this.store.select(fromAuth.selectToken);
  user$ = this.store.select(fromAuth.selectUser);
  constructor(private store: Store<fromAuth.State>) { }
  ngOnInit(): void {}

  logout(): void {
    window.location.reload();
  }
}
