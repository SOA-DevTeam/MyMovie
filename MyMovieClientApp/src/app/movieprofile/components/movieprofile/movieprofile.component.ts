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
  loading = true;
  // tslint:disable-next-line: ban-types
  comments: Object;
  score= 0;
  comment: string;
  msize=-1;
  csize=-1;
  pop = 0;

  constructor(public httpService: HttpService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.httpService.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movies = data;
      this.msize = this.Size(this.movies);
      });

      this.getComments();

    
  }

  getComments(){
    this.httpService.getComments(this.route.snapshot.params['id']).subscribe(d => {
      this.loading = true;
      this.comments = d;
      this.csize = this.Size(this.comments);
      this.loading = false;
    });
  }

  async postComment(){
    var request = this.httpService.postComment({
      idPelicula: this.route.snapshot.params['id'],
      calificacion: this.score,
      Comentario: this.comment
  });
  if (await request == "0") {
    console.log("fail");
  }
  else {
    this.putPop();
  }
  this.getComments();
  }

  popUpdate(){
    if(this.csize==0){
      return 15;
    }else if(this.csize==5){
      return 10
    }else if(this.csize==10){
      return 15;
    }else if (this.csize==10){
      return 20;
    }else{
      return 0;
    }
  }

  async putPop(){
    var request = this.httpService.putPopularity({
      idPelicula: this.route.snapshot.params['id'],
      indicePopularidad: this.popUpdate
  })
}



  Size(obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
}

refresh(): void {
  window.location.reload();
}




}
