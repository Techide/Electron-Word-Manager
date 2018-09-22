import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private modals: any[] = [];

  // onFormDataSubmitted: EventEmitter<any> = new EventEmitter();

  /** add modal to array of active modals */
  add(modal: any) {
    this.modals.push(modal);
  }

  /** remove modal from array of active modals */
  remove(id: string) {
    this.modals = this.modals.filter(x => x.id !== id);
  }

  /** open modal specified by id */
  open(id: string) {
    const modal: any = this.modals.filter(x => x.id === id)[0];
    modal.open();
  }

  openForm(id: string, model: any) {
    const modal: any = this.modals.filter(x => x.id === id)[0];
    modal.open(model);
    // modal.onFormDataSubmitted.subscribe(x => this.onFormDataSubmitted.emit(x));
  }

  /** close modal specified by id */
  close(id: string) {
    const modal: any = this.modals.filter(x => x.id === id)[0];
    modal.close();
  }
}
