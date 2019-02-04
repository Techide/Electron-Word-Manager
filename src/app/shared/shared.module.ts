import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { UserButtonComponent } from './components/user-button/user-button.component';
import { ContextMenuModule } from 'ngx-contextmenu';
import { MinValueDirective } from './directives/min-value.directive';
import { ContainsNumberDirective } from './directives/contains-number.directive';
import { NumbersOnlyDirective } from './directives/numbers-only.directive';

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
    MinValueDirective,
    ContainsNumberDirective,
    NumbersOnlyDirective
  ],
  declarations: [
    UserButtonComponent,
    MinValueDirective,
    ContainsNumberDirective,
    NumbersOnlyDirective,
  ]
})
export class SharedModule { }
