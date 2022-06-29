import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Shipper } from '../models/shipper';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  endpoint: string = 'shippers';

  constructor(private http: HttpClient) { }

  public addShipper(shipperRequest: Shipper): Observable<any> {
    const url = environment.apiShippers + this.endpoint;
    return this.http.post(url, shipperRequest)
  }

  public editShipper(shipperRequest: Shipper): Observable<any> {
    const url = environment.apiShippers + this.endpoint;
    return this.http.put(url, shipperRequest)
  }

  public deleteShipper(id:number|string) {
    return this.http.delete(environment.apiShippers + this.endpoint + `/${id}`);
  }

  public getShippers(): Observable<Array<Shipper>> {
    const url = environment.apiShippers + this.endpoint;
    return this.http.get<Array<Shipper>>(url);
  }
}
