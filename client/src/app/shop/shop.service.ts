import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  public getProducts() {
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products?pageSize=50');
  }
}
