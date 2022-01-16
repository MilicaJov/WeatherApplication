import { Component, OnInit, ViewChild } from '@angular/core';
import { CityData } from '../models/city.model';
import { ActivatedRoute } from '@angular/router';
import { ConfigService } from '../services/config.service';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-city-data',
  templateUrl: './city-data.component.html',
  styleUrls: ['./city-data.component.css']
})
export class CityDataComponent implements OnInit {

  citiesData: CityData[] = new Array<CityData>();
  cityName!: string;
  displayedColumns: string[] = ['date', 'max', 'min'];
  dataSource: any;

  constructor(private route: ActivatedRoute, private service: ConfigService) { 
    this.route.params.subscribe(params => {
      this.cityName = params['city'];
    })
  }

  @ViewChild(MatSort)
  sort!: MatSort;

  ngOnInit(): void {
    this.getCityData();
  }

  getCityData() {
    this.service.getCityData(this.cityName).subscribe((cities: Array<CityData>) => {
        this.citiesData = cities;
        this.dataSource = new MatTableDataSource(this.citiesData);
        this.dataSource.sort = this.sort;
    });
  }

  filterByDate(event: Event) {
    const target = event.target as HTMLInputElement;
    var date: Date | null = target.valueAsDate;
    console.log(date);
    if(date) {
      console.log(this.citiesData);
      this.citiesData = this.citiesData.filter(c => new Date(c.date).getDate() === date?.getDate());
      console.log(this.citiesData);
      this.dataSource = new MatTableDataSource(this.citiesData);
    }
  }

  clearFilter() {
    this.getCityData();
  }

}
