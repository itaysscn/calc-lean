import {  NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoanComponent } from './loan/loan.component';  // מוודאים שיבוא הרכיב
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    LoanComponent,
    AppComponent,

  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      
  ],
  
  providers: [],
  bootstrap: [AppComponent],
  
    
 
})
export class AppModule { }
