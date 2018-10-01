import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { UserButtonComponent } from './components/user-button/user-button.component';
import { ModalComponent } from './components/modal/modal.component';
import { ContextMenuModule } from 'ngx-contextmenu';
import { MinValueDirective } from './directives/min-value.directive';
import { ContainsNumberDirective } from './directives/contains-number.directive';
import { NumbersOnlyDirective } from './directives/numbers-only.directive';
import { RadioButtonComponent } from './components/radio-button/radio-button.component';

@NgModule({
  imports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ContextMenuModule.forRoot({
      autoFocus: true,
      useBootstrap4: false
    })
  ],
  exports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ContextMenuModule,
    UserButtonComponent,
    ModalComponent,
    RadioButtonComponent,
    MinValueDirective,
    ContainsNumberDirective,
    NumbersOnlyDirective
  ],
  declarations: [
    UserButtonComponent,
    ModalComponent,
    MinValueDirective,
    ContainsNumberDirective,
    NumbersOnlyDirective,
    RadioButtonComponent
  ]
})
export class SharedModule {}
