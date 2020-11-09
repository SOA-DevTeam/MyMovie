import { NO_ERRORS_SCHEMA } from '@angular/compiler';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMovieComponent } from './add-movie.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

describe('AddMovieComponent', () => {
  let component: AddMovieComponent;
  let fixture: ComponentFixture<AddMovieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddMovieComponent],
      imports: [HttpClientModule, RouterModule,
        FormsModule,
        ReactiveFormsModule,],
      schemas: [NO_ERRORS_SCHEMA]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });



  it('image should be the placeholder', () => {
    expect(component.imageSelected).toBe("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAssAAAHfCAMAAACReWX5AAAA51BMVEVpXM3TwL6wn8Pl0byHeMmbi8a5qMKHfdH/6rillcXBsMF7bct9b8pqXc365bn+6bjRv75xZMxvYszt2brItsCSg8fSwL6gkMV/ccp7bcrLuL+qmcTZxr13acvn1Lt1aMuGeMn24rmDdcnFs8D04LmUhcejk8Xj0LyzosOhkcXjz7ziz7xxY8yyocOxoMOBcsqunsPArsGuncOPgMjRvr9+b8rv2rqNf8iejsaMfcj757iKe8jLub9rXs3cyb3Jt7+qmsR5bMt5a8upmMT65rmIesl2aMt0Z8uGd8m1pMKXh8f14bmWhsfTbQknAAADrElEQVR42uzc106VURSF0a1IXBaKYG+AXWPvxth7ef/nkXNU5AKM5cjPno7xDF+yd+bFagAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACMHTpdQ5g9eKDBJN2brYEcbDBJJ2oosw0maWcNpoGWYbOWd28xLaNl0DLptEwKLZNCy6TQMim0TAotk0LLpNAyKbRMCi2TQsuk0DIptEwKLZNCy6TQMim0TAotk0LL9OjtrpHlA1qmbwt366vXr7RM167Xd3M3tEzPDteay1qmZztqzWMt07MfLd/yX6Zr45YXp6en39sx6Nu45Sn7Mv3TMim0TAotk0LLpNAyKbRMCi2TQsuk0DIptEwKLZNCy6TQMim0TAotk0LLpNAyKbRMCi2TQst06NSRPd88fKdlOvZopdace6Nl+jVV65zUMv2aq3Xua5l+1XrHtUy/ap2nS1qmXzXybP/IC5scPauRvfZl+qdlUmiZFFomhZZJoWVSaJkUWiaFlkmhZVJomRRaJoWWSaFlUmiZFFomxe+1PAQto2X+L1W/3vLNGspcg0m2/LmGMtVgki3PHK9hrNxpMLGWxx7sGcKRUw3+uGUPO73RMim0TAotk0LLpNAyKbRMiu3U8szy0ZkG/be8dKXq5NUG3bd8tlZ9aNB9yxdr1Y4G3bc8pWW0DFomh5ZJoWVSaJkUWiaFlkmhZVJomRQ/aXlxemstapl/0fIQtIyWYbOWD9cGtMy2VrVRy5dqKNcaTLLlhfkaxvxCg4m1PHZs1xCONfjLlqF7WiaFlkmhZVJomRRaJoWWSTFMy2eef3Q5joSWL8xVzYuZ/lt+8qlWnW/Qe8sva+R2g95b3lcjOxtoGbRMLi2TQsuk0DIptEwKLX9pl45NAISBAAB+JY9FQFAQBBdwA3H/ucQB7KKBcDfD0QuX6YXL9CIfx/Cr0WU+kC24jMvwqmQrW0BNVzZyrgE1TXPJFvYlAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIiIuAHhdnvCvNaURQAAAABJRU5ErkJggg==");
  })

  it('genres should be empty', () => {
    expect(component.genres$).toEqual(undefined);
  })

  it('initially post status should be 0', () => {
    expect(component.postStatus).toEqual(0);
  })

  it('popularity should be 0 at start', () => {
    expect(component.popularity).toEqual(0);
  })

  it('should set status to 404', () => {
    component.postFailed()
    expect(component.postStatus).toEqual(404);
  })

  it('should set status to 200', () => {
    component.postSuccess()
    expect(component.postStatus).toEqual(200);
  })



});
