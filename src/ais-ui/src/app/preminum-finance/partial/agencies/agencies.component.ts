import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
declare var $: any;

@Component({
  selector: 'app-agencies',
  templateUrl: './agencies.component.html',
  styleUrls: ['./agencies.component.css']
})
export class AgenciesComponent implements OnInit {

  @Input()
  get versionId() {
    return this._versionId;
  }
  set versionId(val: any) {
    if (val) {
      this._versionId = val;
      this.init();
    }
  }

  checked_datecreated: boolean = false;
  pageArr = [1, 10, 20];
  indexArr: Array<number> = new Array<number>();
  rows = [];
  pageCount: any = 10;
  pageIndex: number = 1;
  checked_partne: boolean = false;
  countries: Array<any> = new Array<any>();
  states: Array<any> = new Array<any>();
  condition_country_id: number;
  rates: Array<any> = new Array<any>();
  condition_state_id: number;
  condition_has_pf: number;
  condition_agency_name: string;
  condition_rate_id: string;
  condition_quick_search: string;
  condition_zip: string;
  pageTotal: number;


  private _versionId: number;
  constructor(private preminumService: PreminumFinanceService) {

  }

  ngOnInit(): void {


    this.BindStateCountry();
    this.getRateTables();
    this.BindTimeControl();
  }

  BindTimeControl() {
    $('#date_begin').datepicker();
    $('#date_end').datepicker();
  }

  init() {
    const condition = {
      "condition": {

      },
      "id_version": this.versionId,
      "pageIndex": this.pageIndex,
      "pageSize": this.pageCount
    };
    this.queryAgencies(condition);
  }

  changeDateCreated(event: any) {
    this.checked_datecreated = event.target.checked;

  }

  changePartne(event: any) {
    this.checked_partne = event.target.checked;

  }

  getRateTables() {

    this.preminumService.getRateTables().subscribe(res => {
      this.rates = res;
    })
  }

  changePage(event: any) {
    this.pageIndex = 1;

  }

  loadPageSize(total: number) {
    const count = Math.ceil(total / this.pageCount);
    if (count > 0) {
      for (let i = 1; i <= count; i++) {
        this.indexArr.push(i);
      }
    }
  }


  queryAgencies(condition) {
    this.preminumService.getAgencies(condition).subscribe(res => {
      this.rows = res.item1;
      this.pageTotal = res.item2;
      this.loadPageSize(this.pageTotal);
    });
  }

  countrychange() {

    this.GetStatesByCountryId(this.condition_country_id);
  }

  BindStateCountry() {
    this.preminumService.getAllCountries().subscribe(res => {
      this.countries = res;
    });
  }

  quickClick() {
    if (this.condition_quick_search) {
      const condition = {
        "condition": {
          "condition_agency_name": this.condition_quick_search
        },
        "pageIndex": this.pageIndex,
        "pageSize": this.pageCount
      };
      this.queryAgencies(condition);
    }
  }

  clearPageSize() {
    this.indexArr = new Array<number>();
  }



  search() {
    this.clearPageSize();
    const condition = {
      "condition": {
        "condition_agency_name": this.condition_quick_search,
        "condition_zip": null,
        "condition_country_id": null,
        "condition_state_id": null,
        "condition_ratetable_id": null,
        "condition_has_pf": null,
        "condition_date_begin": null,
        "condition_date_end": null
      },
      "id_version": this.versionId,
      "pageIndex": this.pageIndex,
      "pageSize": this.pageCount
    };

    if (this.condition_agency_name)
      condition.condition.condition_agency_name = this.condition_agency_name;
    if (this.condition_zip)
      condition.condition.condition_zip = this.condition_zip;
    if (this.condition_country_id)
      condition.condition.condition_country_id = this.condition_country_id;
    if (this.condition_state_id)
      condition.condition.condition_state_id = this.condition_state_id;
    if (this.condition_rate_id)
      condition.condition.condition_ratetable_id = this.condition_rate_id;
    if (this.condition_has_pf)
      condition.condition.condition_has_pf = this.condition_has_pf;
    if (!this.checked_datecreated) {
      if ($('#date_end').val()) {
        condition.condition.condition_date_end = $('#date_end').val();
      }
      if ($('#date_begin').val())
        condition.condition.condition_date_begin = $('#date_begin').val();
    }

    this.queryAgencies(condition);
  }

  GetStatesByCountryId(id_country) {

    this.preminumService.getStatesByCountryId(id_country).subscribe(res => {
      this.states = res;
    })
  }

}
