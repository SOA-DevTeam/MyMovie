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
  // tslint:disable-next-line: ban-types
  movies: Object;
  loading = false;
  // tslint:disable-next-line: ban-types
  comments: Object;
  score: number;
  comment: string;

  constructor(public httpService: HttpService, private route: ActivatedRoute) {

    this.httpService.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movies = data;
      });

    this.httpService.getComments(this.route.snapshot.params['id']).subscribe(d => {
        this.loading = true;
        this.comments = d;
        this.loading = false;
      });
  }

  ngOnInit(): void {
  }



}
