import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/compiler';
import { TestBed } from '@angular/core/testing';
import { HttpService } from './http.service';

describe('HttpService', () => {
  let service: HttpService;
  let c: HttpClient;

  beforeEach(() => {
    service = new HttpService(c);
    TestBed.configureTestingModule({
      imports : [HttpClientModule],
      schemas : [NO_ERRORS_SCHEMA],
      providers : []
    }).compileComponents();
    service = TestBed.inject(HttpService);
  });

});
