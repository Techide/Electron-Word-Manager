import { Directive, Input } from '@angular/core';
import { Validator, AbstractControl, NG_VALIDATORS } from '@angular/forms';
import { containsNumberValidator } from '../validators/contains-number.validator';

@Directive({
  selector: '[ewmContainsNumber]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: ContainsNumberDirective,
      multi: true
    }
  ]
})
export class ContainsNumberDirective implements Validator {
  // tslint:disable-next-line:no-input-rename
  @Input('ewmContainsNumber')
  condition;

  validate(c: AbstractControl): { [key: string]: any } {
    return containsNumberValidator(this.condition)(c);
  }
}
