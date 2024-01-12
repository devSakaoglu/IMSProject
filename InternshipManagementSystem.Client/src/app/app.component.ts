import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
 selector: 'app-root',
 template: `
    <router-outlet></router-outlet>
 `,
 styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project1';
  constructor() {}
}
