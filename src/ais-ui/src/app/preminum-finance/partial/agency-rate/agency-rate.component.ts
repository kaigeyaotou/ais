import { Component, OnInit } from '@angular/core';

import { MenuComponent, ContextMenuService, MenuPackage } from '@ctrl/ngx-rightclick';



@Component({
  selector: 'app-agency-rate',
  templateUrl: './agency-rate.component.html',
  styleUrls: ['./agency-rate.component.css']
})
export class AgencyRateComponent extends MenuComponent implements OnInit {

  lazy = false;
  constructor(public menuPackage: MenuPackage,
    public contextMenuService: ContextMenuService, ) {
    super(menuPackage, contextMenuService);
  }

  ngOnInit(): void {
  }

  handleClick() {
    // IMPORTANT! tell the menu to close, anything passed in here is given to (menuAction)
    this.contextMenuService.closeAll();
  }

}
