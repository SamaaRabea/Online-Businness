import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  products: any;
  constructor(public http: HttpClient) {}
  getAllProducts() {
    return this.http.get('https://localhost:7245/api/Product');
  }
  addProduct(product:any){
    return this.http.post('https://localhost:7245/api/Product',product);
  }
  editProduct(product:any){
    return this.http.put('https://localhost:7245/api/Product',product);
  }
  deleteProduct(id:any){
    return this.http.delete('https://localhost:7245/api/Product/'+id);
  }
}
