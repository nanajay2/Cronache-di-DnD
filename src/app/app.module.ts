import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms'; // <- IMPORT NECESSARIO
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BlogComponent } from './pages/blog/blog.component';
import { CharactersComponent } from './pages/characters/characters.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { MainComponent } from './main/main.component';
import { CommonModule } from '@angular/common';
import { BlogCardService } from './services/blog-card.service';

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
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'blog', component: BlogComponent },
      { path: 'characters', component: CharactersComponent },
      { path: 'calendar', component: CalendarComponent },
      { path: 'blogCardService', component: BlogCardService}
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }