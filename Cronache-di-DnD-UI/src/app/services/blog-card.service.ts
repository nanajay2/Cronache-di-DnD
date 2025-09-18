import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface BlogCard {
  title: string;
  text: string;
  date: string;
}

@Injectable({
  providedIn: 'root'
})
export class BlogCardService {
  private apiUrl = 'http://localhost:5209/api/SessionSummaries'; 

  constructor(private http: HttpClient) {}

  getCards(): Observable<BlogCard[]> {
    return this.http.get<BlogCard[]>(this.apiUrl);
  }

  addCard(card: BlogCard): Observable<BlogCard> {
    return this.http.post<BlogCard>(this.apiUrl, card);
  }
}