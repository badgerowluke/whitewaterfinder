import { Component, OnChanges, OnInit } from '@angular/core';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root-paddle',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: []
})
export class AppComponent implements OnInit {
  title = 'paddle-finder';
  profile: any;
  constructor(public auth: AuthService) {

  }
  ngOnInit() { }


  openNav() {
    document.getElementById("side-nav").style.width = "250px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";    
  }
  closeNav() {
    document.getElementById("side-nav").style.width = "0";
    document.body.style.backgroundColor = "white";    
  }
  
}
