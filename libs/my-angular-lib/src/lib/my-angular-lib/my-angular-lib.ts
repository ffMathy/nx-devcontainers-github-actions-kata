import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-my-angular-lib',
  imports: [CommonModule],
  templateUrl: './my-angular-lib.html',
  styleUrl: './my-angular-lib.css',
})
export class MyAngularLib {
  title = 'My Angular Library Component';
  items = ['Item 1', 'Item 2', 'Item 3'];

  addItem(): void {
    this.items.push(`Item ${this.items.length + 1}`);
  }
}
