import { ValidatorFn, FormControl, ValidationErrors } from '@angular/forms';

class Condition {
  collection: number[];
  except: number;
}

export function containsNumberValidator(condition: Condition): ValidatorFn {
  return (control: FormControl): ValidationErrors | null => {
    if (control.value == null || condition.collection == null) {
      return null;
    }

    let contains: boolean = null;
    let excludeIndex = -1;

    if (condition.except) {
      excludeIndex = condition.collection.indexOf(condition.except);
    }

    if (excludeIndex >= 0) {
      condition.collection.splice(excludeIndex, 1);
    }

    const val = parseInt(control.value, 10);
    contains = condition.collection.includes(val);

    return contains ? { containsNumber: true } : null;
  };
}
