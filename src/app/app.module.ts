import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BlogComponent } from './pages/blog/blog.component';
import { CharactersComponent } from './pages/characters/characters.component';
import { CalendarComponent } from './pages/calendar/calendar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BlogComponent,
    CharactersComponent,
    CalendarComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'blog', component: BlogComponent },
      { path: 'characters', component: CharactersComponent },
      { path: 'calendar', component: CalendarComponent }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }