import { Directive, HostListener } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[ewmNumbersOnly]'
})
export class NumbersOnlyDirective {
  constructor(private el: NgControl) {}

  @HostListener('input', ['$event.target.value'])
  oninput(value: string) {
    this.el.control.patchValue(value.replace(/[^0-9]/g, ''));
    // this.el.control.updateValueAndValidity();
  }
}
