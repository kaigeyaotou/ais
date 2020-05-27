import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PreminumFinanceRouttingModule } from './preminum-finance.routting.module';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatDialogModule,
    PreminumFinanceRouttingModule
  ]
})
export class PreminumFinanceModule { }
