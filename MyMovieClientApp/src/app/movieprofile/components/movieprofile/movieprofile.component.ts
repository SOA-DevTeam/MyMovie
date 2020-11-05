import { Component, OnInit } from '@angular/core';
import { Router  , ActivatedRoute } from '@angular/router'
import { HttpService } from '../../../http.service';

@Component({
  selector: 'app-movieprofile',
  templateUrl: './movieprofile.component.html',
  styleUrls: ['./movieprofile.component.css']
})
export class MovieprofileComponent implements OnInit {
  // Object to store http data
  movies: Object;
  fav = false;

  constructor(public httpService: HttpService, private route:ActivatedRoute) { 
    this.httpService.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movies = data;
      console.log(this.movies.toString());
      });
  }

  ngOnInit(): void {
  }

  isUndefined(val): boolean{
    return typeof val === 'undefined';
  }

}
