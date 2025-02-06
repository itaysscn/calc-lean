import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanRequest, LoanResponse } from '../models/loan';

@Injectable()
export class LoanService {
  private apiUrl = 'http://localhost:5092/api/loan/calculate'; 
  constructor(private http: HttpClient) {}

  calculateLoan(request: LoanRequest): Observable<LoanResponse> {
    return this.http.post<LoanResponse>(this.apiUrl, request);
  }
}
