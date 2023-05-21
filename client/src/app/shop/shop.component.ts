import { Component } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { Type } from '../shared/models/type';
import { Brand } from '../shared/models/brand';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
  public products: Product[] = [];
  public brands: Brand[] = [];
  public types: Type[] = [];
  
  public brandIdSelected = 0;
  public typeIdSelected = 0;

  constructor(private shopService: ShopService) {
    this.getProducts();
    this.getBrands();
    this.getTypes();
   }

   private getProducts(): void {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected).subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error)
    });
   }

   private getBrands(): void {
    this.shopService.getBrands().subscribe({
      next: response => this.brands = [{ id: 0, name: 'All' }, ...response],
      error: error => console.log(error)
    });
   }

   private getTypes(): void {
    this.shopService.getTypes().subscribe({
      next: response => this.types = [{ id: 0, name: 'All' }, ...response],
      error: error => console.log(error)
    });
   }

   public onBrandSelected(brandId: number): void {
    this.brandIdSelected = brandId;
    this.getProducts();
   }

   public onTypeSelected(typeId: number): void {
    this.typeIdSelected = typeId;
    this.getProducts();
   }
}
