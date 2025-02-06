export interface LoanRequest {
    clientId: number;
    amount: number;
    periodMonths: number;
  }
  
  export interface LoanResponse {
    totalAmount: number;
    interestAmount: number;
    message: string;
  }
  