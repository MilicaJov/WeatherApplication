import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { CityData } from '../models/city.model';

@Injectable()
export class ConfigService {

  uri='http://localhost:14131';

  constructor(private http: HttpClient) { }

  getAllData() {
    return this.http.get<Array<CityData>>(`${this.uri}/api/WeatherData/data`);
  }

  getDataOnADate(date: string) {
    return this.http.get<Array<CityData>>(`${this.uri}/api/WeatherData/data/${date}`);
  }

  getCityData(city: string) {
    return this.http.get<Array<CityData>>(`${this.uri}/api/WeatherData/city/${city}`);
  }  
}