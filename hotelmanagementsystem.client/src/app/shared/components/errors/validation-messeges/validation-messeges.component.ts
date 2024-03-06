import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-validation-messeges',
  templateUrl: './validation-messeges.component.html',
  styleUrl: './validation-messeges.component.css'
})
export class ValidationMessegesComponent {
  @Input() errorMessages: string[] | undefined;
}
