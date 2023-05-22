import { Component } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { Type } from '../shared/models/type';
import { Brand } from '../shared/models/brand';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent {
  public products: Product[] = [];
  public brands: Brand[] = [];
  public types: Type[] = [];
  
  shopParams = new ShopParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name'},
    { name: 'Price: Low to high', value: 'priceAsc'},
    { name: 'Price: High to low', value: 'priceDesc'}
  ];

  public totalCount = 0;

  constructor(private shopService: ShopService) { }

   ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
   }

   private getProducts(): void {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data,
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
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
    this.shopParams.brandId = brandId;
    this.getProducts();
   }

   public onTypeSelected(typeId: number): void {
    this.shopParams.typeId = typeId;
    this.getProducts();
   }

   public onSortSelected(event: any): void {
    this.shopParams.sort = event.target.value;
    this.getProducts();
   }

   public onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event.page) {
      this.shopParams.pageNumber = event.page;
      this.getProducts();
    }
   }
}
