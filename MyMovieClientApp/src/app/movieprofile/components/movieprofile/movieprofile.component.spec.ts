import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { RouterTestingModule } from "@angular/router/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";

import { MovieprofileComponent } from './movieprofile.component';

describe('MovieprofileComponent', () => {
  let component: MovieprofileComponent;
  let fixture: ComponentFixture<MovieprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MovieprofileComponent],
      imports: [HttpClientModule, RouterTestingModule, HttpClientTestingModule],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: { snapshot: { params: { 'id': 1 } } }
        },
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have null data at the beggining', () => {
    expect(component.movies).toBe(undefined);
  });

  it('should count -1 if the movie request was failed', () => {
    expect(component.msize).toBe(-1);
  });

  it('should count -1 if the comments request was failed', () => {
    expect(component.csize).toBe(-1);
  });

});
