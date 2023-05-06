import { Component, Inject } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css'],
})
export class DeleteDialogComponent {
  constructor(
    private productService: ProductService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  deleteProduct() {
    this.productService.deleteProduct(this.data).subscribe({
      next: (res) => {
        this.productService.getAllProducts();
      },
    });
  }
}
