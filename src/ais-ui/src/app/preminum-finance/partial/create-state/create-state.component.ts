import { Component, OnInit, ViewChild, ElementRef, TemplateRef, Output, EventEmitter } from '@angular/core';
import { BsDatepickerConfig, BsModalService, BsModalRef } from 'ngx-bootstrap';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { stateArgs } from '../../services/models/statesArgs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmDialogComponent } from 'src/app/core/partial/confirm-dialog/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
declare var $: any;

@Component({
  selector: 'app-create-state',
  templateUrl: './create-state.component.html',
  styleUrls: ['./create-state.component.css']
})
export class CreateStateComponent implements OnInit {

  title = 'State';
  stateArgs: stateArgs;
  stateAbbrs: Array<any>;
  modalRef: any;
  form: FormGroup;
  @Output() stateSave: EventEmitter<any> = new EventEmitter();

  constructor(private preminumService: PreminumFinanceService,
    private modalService: BsModalService,
    private formbuilder: FormBuilder,
    public createmodal: BsModalRef,
    public dialog: MatDialog) {

  }
  @ViewChild('date_effective') date_effective: ElementRef;
  @ViewChild('date_expiration') date_expiration: ElementRef;
  ngOnInit(): void {
    this.loadForm();
    this.stateArgs = {
      state: "",
      stateId: 0,
      license: "",
      effectiveDate: null,
      expirationDate: null,
      hasExpiration: false

    };

    this.initDatePicker();
    this.bindDrop();
  }

  loadForm() {
    this.form = this.formbuilder.group({
      license: ['', [Validators.required]],
      stateId: [, [Validators.required]],
      hasExpiration: [false, [Validators.required]]
    })
  }

  selectChange($event: any) {
    let text = $event.target.options[$event.target.options.selectedIndex].text;
    this.stateArgs.state = text;
  }

  initDatePicker() {

    $('#date_expiration').datepicker();
    $('#date_effective').datepicker();

  }



  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  save() {

    this.stateArgs.expirationDate = new Date(this.date_expiration.nativeElement.value);
    this.stateArgs.effectiveDate = new Date(this.date_effective.nativeElement.value);
    this.stateArgs.hasExpiration = this.form.value.hasExpiration;
    this.stateArgs.license = this.form.value.license;
    this.stateArgs.stateId = this.form.value.stateId;

    this.stateSave.emit(this.stateArgs);
  }

  confirm() {
    this.modalRef.hide();
  }

  decline() {
    this.modalRef.hide();
  }

  bindDrop() {
    this.preminumService.getStatesDrops().subscribe((res: any) => {
      this.stateAbbrs = res;
    })
  }

  checkChange(event$: any) {
    const a = event$;
  }

}
