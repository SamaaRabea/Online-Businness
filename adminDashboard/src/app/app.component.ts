import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatDrawer, MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'adminDashboard';
  sideBarOpen = true;
  @ViewChild(MatDrawer)
  drawer!: MatDrawer;
  constructor(private observer: BreakpointObserver) {}

  sideBarToggler() {
    this.sideBarOpen = !this.sideBarOpen;
  }
  ngAfterViewInit() {
    this.observer
      .observe(['(max-width: 800px)'])
      .subscribe((res) => {
        if (res.matches) {
          this.sideBarOpen = !this.sideBarOpen;
          this.drawer.mode = 'over';
        } else {
          this.sideBarOpen = this.sideBarOpen;
          this.drawer.mode = 'side';
        }
      });
    }
}
