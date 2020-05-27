import { Component, OnInit, TemplateRef, Input } from '@angular/core';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CreateStateComponent } from '../create-state/create-state.component';
import { PreminumObServices } from '../../services/preminumOb.services';
import { EditStateComponent } from '../edit-state/edit-state.component';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/core/partial/confirm-dialog/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-states',
  templateUrl: './states.component.html',
  styleUrls: ['./states.component.css']
})

export class StatesComponent implements OnInit {

  @Input() versionId: number;
  createmodal: BsModalRef;
  editmodal: BsModalRef;
  @Input() states: Array<any>;
  constructor(private preminumService: PreminumFinanceService,
    private modalService: BsModalService,
    private preminum$: PreminumObServices,
    public dialog: MatDialog) { }

  ngOnInit(): void {


    this.preminum$.save$.subscribe(res => {
      // const handle_states: Array<any> = this.states.filter(a => a.hasOwnProperty('status'));
      this.preminum$.checkcansave$.next({ state: this.states });
    });


  }

  editState(state: any) {
    this.editmodal = this.modalService.show(EditStateComponent, Object.assign({}, { class: 'gray modal-lg' }));
    this.editmodal.content.state = state;
  }

  openDialog() {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '250px',
      data: {
        msg: 'willing to close?'
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      alert(result);
    });
  }

  addState() {

    this.createmodal = this.modalService.show(CreateStateComponent, Object.assign({}, { class: 'gray modal-lg' }));
    this.createmodal.content.closeBtnName = "close";
    this.createmodal.content.stateSave.subscribe(res => {
      this.states.push({
        state_id: res.stateId,
        license: res.license,
        hasexpiration: res.hasExpiration,
        effective_date: res.effectiveDate.toLocaleDateString(),
        expiration_date: res.expirationDate.toLocaleDateString(),
        status: 'create'
      })
    });
  }



}
