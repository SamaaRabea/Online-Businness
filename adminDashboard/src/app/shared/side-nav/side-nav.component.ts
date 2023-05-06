import { Component, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { NavigationEnd, Router } from '@angular/router';


@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit{
  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  constructor(private observer: BreakpointObserver) {}
  ngOnInit(): void {
  }

  // ngAfterViewInit() {
  //   this.observer
  //     .observe(['(max-width: 800px)'])
  //     .subscribe((res) => {
  //       if (res.matches) {
  //         setTimeout(() => {
  //         this.sidenav.mode = 'over';
  //         this.sidenav.open();
  //         })
  //       } else {
  //         setTimeout(() => {
  //         this.sidenav.mode = 'side';
  //         this.sidenav.open();
  //         })
  //       }
  //     });

  // }
}
