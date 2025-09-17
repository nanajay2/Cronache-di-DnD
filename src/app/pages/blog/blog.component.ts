import { Component, OnInit } from '@angular/core';
import { BlogCard, BlogService } from '../../services/blogService/blog.service';

@Component({
  selector: 'app-blog',
  standalone: false,
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.css'
})
export class BlogComponent implements OnInit {
  cards: BlogCard[] = [];
  newCard: BlogCard = { title: '', text: '', date: new Date().toISOString() };

  constructor(private blogService: BlogService) {}

  ngOnInit() {
    this.loadCards();
  }

  loadCards() {
    this.blogService.getCards().subscribe(cards => this.cards = cards);
  }

  addCard() {
    this.blogService.addCard(this.newCard).subscribe(card => {
      this.cards.push(card);
      this.newCard = { title: '', text: '', date: new Date().toISOString() };
    });
  }
}