import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchComponent } from './search.component';

describe('SearchComponent', () => {
  let component: SearchComponent;
  let fixture: ComponentFixture<SearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchComponent ],
     imports:[HttpClientModule],
      providers: [] 
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have button disabled when no input', () => {
    component.searchMovie();
    expect(component.message).toBe('Debes introducir un nombre o parte del nombre');
  });

  it('should have error message when not given enough characters to search', () => {
    component.name = 'aa';
    component.searchMovie();
    expect(component.message).toBe('Asegurate de ingresar al menos 4 caracteres');
  });

  
});
