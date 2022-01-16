import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { CityData } from '../models/city.model';
import { ConfigService } from '../services/config.service';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-weather-data',
  templateUrl: './weather-data.component.html',
  styleUrls: ['./weather-data.component.css']
})
export class WeatherDataComponent implements OnInit {

  citiesData: CityData[] = new Array<CityData>();
  displayedColumns: string[] = ['city', 'date', 'max', 'min'];
  dataSource: any;
  
  constructor(private service: ConfigService) {}

  @ViewChild(MatSort)
  sort!: MatSort;

  ngOnInit(): void {
    this.getAllData();
  }

  getAllData() {
    this.service.getAllData().subscribe((cities: Array<CityData>) => {
      this.citiesData = cities;
      this.dataSource = new MatTableDataSource(this.citiesData);
      this.dataSource.sort = this.sort;
    });
  }

  filterData(event: Event) {
    const target = event.target as HTMLTextAreaElement;
    this.dataSource.filter = target.value.trim().toLocaleLowerCase(); 
  }

  filterByDate(event: Event) {
    const target = event.target as HTMLInputElement;
    var date: Date | null = target.valueAsDate;
    console.log(date);
    if(date) {
      let dateString = formatDate(date, 'yyyy-MM-dd', "en_US");
      this.service.getDataOnADate(dateString).subscribe((cities: Array<CityData>) => {
        this.citiesData = cities;
        this.dataSource = new MatTableDataSource(this.citiesData);
        this.dataSource.sort = this.sort;
      });
    }
  }

  clearFilter() {
    this.getAllData();
  }

}
