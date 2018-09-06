import { NgModule } from '@angular/core';

import { WordManagerRoutingModule } from './word-manager-routing.module';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { SharedModule } from '../../shared/shared.module';
import { WordManagerComponent } from './word-manager.component';
import { RankSelectionComponent } from './rank-selection/rank-selection.component';
import { CurriculumDetailsComponent } from './curriculum-details/curriculum-details.component';
import { CurriculumPageComponent } from './curriculum-page/curriculum-page.component';

@NgModule({
  imports: [SharedModule, WordManagerRoutingModule],
  declarations: [
    NavigationMenuComponent,
    WordManagerComponent,
    RankSelectionComponent,
    CurriculumDetailsComponent,
    CurriculumPageComponent
  ]
})
export class WordManagerModule {}
