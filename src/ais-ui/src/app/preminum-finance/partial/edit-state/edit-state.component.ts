import { Component, OnInit, ElementRef, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { stateArgs } from '../../services/models/statesArgs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
declare const $: any;

@Component({
  selector: 'app-edit-state',
  templateUrl: '../create-state/create-state.component.html',
  styleUrls: ['../create-state/create-state.component.css']
})
export class EditStateComponent implements OnInit {

  @Input()
  set state(val) {
    if (val) {
      this._state = val;
      this.form.controls['license'].setValue(val.license);
      this.form.controls['stateId'].setValue(val.state_id);
      this.form.controls['hasExpiration'].setValue(val.hasexpiration);
      this.form.controls['id_state'].setValue(val.id_state);
      this.date_effective.nativeElement.value = val.effective_date;
      this.date_expiration.nativeElement.value = val.expiration_date;
    }

  }
  get state() {
    return this._state;
  }
  @Output() stateEdit: EventEmitter<any> = new EventEmitter();
  title = 'State';
  stateArgs: any;
  stateAbbrs: Array<any>;
  modalRef: any;
  form: FormGroup;

  @ViewChild('date_effective') date_effective: ElementRef;
  @ViewChild('date_expiration') date_expiration: ElementRef;

  private _state: any;
  constructor(private preminumService: PreminumFinanceService,
    private modalService: BsModalService,
    private formbuilder: FormBuilder,
    public createmodal: BsModalRef) { }

  ngOnInit(): void {
    this.bindDrop();
    this.initDatePicker();
    this.loadForm();
  }

  bindDrop() {
    this.preminumService.getStatesDrops().subscribe((res: any) => {
      this.stateAbbrs = res;
    })
  }

  loadForm() {
    this.form = this.formbuilder.group({
      id_state: ['', []],
      license: ['', [Validators.required]],
      stateId: [, [Validators.required]],
      hasExpiration: [false, [Validators.required]]
    })
  }

  initDatePicker() {

    $('#date_expiration').datepicker();
    $('#date_effective').datepicker();

  }

  save() {

    this.stateArgs.expirationDate = new Date(this.date_expiration.nativeElement.value);
    this.stateArgs.effectiveDate = new Date(this.date_effective.nativeElement.value);
    this.stateArgs.hasExpiration = this.form.value.hasExpiration;
    this.stateArgs.license = this.form.value.license;
    this.stateArgs.stateId = this.form.value.stateId;
    this.stateArgs.id_state = this.form.value.id_state;
    this.stateEdit.emit(this.stateArgs);
  }
  checkChange(val: any) {
    const checked = val.currentTarget.checked;
    if(checked){
    }
  }

  selectChange($event: any) { }

}
