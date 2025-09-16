import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BlogComponent } from './pages/blog/blog.component';
import { CharactersComponent } from './pages/characters/characters.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { MainComponent } from './main/main.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BlogComponent,
    CharactersComponent,
    CalendarComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    RouterModule.forRoot([
      { path: 'blog', component: BlogComponent },
      { path: 'characters', component: CharactersComponent },
      { path: 'calendar', component: CalendarComponent }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }