import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';
import { minValueValidator } from '../validators/min-value.validator';

@Directive({
  selector: '[ewmMinValue]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: MinValueDirective, multi: true }
  ]
})
export class MinValueDirective implements Validator {
  // tslint:disable-next-line:no-input-rename
  @Input('ewmMinValue')
  minValue;

  validate(c: AbstractControl): { [key: string]: any } {
    const minVal = parseInt(this.minValue, 10);
    const val = parseInt(c.value, 10);
    const result = this.minValue ? minValueValidator(val, minVal) : null;
    return result;
  }
}
