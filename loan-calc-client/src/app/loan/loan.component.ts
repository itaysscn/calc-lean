import { Component, OnInit } from '@angular/core';
import { LoanRequest, LoanResponse } from '../models/loan';
import { LoanService } from '../services/loan.services';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css'],
  providers:[LoanService]

 // standalone: true,
  //imports:[ FormsModule,CommonModule]
})
export class LoanComponent implements OnInit {
  loanRequest: LoanRequest = { clientId: 0, amount: 0, periodMonths: 12 };
  loanResponse?: LoanResponse;

  constructor(private loanService: LoanService) {}

  onSubmit() {
    this.loanService.calculateLoan(this.loanRequest).subscribe(
      response => this.loanResponse = response,
      error => alert('שגיאה בחישוב ההלוואה')
    );
  }
  ngOnInit(): void {
    console.log("i amhere")
  }
}
