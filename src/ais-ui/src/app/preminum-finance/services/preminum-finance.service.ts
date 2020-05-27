import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PreminumFinanceService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getStatesByVersionId(versionId: number): Observable<any> {
    const url = `${this.baseUrl}preminum-finance/states?versionId=${versionId}`;
    return this.http.get(url);
  }

  getStatesDrops(): Observable<any> {
    const url = this.baseUrl + 'preminum-finance/states-drop';
    return this.http.get(url);
  }

  getAgencies(query: any): Observable<any> {

    const url = this.baseUrl + 'preminum-finance/agencies';
    return this.http.post(url, query);
  }

  getUnittrees(versionId): Observable<any> {

    const url = this.baseUrl + `preminum-finance/unit-tree/version?id_version=${versionId}`;
    return this.http.get(url);
  }

  getVersions(): Observable<any> {

    const url = this.baseUrl + "preminum-finance/versions";
    return this.http.get(url);
  }

  getMPRelated(id_version: number): Observable<any> {

    const url = this.baseUrl + `preminum-finance/mp-related?id_version=${id_version}`;
    return this.http.get(url);
  }

  addVersionUnitTest(): Observable<any> {
    try {
      const url = 'http:' + this.baseUrl + "preminum-finance/versions";
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': 'my-auth-token'
        })
      };
      var art = {
        "versionArg": {
          "id_version": 1,
          "eff_date": "2020-04-05T01:48:27.081Z",
          "units": [
            2
          ],
          "stateArgs": [
            {

              "state_id": 0,
              "license": "string",
              "effective_date": "2020-04-05T01:48:27.081Z",
              "expiration_date": "2020-04-05T01:48:27.081Z",
              "hasexpiration": true,
              "status": "string"
            },
            {
              "id_state": "F2E4B6D4-6204-4508-997D-4A492658C831",
              "state_id": 0,
              "license": "string",
              "effective_date": "2020-04-05T01:48:27.081Z",
              "expiration_date": "2020-04-05T01:48:27.081Z",
              "hasexpiration": true,

            }
          ]
        }
      };
      return this.http.post(url, art, httpOptions);
    }
    catch (ex) { }
  }

  getRateTables(): Observable<any> {

    const url = this.baseUrl + `preminum-finance/rate-tables`;

    return this.http.get(url);
  }

  addVersion(arg: any): Observable<any> {
    const url = this.baseUrl + "preminum-finance/versions";
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'my-auth-token'
      })
    };
    return this.http.post(url, JSON.stringify(arg), httpOptions);
  }

  getUnitVersion(id_version): Observable<any> {

    const url = this.baseUrl + "preminum-finance/unit-version";

    return this.http.get(`${url}?id_version=${id_version}`)
  }

  getContractTree(id_version): Observable<any> {

    const url = this.baseUrl + `preminum-finance/contract-tree?id_version=${id_version}`

    return this.http.get(url);
  }

  getContractType(): Observable<any> {

    const url = this.baseUrl + "preminum-finance/contract-type";

    return this.http.get(url);
  }

  getcountryStates(): Observable<any> {

    const url = this.baseUrl + `preminum-finance/country-state`;

    return this.http.get(url);
  }

  getAllCountries(): Observable<any> {

    const url = this.baseUrl + `preminum-finance/countries`;

    return this.http.get(url);
  }

  getStatesByCountryId(id_country: number): Observable<any> {

    const url = this.baseUrl + `preminum-finance/states/country/id?id_country=${id_country}`;

    return this.http.get(url);
  }
}
