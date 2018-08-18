import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveVehicle } from '../models/vehicle';

@Injectable()
export class VehicleService {

  private readonly vechiclesEndPoint='/api/vehicles';

  constructor(private http:Http) { }
  getMakes(){
    return this.http.get('api/makes/GetMakes').map(res=>res.json());
  }
  getFeatures(){
    return this.http.get('api/feature/getFeatures').map(res=>res.json());
  }

  createVehicle(vehicle){
    return this.http.post(this.vechiclesEndPoint,vehicle).map(res=>res.json());
  }
  update(vehicle:SaveVehicle){
   return this.http.put(this.vechiclesEndPoint+"/"+vehicle.id,vehicle)
   .map(res=>res.json());
  }
  getVehicle(id){
    return this.http.get(this.vechiclesEndPoint+'/'+id)
    .map(res=>res.json());
  }
  getVehicles() {
    return this.http.get(this.vechiclesEndPoint)
      .map(res => res.json());
  }
  Delete(id){
    return this.http.delete(this.vechiclesEndPoint+"/"+id)
    .map(res=>res.json());
  }
}
