import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { IBookInterface } from '../books/Book.interface';
import { IBookAssignInterface } from './BookAssign.interface';
import { IUserInterface } from './IUser.interface';

@Component({
  selector: 'app-assignbook',
  templateUrl: './assignbook.component.html',
  styleUrls: ['./assignbook.component.css']
})
export class AssignbookComponent implements OnInit {

  book : IBookInterface;
  users : IUserInterface[];
  assignBook : IBookAssignInterface;
  bookID : number;
  userID : number;
  ifAssigned : boolean = false;

  constructor(private apiService: ApiService,  private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.GetBookInfo();
    this.GetUserInfo();
  }
  GetUserInfo() {
    this.apiService.getusers().subscribe((data: any[])=>{  
      console.log(data);  
      this.users = data;  
    })  
  }

  GetBookInfo() {
    let id = +this.route.snapshot.params['id'];
        if (id) {
           this.apiService.getbookbyid(id).subscribe((data: any)=>{  
            console.log(data);  
            this.book = data;  
          })  
        }
  }

  Assign()
  {
    this.assignBook = {
      bookID : this.book.id,
      userID : this.userID,
      id : 0
    }
    this.apiService.assignBook(this.assignBook).subscribe((data: any)=>{  
      console.log(data);  
      alert(data.message);
    })
    this.checkassigned();
    this.router.navigate(['/book']);
  }

  ReturnBook()
  {
    this.assignBook = {
      bookID : this.book.id,
      userID : this.userID,
      id : 0
    };
    this.apiService.returnBook(this.assignBook).subscribe((data: any)=>{  
      console.log(data);  
      alert(data.message);
    })  
    this.checkassigned();
    this.router.navigate(['/book']);

  }

    parseValueUser(value: string) {
      console.log(value);
      this.userID = parseInt(value);
      this.checkassigned()
    }

    checkassigned()
    {
        this.assignBook = {
          bookID : this.book.id,
          userID : this.userID,
          id : 0
        };
        console.log(this.assignBook);
        this.apiService.checkassigned(this.assignBook).subscribe((data: any)=>{  
          console.log(data);  
          this.ifAssigned = data;
        })  
    }
}
