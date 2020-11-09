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
      this.getMovie();
      this.getComments();
      this.popUpdate();
  }

  getMovie(){
    this.httpService.getMovie(this.route.snapshot.params['id']).subscribe(data => {
      this.movies = data;
      this.msize = this.Size(this.movies);
      });
  }

  getComments(){
    this.httpService.getComments(this.route.snapshot.params['id']).subscribe(d => {
      this.loading = true;
      this.comments = d;
      this.csize = this.Size(this.comments);
      this.loading = false;
      this.popUpdate();
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
  }else{
    await this.putPop();
    this.getMovie();
    this.getComments();
    this.comment="";
    this.popUpdate();
    }
  }

  popUpdate(){
    if(this.csize==0){
      this.pop = 15;
    }else if(this.csize==5){
      this.pop = 10
    }else if(this.csize==10){
      this.pop = 15;
    }else if (this.csize==10){
      this.pop = 20;
    }else{
      this.pop = 0;
    }
  }

  async putPop(){
    var request = this.httpService.putPopularity({
      idPelicula: this.route.snapshot.params['id'],
      indicePopularidad: this.pop
  })
}
  Size(obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
    
  }

}
