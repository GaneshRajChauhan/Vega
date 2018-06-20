import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http:Http) { }
  getMakes(){
    return this.http.get('api/makes/GetMakes').map(res=>res.json())
  }
  getFeatures(){
    return this.http.get('/api/feature/getFeatures').map(res=>res.json());
  }

  createVehicle(vehicle){
    return this.http.post('/api/vehicles',vehicle).map(res=>res.json());
  }
}
