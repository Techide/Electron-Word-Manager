import { NgModule } from '@angular/core';

import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WordManagerModule } from './pages/word-manager/word-manager.module';

import { ContextMenuModule } from 'ngx-contextmenu';

@NgModule({
  declarations: [AppComponent],
  imports: [
    SharedModule,
    WordManagerModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
