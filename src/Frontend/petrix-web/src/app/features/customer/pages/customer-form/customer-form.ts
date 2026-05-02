import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-form',
  imports: [],
  templateUrl: './customer-form.html',
  styleUrl: './customer-form.css',
})
export class CustomerFormComponent implements OnInit {
  isEdit = false; 

  constructor(private router: Router){}
  ngOnInit(): void {
    if (!this.router.url.includes('new')){
      this.isEdit = true;
    }
  }




}
