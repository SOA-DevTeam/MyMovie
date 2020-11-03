import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
name: string;
message: string;
  
  constructor() { }

  ngOnInit(): void {
  }

  searchMovie(){
    const name = this.name;
    if(name == null){
      this.message="Debes introducir un nombre o parte del nombre";
    }else{
      this.message="Buscando"+name;
    }
    
  }

}
