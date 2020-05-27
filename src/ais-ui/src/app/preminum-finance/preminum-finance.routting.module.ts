import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { StatesComponent } from './partial/states/states.component';
import { VersionsComponent } from './partial/versions/versions.component';
import { AgenciesComponent } from './partial/agencies/agencies.component';
import { UnitTreeComponent } from './partial/unit-tree/unit-tree.component';
import { MarketsComponent } from './partial/markets/markets.component';

const appRoues: Routes = [
    { path: '', component: StatesComponent },
    { path: 'versions', component: VersionsComponent },
    { path: 'agencies', component: AgenciesComponent },
    { path: 'unit-tree', component: UnitTreeComponent },
    { path: 'mp', component: MarketsComponent }
];

@NgModule({
    imports: [RouterModule.forChild(appRoues)],
    exports: [RouterModule],
    providers: []
})
export class PreminumFinanceRouttingModule {

}