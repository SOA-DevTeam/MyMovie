import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
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
  loading = true;
  // tslint:disable-next-line: ban-types
  comments: Object;
  score: number;
  comment: string;
  msize = -1;
  csize = -1;

  constructor(public httpService: HttpService, private route: ActivatedRoute, private router: Router) {

    this.httpService.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movies = data;
      this.msize = this.Size(this.movies);
    });

    this.httpService.getComments(this.route.snapshot.params['id']).subscribe(d => {
      this.loading = true;
      this.comments = d;
      this.csize = this.Size(this.comments);
      this.loading = false;
    });
  }

  ngOnInit(): void {
  }

  Size(obj) {
    var size = 0, key;
    for (key in obj) {
      if (obj.hasOwnProperty(key)) size++;
    }
    return size;
  }

}
