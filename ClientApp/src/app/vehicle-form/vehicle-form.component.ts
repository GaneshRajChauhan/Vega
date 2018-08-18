import * as _ from 'underscore';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';
import { SaveVehicle, Vehicle } from '../models/vehicle';
@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  features: any;
  makes: any;
  models: any;
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      email: '',
      phone: ''
    }
  };
  constructor(private vehicleService: VehicleService,
    private toastyService: ToastyService,
    private route: ActivatedRoute,
    private router: Router

  ) {
    this.route.params.subscribe(p => {
      this.vehicle.id = +p["id"];
    });
  }

  ngOnInit() {
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),
    ];
    if (this.vehicle.id) {
      sources.push(this.vehicleService.getVehicle(this.vehicle.id))
    }
    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];
      if (this.vehicle.id)
      {
        this.setVehicle(data[2]);
        this.populatesModels();

      }

    }, err => {
      if (err.status == 404) {
        this.router.navigate(['/Home']);
      }
    });
  }
  private setVehicle(v:Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered=v.isRegistered,
    this.vehicle.contact=v.contact,
    this.vehicle.features=_.pluck(v.features,'id');
  }
  onMakeChange() {
    this.populatesModels();


    delete this.vehicle.modelId;
  }

private populatesModels(){
  var selectedmakes = this.makes.find(m => m.id == this.vehicle.makeId);
  this.models = selectedmakes ? selectedmakes.models : [];
}
  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);

    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    if(this.vehicle.id)
    {
      this.vehicleService.update(this.vehicle)
      .subscribe(x=>{
        this.toastyService.success({
          title:'Success',
          msg:'The vehicel was sucessefully updated',
          theme:'bootstrap',
          showClose:true,
          timeout:5000
        })
      })
    }
    else
    {
      if  (!this.vehicle.id)
      {
        this.vehicle.id=0;
      }
      this.vehicleService.createVehicle(this.vehicle)
      .subscribe(x => console.log(x));
    }
  }
  Delete(){
    if(confirm("Are you Sure"))
    {
      this.vehicleService.Delete(this.vehicle.id)
      .subscribe(x=>{
        this.router.navigate(['/home']);
      })
    }
  }
}
