import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { PreminumObServices } from '../../services/preminumOb.services';
declare var $: any;

@Component({
  selector: 'app-markets',
  templateUrl: './markets.component.html',
  styleUrls: ['./markets.component.css']
})
export class MarketsComponent implements OnInit, AfterViewInit {

  @Input()
  set versionId(val) {
    if (val != 0 && val) {
      this._versionId = val;
      this.loadmpRelated().then(() => {
        this.preminumService.getContractTree(this.versionId).subscribe(res => {
          $('#id_contracttree').jstree({
            'core': {
              'data': res
            },
            'plugins': ['checkbox']
          });
        })

      });

    }
  }
  get versionId() {
    return this._versionId;
  }
  contract_types: Array<any> = new Array<any>();
  allPayment: boolean = false;
  allSubContract: boolean = false;
  allContractType: boolean = false;
  mp_payments: Array<number> = new Array<number>();
  mp_subcontracts: Array<number> = new Array<number>();
  mp_contract_types: Array<number> = new Array<number>();

  mp_payments_param: Array<any> = new Array<any>();
  mp_subcontracts_param: Array<any> = new Array<any>();
  mp_contract_types_param: Array<any> = new Array<any>();

  private _versionId: number;
  constructor(private preminumService: PreminumFinanceService,
    private prem$: PreminumObServices) { }
  ngAfterViewInit(): void {

  }

  ngOnInit(): void {

    this.prem$.changeMP$.subscribe(res => {
      setTimeout(() => {
        const checkboxs = $('#div-contract-type input[type="checkbox"]');
        checkboxs.each(item => {
          if (this.mp_contract_types.some(a => a == $(checkboxs[item])[0].id)) {
            $(checkboxs[item]).prop('checked', true)
          }
        })
      }, 2000);

      this.prem$.save$.subscribe(res => {
        if (this.allContractType === true) {
          this.mp_contract_types_param.push(0);
        }
        else {
          const chk_contract_types = $('#chk_contract_type input[type=checkbox]:checked');
          if (chk_contract_types.length > 0) {
            chk_contract_types.each(item => {
              const id_contracttree = chk_contract_types[item].id;
              this.mp_contract_types_param.push(id_contracttree);
            });
          }
        }

        if (this.allPayment === true) {
          this.mp_payments_param.push(0);
        }
        else {
          const chk_payments = $('#chk_payment input[type=checkbox]:checked');
          if (chk_payments.length > 0) {
            chk_payments.each(item => {
              this.mp_payments_param.push(chk_payments[item].id)
            })
          }
        }

        if (this.allSubContract === true) {
          this.mp_subcontracts_param.push(0);
        } else {
          const checkednodeids: Array<any> = $('#id_contracttree').jstree().get_checked();
          checkednodeids.forEach(node_id => {
            const node = $('#id_contracttree').jstree().get_node(node_id);
            this.mp_subcontracts_param.push(
              node.data.id
            );
          });
        }
        this.prem$.checkcansave$.next({
          market: {
            mp_contract_types: this.mp_contract_types_param,
            mp_payments: this.mp_payments_param,
            mp_subcontracts: this.mp_subcontracts_param
          }
        })

      });
    })

    this.preminumService.getContractType().subscribe(res => {
      this.contract_types = res;
    });




  }

  save() {
    if (this.allContractType === true) {
      this.mp_contract_types_param.push(0);
    }
    else {
      const chk_contract_types = $('#chk_contract_type input[type=checkbox]:checked');
      if (chk_contract_types.length > 0) {
        chk_contract_types.each(item => {
          const id_contracttree = chk_contract_types[item].id;
          this.mp_contract_types_param.push(id_contracttree);
        });
      }
    }

    if (this.allPayment === true) {
      this.mp_payments_param.push(0);
    }
    else {
      const chk_payments = $('#chk_payment input[type=checkbox]:checked');
      if (chk_payments.length > 0) {
        chk_payments.each(item => {
          this.mp_payments_param.push(chk_payments[item].id)
        })
      }
    }

    const checkednodeids: Array<any> = $('#id_contracttree').jstree().get_checked();
    checkednodeids.forEach(node_id => {
      const node = $('#id_contracttree').jstree().get_node(node_id);
      this.mp_subcontracts_param.push(
        node.data.id
      );
    });
  }

  loadmpRelated(): Promise<any> {

    return new Promise<any>((resolve, error) => {

      this.preminumService.getMPRelated(this.versionId).subscribe(res => {
        if (res.mp_contract_types) {
          if (res.mp_contract_types.some(a => a === 0)) {
            this.allContractType = true;
          } else {
            this.mp_contract_types = res.mp_contract_types;
          }
          if (res.mp_payments.some(a => a === 0)) {
            this.allPayment = true;
          } else {
            this.mp_payments = res.mp_payments;
          }
          if (res.mp_subcontracts.some(a => a === 0)) {
            this.allSubContract = true;

          } else {
            this.mp_subcontracts = res.mp_subcontracts;
          }
          resolve();
        }
      }, error => {

      })
    });

  }

}
