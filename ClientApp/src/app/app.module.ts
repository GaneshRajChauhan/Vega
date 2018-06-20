import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {ToastyModule} from '../../node_modules/ng2-toasty';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CounterComponent } from './counter/counter.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehicleService } from './services/vehicle.service';
import { AppErrorHandler } from './app.error-handler';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VehicleFormComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        HttpClientModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            {path:'vehicle/new',component:VehicleFormComponent},
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[
        {provide:ErrorHandler,useClass:AppErrorHandler},
        VehicleService,
    ],
      bootstrap: [AppComponent]
})
export class AppModule { }
