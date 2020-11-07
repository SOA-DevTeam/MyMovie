import { PeliculasCalificadas } from './../../models/peliculasCalificadas';
import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RecommendationFilterComponent } from './recommendation-filter.component';

describe('RecommendationFilterComponent', () => {
  let component: RecommendationFilterComponent;
  let fixture: ComponentFixture<RecommendationFilterComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommendationFilterComponent ],
      imports : [HttpClientModule],
      providers : []
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendationFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have no input started',() =>
  {
    expect(component.filter()).toBe(undefined)
  })
});
