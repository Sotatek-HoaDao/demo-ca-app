import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-logout-button',
  templateUrl: './logout-button.component.html',
  styleUrls: ['./logout-button.component.scss']
})
export class LogoutButtonComponent implements OnInit {

  constructor(public auth:AuthService, @Inject(DOCUMENT) private doc: Document) { }

  ngOnInit(): void {
  }
  logout(): void {
    this.auth.logout({ returnTo: this.doc.location.origin });
  }

}
