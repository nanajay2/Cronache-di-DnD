import { RouterModule, Routes } from '@angular/router';
import { BlogComponent } from './pages/blog/blog.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { CharactersComponent } from './pages/characters/characters.component';
import { NgModule } from '@angular/core';
import { BlogCardService } from './services/blog-card.service';

export const routes: Routes = [
    {path: 'blog', component: BlogComponent},
    {path: 'calendar', component: CalendarComponent},
    {path: 'characters', component: CharactersComponent},
    { path: 'blogCardService', component: BlogCardService}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
