import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NxWelcome } from './nx-welcome';
import { MyAngularLib } from '@nx-example/my-angular-lib';

@Component({
  imports: [NxWelcome, RouterModule, MyAngularLib],
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected title = 'my-angular-app';
}
