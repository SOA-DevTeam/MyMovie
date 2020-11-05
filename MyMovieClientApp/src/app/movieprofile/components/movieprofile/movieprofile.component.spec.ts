import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieprofileComponent } from './movieprofile.component';

describe('MovieprofileComponent', () => {
  let component: MovieprofileComponent;
  let fixture: ComponentFixture<MovieprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieprofileComponent ]
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
});
