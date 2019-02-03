import { Component } from '@angular/core';

@Component({
  selector: 'ewm-root',
  template: '<router-outlet></router-outlet><router-outlet name ="modal"></router-outlet>'
})
export class AppComponent {
  title = 'Jiu Jutsu Gradueringer';

  constructor() {
  }
}
