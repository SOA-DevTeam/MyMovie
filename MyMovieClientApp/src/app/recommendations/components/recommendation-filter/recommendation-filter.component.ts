
import { Component, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-recommendation-filter',
  templateUrl: './recommendation-filter.component.html',
  styleUrls: ['./recommendation-filter.component.css'],
})
export class RecommendationFilterComponent implements OnInit {

  constructor(private http: HttpClient) 
  {

  }

    
  imdb : number = 0;
  
  popularity : number = 0;
  
  community : number = 0;
  
  platform : number = 0;
  
  metascore : number = 0;
  
  total : number = 100;

  goodT : number = -1;

  goodF : number = -1;

  ngOnInit(): void {
  }

  calculateTotal(item){
    console.log(this.total);
    this.total = 100 - this.imdb - this.popularity - this.community - this.metascore - this.platform;
    this.validate();
  }

  validate(){
    if(this.total < 0){
      this.goodT = 1;
    }else{
      this.goodT = -1;
    }

    }

  filter(event){
    if(this.goodT = 1){
      this.goodF = 1;
    }
  }

}
