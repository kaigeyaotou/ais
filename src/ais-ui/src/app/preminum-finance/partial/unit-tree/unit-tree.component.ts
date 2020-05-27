import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { PreminumObServices } from '../../services/preminumOb.services';
declare var $: any;

@Component({
  selector: 'app-unit-tree',
  templateUrl: './unit-tree.component.html',
  styleUrls: ['./unit-tree.component.css']
})
export class UnitTreeComponent implements OnInit, OnDestroy {

  checkednodes: Array<any> = [];
  @Input()
  set versionId(val) {
    if (val && val != 0) {
      this._versionId = val;
      this.preminumService.getUnittrees(val).subscribe(res => {
        $('#unittree').jstree({
          'core': {
            'data': res
          },
          'plugins': ['checkbox']
        });
      })

    }
  }
  get versionId() {
    return this._versionId;
  }
  allchecked: boolean = true;
  @Input() units: Array<any> = new Array<any>();

  private _versionId: number;
  constructor(private preminumService: PreminumFinanceService,
    private preminum$: PreminumObServices) { }
  ngOnDestroy(): void {
  }


  ngOnInit(): void {

    this.preminum$.save$.subscribe(res => {

      const checkednodeids: Array<any> = $('#unittree').jstree().get_checked();
      if (checkednodeids.length > 0) {
        checkednodeids.forEach(node_id => {
          this.checkednodes.push(node_id);
          // const node = $('#unittree').jstree().get_node(node_id);
          // this.checkednodes.push({
          //   id_division_product: node.data.id_division_product
          //   // id_division: node.data.id_division,
          //   // id_product: node.data.id_product,
          //   // id_lob: node.data.id_lob,
          //   // id_coverage: node.data.id_coverage
          // });
        });
       
      }
      this.preminum$.checkcansave$.next({ unittree: this.checkednodes });
    });


  }



}
