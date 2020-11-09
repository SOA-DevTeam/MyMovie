import { HttpClientModule } from '@angular/common/http';
import { NO_ERRORS_SCHEMA } from '@angular/compiler';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { RouterTestingModule } from "@angular/router/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";

import { UpdateProfileComponent } from './update-profile.component';

describe('UpdateProfileComponent', () => {
  let component: UpdateProfileComponent;
  let fixture: ComponentFixture<UpdateProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateProfileComponent],
      imports: [HttpClientModule, RouterModule,
        FormsModule,
        ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule],
      schemas: [NO_ERRORS_SCHEMA],
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
    fixture = TestBed.createComponent(UpdateProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('genres should be empty', () => {
    expect(component.genres$).toEqual(undefined);
  })

  it('initially post status should be 0', () => {
    expect(component.putStatus).toEqual(0);
  })

  it('should not have null data when loaded', () => {
    expect(component.movie).not.toBe(undefined);
  });

  it('should not have null styles data when loaded', () => {
    expect(component.styles$).not.toBe(undefined);
  });

  it('should have null genres data when loaded', () => {
    expect(component.genres$).toBe(undefined);
  });

  it('should not have null languages data when loaded', () => {
    expect(component.langs$).not.toBe(undefined);
  });

  it('should have null image data when loaded', () => {
    expect(component.imageSelected).toBe(undefined);
  });

  it('should set status to 404', () => {
    component.putFailed()
    expect(component.putStatus).toEqual(404);
  })

  it('should set status to 200', () => {
    component.putSuccess()
    expect(component.putStatus).toEqual(200);
  })


});
