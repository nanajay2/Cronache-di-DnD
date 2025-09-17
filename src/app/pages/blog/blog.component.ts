import { Component, OnInit } from '@angular/core';
import { BlogCard, BlogCardService } from '../../services/blog-card.service';

@Component({
  selector: 'app-blog',
  standalone: false,
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.css'
})
export class BlogComponent implements OnInit {
  cards: BlogCard[] = [];
  newCard: BlogCard = { title: '', text: '', date: new Date().toISOString() };

  constructor(private blogCardService: BlogCardService) {}

  ngOnInit() {
    this.loadCards();
  }

  loadCards() {
    this.blogCardService.getCards().subscribe(cards => this.cards = cards);
  }

  addCard() {
    this.blogCardService.addCard(this.newCard).subscribe(card => {
      this.cards.push(card);
      this.newCard = { title: '', text: '', date: new Date().toISOString() };
    });
  }
}