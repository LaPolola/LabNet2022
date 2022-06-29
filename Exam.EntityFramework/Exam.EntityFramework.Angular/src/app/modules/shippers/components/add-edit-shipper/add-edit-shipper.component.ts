import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Shipper } from '../../models/shipper';
import { ShippersService } from '../../services/shippers.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-shipper',
  templateUrl: './add-edit-shipper.component.html',
  styleUrls: ['./add-edit-shipper.component.scss']
})
export class AddEditShipperComponent implements OnInit {

  public formShippers!: FormGroup;

  constructor(private formBuild: FormBuilder, private shippersService: ShippersService) { }

  @Input() shipper!:Shipper;
  @Output() sendOutShowShipper = new EventEmitter<boolean>();

  ngOnInit(): void {
    this.initForm();
  }

  buttonName:string = "Agregar";

  initForm() {
    this.formShippers = this.formBuild.group({
      name: ['', [Validators.required, Validators.maxLength(40)]]
    });
    this.formShippers.get('name')?.setValue(this.shipper.Name);
    if (this.shipper.Id != 0) {
      this.buttonName = "Editar";
    }
  }

  get f() { return this.formShippers.controls; }

  sendShipper() {
    if (this.shipper.Id == 0) {
      this.addShipper();
    } else {
      this.editShipper();
    }
  }

  private addShipper() {
    Swal.fire({
        title: 'Por favor espere',
        showConfirmButton: false,
    });
    Swal.showLoading();
    const shipper = new Shipper();
    shipper.Name = this.formShippers.get('name')?.value;
    this.shippersService.addShipper(shipper).subscribe({
      next: res => {
        this.sendOutShowShipper.emit(true);
        const closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }
        const showAddSuccess = document.getElementById('add-success-alert');
        if (showAddSuccess) {
          showAddSuccess.style.display = "block";
        }
        setTimeout(function() {
          if (showAddSuccess) {
            showAddSuccess.style.display = "none";
          }
        }, 4000);
      },
      error: err => {
        this.sendOutShowShipper.emit(false);
        Swal.close();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'No es posible agregar el Transporte en este momento. Por favor vuelva a intentar más tarde.'
        });
      }
    });
  }

  private editShipper() {
    Swal.close();
    Swal.fire({
        title: 'Por favor espere',
        showConfirmButton: false,
    });
    Swal.showLoading();
    const shipper = {
      Id: this.shipper.Id,
      Name: this.formShippers.get('name')?.value
    }
    this.shippersService.editShipper(shipper).subscribe({
      next: res => {
        this.sendOutShowShipper.emit(true);
        const closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }
        const showUpdateSuccess = document.getElementById('update-success-alert');
        if (showUpdateSuccess) {
          showUpdateSuccess.style.display = "block";
        }
        setTimeout(function() {
          if (showUpdateSuccess) {
            showUpdateSuccess.style.display = "none";
          }
        }, 4000);
      },
      error: err => {
        this.sendOutShowShipper.emit(false);
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'No es posible editar el Transporte en este momento. Por favor vuelva a intentar más tarde.'
        });
      }
    });
  }
}
