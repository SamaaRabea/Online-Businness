import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();
  currentRoute:any;
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) { //NavigationEnd event to get the current URL
        const url = event.urlAfterRedirects;
        this.currentRoute = url.split('/')[1];
        // console.log(this.currentRoute); // Output: "Products"
        if(this.currentRoute=="")
        {
          this.currentRoute ="Products"
        }
      }
    });
    
  }

  toggleSidebar() {
    this.toggleSidebarForMe.emit();
  }
}
