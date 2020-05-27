import { Directive, Input, ElementRef, Output, HostListener, EventEmitter } from '@angular/core';


@Directive({
  selector: '[appChkData]'
})
export class ChkDataDirective {

  @Input() data_id: string;
  @Output() checkEmmit: EventEmitter<any> = new EventEmitter<any>();
  @HostListener('change') onchange() {
    this.checkEmmit.emit(this.elRef.nativeElement.value);
  }
  constructor(private elRef: ElementRef) {

  }

}
