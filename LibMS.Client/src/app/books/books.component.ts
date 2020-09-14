import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books = [];
	constructor(private apiService: ApiService, private router: Router) { }
	ngOnInit() {
		this.apiService.getbooks().subscribe((data: any[])=>{  
			console.log(data);  
			this.books = data;  
		})  
  }
  
  AssignBook(id : number) {
    console.log(id);
    this.router.navigate(['/assignbook/'+id]);
  }

}
