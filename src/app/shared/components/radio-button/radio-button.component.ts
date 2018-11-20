import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'ewm-radio-button',
  templateUrl: './radio-button.component.html',
  styleUrls: ['./radio-button.component.scss']
})
export class RadioButtonComponent {
  @Input()
  selectedGroupId: number;

  @Input()
  groupId: number;

  @Output()
  clicked: EventEmitter<number> = new EventEmitter();

  onClicked() {
    this.clicked.emit(this.groupId);
  }

  showIcon() {
    return Number(this.selectedGroupId) === Number(this.groupId);
  }
}
