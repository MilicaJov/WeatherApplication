import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityDataComponent } from './city-data/city-data.component';
import { WeatherDataComponent } from './weather-data/weather-data.component';

const routes: Routes = [
  { path: '', component: WeatherDataComponent },
  { path: "cityData/:city", component: CityDataComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
