import { Component, inject, OnInit } from '@angular/core';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  // http = inject(HttpClient);
  private accountService = inject(AccountService);
  //users: any;

  ngOnInit(): void {
   // this.getUsers();
    this.setCurrentUser();
    }
   
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString){
      return;
      //this.accountService.currentUser.set(userString);
    }
    const user: any = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }
  // getUsers(){
  //   this.http.get('https://localhost:5001/api/users').subscribe({
  //     next: (response) => {
  //       this.users = response;
  //     },
  //     error: (err) => {
  //       console.error(err);
  //     },
  //     complete: () => {
  //       console.log('Request completed');
  //     }
  //   })
  //}
}
