import { Subject, Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: "root" })
export class PreminumObServices {
    save$: Subject<any>;
    checkcansave$: Subject<any>;
    changeMP$: Subject<any>;
    clearparam$: Subject<any>;

    constructor() {
        this.save$ = new Subject<any>();
        this.checkcansave$ = new Subject<any>();
        this.changeMP$ = new Subject<any>();
        this.clearparam$ = new Subject<any>();
    }
}