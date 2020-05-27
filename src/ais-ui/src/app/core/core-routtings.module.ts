import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ChkDataDirective } from './partial/chk-data.directive';

const routings: Routes = [
    { path: 'state', loadChildren: () => import('../preminum-finance/preminum-finance.module').then(m => m.PreminumFinanceModule) },
];

@NgModule({
    imports: [RouterModule.forChild(routings)],
    exports: [RouterModule],
    providers: [],
    declarations: [ChkDataDirective]
})
export class CoreRouttingModule {

}