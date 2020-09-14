import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AssignbookComponent } from './assignbook/assignbook.component';
import {BooksComponent } from './books/books.component';

const routes: Routes = [
  { path: '', redirectTo: 'book', pathMatch: 'full'},
  { path: 'book', component: BooksComponent },
  { path: 'assignbook', component: AssignbookComponent },
  { path: 'assignbook/:id', component: AssignbookComponent },

  { path: 'about', component: AboutComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
