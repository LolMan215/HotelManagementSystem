import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient, private accountService: AccountService) {}

  ngOnInit() {
    this.refreshUser();
  }

  private refreshUser(){
    const jwt = this.accountService.getJWT();
    if(jwt){
      this.accountService.refreshUser(jwt).subscribe({
        next: _ => {},
        error: _ => {
          this.accountService.logout();
        }
      })
    } else{
      this.accountService.refreshUser(null).subscribe();
    }
  }
}
