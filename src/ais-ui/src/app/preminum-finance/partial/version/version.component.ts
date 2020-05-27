import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { PreminumObServices } from '../../services/preminumOb.services';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
declare var $: any;


@Component({
  selector: 'app-version',
  templateUrl: './version.component.html',
  styleUrls: ['./version.component.css']
})
export class VersionComponent implements OnInit {

  @ViewChild('hidVal') hidVal: ElementRef;
  agencies: Array<any> = new Array<any>();
  versions: Array<any> = new Array<any>();
  units: Array<any> = new Array<any>();
  versionId: number;
  arg: any;
  @ViewChild('eff_date') eff_date: ElementRef;
  states: Array<any> = new Array<any>();
  save_data: any = {};
  constructor(private preminum$: PreminumObServices,
    private priminumService: PreminumFinanceService) { }

  ngOnInit(): void {
    this.getVersions().then((id_version: any) => {
      this.versionId = id_version;
      this.loadVersion(id_version);
    });

    this.preminum$.clearparam$.subscribe(res => {
      this.arg = {};
    });


    this.preminum$.save$.subscribe(res => {
      alert(this.hidVal.nativeElement.value)
      const agency_val = this.hidVal.nativeElement.value;
      const agency_arr = agency_val.split('$');
      if (agency_arr.length > 1) {
        for (let i = 0; i < agency_arr.length - 1; i++) {
          const str = agency_arr[i];
          this.agencies.push({
            agency_id: str.split(',')[0],
            rate_id: 0,
            haspf: str.split(',')[1]
          })
        }
      }
      this.preminum$.checkcansave$.next({ agency: this.agencies });
    });

    this.preminum$.checkcansave$.subscribe(res => {
      if (res.hasOwnProperty('agency'))
        this.save_data.agency = res.agency;
      if (res.hasOwnProperty('state'))
        this.save_data.state = res.state;
      if (res.hasOwnProperty('unittree'))
        this.save_data.unittree = res.unittree;
      if (res.hasOwnProperty('market'))
        this.save_data.market = res.market;
      if (this.save_data.hasOwnProperty('agency')) {
        if (this.save_data.hasOwnProperty('state')) {
          if (this.save_data.hasOwnProperty('unittree')) {
            if (this.save_data.hasOwnProperty('market')) {

              let param_units: Array<any> = new Array<any>();
              if (this.save_data.unittree.length > 0) {
                this.save_data.unittree.forEach(unit => {
                  param_units.push(unit);
                });
              }
              this.arg = {
                versionArg: {
                  id_version: this.versionId,
                  eff_date: new Date(this.eff_date.nativeElement.value),
                  units: param_units,
                  stateArgs: this.save_data.state,
                  mpContracts: {
                    mp_contract_types: this.save_data.market.mp_contract_types,
                    mp_sub_contracts: this.save_data.market.mp_subcontracts,
                    mp_payments: this.save_data.market.mp_payments
                  },
                  agencies: this.save_data.agency
                }
              };
              this.priminumService.addVersion(this.arg).subscribe((res) => { }, error => {
                alert(error.error);
              });

            }
          }
        }
      }

    });

    $('#eff_date').datepicker();


  }



  changeTab(versionId: any) {
    this.loadVersion(versionId);
  }

  loadVersion(versionId: any) {
    this.versionId = versionId;
    this.priminumService.getStatesByVersionId(this.versionId)
      .subscribe(res => {
        this.states = res;
      });

    this.getUnitVersions(versionId);
  }

  getUnitVersions(versionId) {

    this.priminumService.getUnitVersion(this.versionId).subscribe(res => {
      this.units = res;
    })
  }

  getVersions(): Promise<any> {
    return new Promise((resolve, error) => {
      this.priminumService.getVersions().subscribe(res => {
        this.versions = res;
        resolve(this.versions[0].id_version);
      }, error => {
        error();
      });
    });

  }

  changeAgency() {
    this.BindContextMenuForPF();
    // this.BindContextMenu();
  }

  GetRateTables(): Promise<any> {

    return new Promise((resolve, error) => {
      this.priminumService.getRateTables().subscribe(res => {
        resolve(res);
      })
    });
  }

  BindContextMenuForPF() {

    $.contextMenu({
      selector: '.preminum',
      callback: function (key, options) {
        const agency_id = $(this).closest('tr').find('td:eq(7)').text();
        const param = {
          agency_id: agency_id,
          rate_id: 0,
          haspf: options.items[key].data
        };
        $('#id_hidVal').val($('#id_hidVal').val() + `${agency_id},${param.haspf}$`);
        $(this).closest('tr').find('td:eq(1)').text(options.items[key].data === 1 ? 'Y' : 'N')
      },
      items: {
        Yes: {
          name: 'Yes',
          title: 'Yes',
          data: 1
        },
        No: {
          name: 'No',
          title: 'No',
          data: 0
        }
      }
    })
  }

  BindContextMenu() {
    this.GetRateTables().then(rates => {
      const actions: Array<any> = new Array<any>();
      rates.forEach(item => {
        actions.push({

          name: item.ratetable_name,
          data: item.id_ratetable,
          title: item.ratetable_name
        });
      });
      $.contextMenu({
        selector: '.preminum',
        build: function ($triggerElement, e) {
          var options = {
            callback: function (key, options) {
              const agency_id = $(this).closest('tr').find('td:eq(7)').text();
              alert(agency_id + ',' + key);
            },
            items: {}
          };
          options.items = actions

          return options;
        }
      })
    })

  }

  changeMP() {
    this.preminum$.changeMP$.next('change');
  }

}
