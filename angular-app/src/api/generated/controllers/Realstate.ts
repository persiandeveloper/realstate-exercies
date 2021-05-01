/* tslint:disable:max-line-length */
/**
 * API
 * Description for the API.
 * Babak
 * v1
 * undefined
 */

import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {RealStateObject} from '../model'

@Injectable()
export class RealstateService {
  constructor(private http: HttpClient) {}

  topAgents(): Observable<RealStateObject[]> {
    return this.http.get<RealStateObject[]>(`http://localhost:5000/api/v1/Realstate`);
  }

  topDeals(): Observable<RealStateObject[]> {
    return this.http.get<RealStateObject[]>(`http://localhost:5000/api/v1/Realstate/forsale`);
  }
}
