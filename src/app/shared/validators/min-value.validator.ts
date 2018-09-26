import { FormControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function minValueValidator(
  val: number,
  minValue: number
): ValidationErrors | null {
  if (val == null || minValue == null) {
    return null;
  }

  const lessThan = val < minValue;
  return lessThan ? { minValue: true } : null;
}
