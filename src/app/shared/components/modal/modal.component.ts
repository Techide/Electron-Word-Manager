import {
  Component,
  OnInit,
  OnDestroy,
  Input,
  ElementRef,
  Output,
  EventEmitter
} from '@angular/core';
import { ModalService } from '../../services/modal.service';

@Component({
  selector: 'ewm-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit, OnDestroy {
  @Input()
  id: string;

  data: any;

  private element: any;

  constructor(private modalService: ModalService, private el: ElementRef) {
    this.element = el.nativeElement;
    this.keyupHandler = this.keyupHandler.bind(this);
  }

  ngOnInit() {
    const modal = this;

    if (!this.id) {
      console.error('modal must have an id');
      return;
    }

    // move element to bottom of page (just before </body>) so it can be displayed above everything else
    document.body.appendChild(this.element);

    // close modal on background click
    // this.element.addEventListener('click', function(e: any) {
    //   if (e.target.className === 'ewm-modal-container') {
    //     modal.close();
    //   }
    // });

    // add self (this modal instance) to the modal service so it's accessible from controllers
    this.modalService.add(this);
  }

  ngOnDestroy(): void {
    this.modalService.remove(this.id);
    this.element.remove();
  }

  // open modal
  open(data?: any): void {
    window.addEventListener('keyup', this.keyupHandler);
    this.element.style.display = 'block';
    this.data = data;
  }

  // close modal
  close(): void {
    window.removeEventListener('keyup', this.keyupHandler);
    this.element.style.display = 'none';
  }

  private keyupHandler(e: KeyboardEvent) {
    if (e.keyCode !== 27) {
      return;
    }
    this.close();
  }
}
