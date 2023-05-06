import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductService } from '../services/product.service';
import { AddEditDialogComponent } from './add-edit-dialog/add-edit-dialog.component';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-products',
  templateUrl: './Products.component.html',
  styleUrls: ['./Products.component.css']
})
export class ProductsComponent implements OnInit{
  products: any;
  filteredStatus: string = '';
  constructor(public dialog:MatDialog,private productService: ProductService){

  }

  ngOnInit(): void {
    this.getallProduct()
  }
  getallProduct() {
    this.productService.getAllProducts().subscribe((data) => {
      this.products = data;
      console.log(this.products)
      // this.filteredData = this.products;
    });
  }
  openDialog() {
    this.dialog.open(AddEditDialogComponent, {
     width:"40%",
    }).afterClosed().subscribe(val=>{
      if(val==='Save'){
        this.getallProduct()
      }
    });
  }
  editProduct(product:any){
    this.dialog.open(AddEditDialogComponent,{
      width:'30%',
      data:product
    }).afterClosed().subscribe(val=>{
      if(val==='Update'){
        this.getallProduct()
      }
    });
  }
  deleteproduct(id:any){
    this.dialog.open(DeleteDialogComponent,{
      width:'30%',
      data:id,
    }).afterClosed().subscribe(val=>{
        this.getallProduct()
    });
  }
}
