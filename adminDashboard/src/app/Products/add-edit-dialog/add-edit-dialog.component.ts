import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-edit-dialog',
  templateUrl: './add-edit-dialog.component.html',
  styleUrls: ['./add-edit-dialog.component.css'],
})
export class AddEditDialogComponent implements OnInit {
  productForm!: FormGroup;
  actionButton:string ="Save"
  products: any;
  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public editData : any,
    private dialogRef: MatDialogRef<AddEditDialogComponent>
  ) {}

  ngOnInit(): void {
    this.productForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      price: ['', Validators.required],
      discription: ['', Validators.required],
      type: ['', Validators.required],
      categoryId: ['', Validators.required],
    });
    if(this.editData){
      this.actionButton="Update";
      this.productForm.controls['id'].setValue(this.editData.id);
      this.productForm.controls['name'].setValue(this.editData.name);
      this.productForm.controls['price']!.setValue(this.editData.price);
      this.productForm.controls['discription']!.setValue(this.editData.discription);
      this.productForm.controls['type']!.setValue(this.editData.type);
      this.productForm.controls['categoryId'].setValue(this.editData.categoryId);
    }
  }
  AddProduct() {
    if(!this.editData){
      // if (this.productForm.valid) {
        this.productService.addProduct(this.productForm.value).subscribe({
          next: (res) => {
           console.log('product added successfully');
            this.productForm.reset();
            this.dialogRef.close('Save');
          },
          error: () => {
            console.log('error while adding product');
          },
        })
      // }yy
    }
    else{
      this.updateProduct();
    }
    // console.log(this.productForm.value);
  }
  updateProduct() {
    console.log(this.productForm.value)
    this.productService.editProduct(this.productForm.value).subscribe({
      next: (res) => {
        console.log(res)
        this.getallProduct();
        this.productForm.reset();
        this.dialogRef.close('Update');
      },
      error: () => {
        console.log('error while updating product');
      },

  })
  // console.log(this.productForm.value);
  // this.productForm.reset();
  this.router.navigate(['']);

}
getallProduct() {
  this.productService.getAllProducts().subscribe((data) => {
    this.products = data;
    console.log(this.products)
    // this.filteredData = this.products;
  });
}


}
