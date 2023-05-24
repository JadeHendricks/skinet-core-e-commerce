import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/enviroments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  public get404Error(): void {
    this.http.get(this.baseUrl + 'products/42').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  public get500Error(): void {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  public get400Error(): void {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  public get400ValidationError(): void {
    this.http.get(this.baseUrl + 'products/fortytwo').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
}
