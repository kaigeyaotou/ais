import { Component, OnInit } from '@angular/core';
import { PreminumFinanceService } from '../../services/preminum-finance.service';
import { PreminumObServices } from '../../services/preminumOb.services';
import { AgencyRateComponent } from '../agency-rate/agency-rate.component';

@Component({
  selector: 'app-versions',
  templateUrl: './versions.component.html',
  styleUrls: ['./versions.component.css']
})
export class VersionsComponent implements OnInit {

  versions: Array<any>;
  menu = AgencyRateComponent;
  constructor(private preminumService: PreminumFinanceService,
    private preminum$: PreminumObServices) { }

  ngOnInit(): void {
  }

  save() {
    this.preminum$.save$.next('save');
  }


}
