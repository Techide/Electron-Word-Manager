import * as typeChecker from './type-check.helper';

export function set(key: string, value: any): void {
  if (typeChecker.isObject(value)) {
    value = JSON.stringify(value);
  }

  localStorage.setItem(key, value);
}

export function get(key: string): any {
  const val = localStorage.getItem(key);
  let result = null;
  try {
    result = JSON.parse(val);
  } catch (error) {
    result = val;
  }
  return result;
}

export function remove(key: string): void {
  localStorage.removeItem(key);
}

export function clear(): void {
  localStorage.clear();
}
