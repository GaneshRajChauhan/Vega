import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  features: any;
  makes: any;
  models: any;
  vehicle: any = {
    features: [],
    contact: {}
  };
  constructor(private vehicleService: VehicleService,
    private toastyService:ToastyService
  
  ) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes =>
      this.makes = makes);

    this.vehicleService.getFeatures().subscribe(features => this.features = features);

  }
  onMakeChange() {

    var selectedmakes = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedmakes ? selectedmakes.models : [];

    delete this.vehicle.modelId;
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
    this.vehicleService.createVehicle(this.vehicle)
      .subscribe(x => console.log(x));
 
}

}
