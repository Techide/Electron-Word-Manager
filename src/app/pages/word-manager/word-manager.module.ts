import { NgModule } from '@angular/core';

import { WordManagerRoutingModule } from './word-manager-routing.module';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { SharedModule } from '../../shared/shared.module';
import { WordManagerComponent } from './word-manager.component';

@NgModule({
  imports: [SharedModule, WordManagerRoutingModule],
  declarations: [NavigationMenuComponent, WordManagerComponent]
})
export class WordManagerModule {}
