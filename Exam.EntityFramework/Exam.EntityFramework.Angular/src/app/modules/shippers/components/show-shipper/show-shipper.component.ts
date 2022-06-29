import { Component, OnInit } from '@angular/core';
import { Shipper } from '../../models/shipper';
import { ShippersService } from '../../services/shippers.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-show-shipper',
  templateUrl: './show-shipper.component.html',
  styleUrls: ['./show-shipper.component.scss']
})
export class ShowShipperComponent implements OnInit {

  public listShippers: Array<Shipper> = [];

  constructor(private shippersService: ShippersService) { }

  ngOnInit(): void {
    this.getShippers();
  }

  getShippers() {
    Swal.fire({
        title: 'Por favor espere',
        showConfirmButton: false,
    });
    Swal.showLoading();
    this.shippersService.getShippers().subscribe({
      next: res => {
        Swal.close();
        this.listShippers = res;
      },
      error: err => {
        Swal.close();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'No es posible obtener la lista de Transportes en este momento. Por favor vuelva a intentar más tarde.'
        });
      }
    });
  }

  // Variable (properties)
  modalTitle: string = '';
  activateAddEditShipperComponent: boolean = false;
  shipper!: Shipper;

  modalAdd() {
    this.shipper = {
      Id: 0,
      Name: ""
    },
    this.modalTitle = "Agregar Transporte";
    this.activateAddEditShipperComponent = true;
  }

  modalEdit(shipper: Shipper) {
    this.shipper = { ...shipper };
    this.modalTitle = "Editar Transporte";
    this.activateAddEditShipperComponent = true;
  }

  modalClose() {
    this.activateAddEditShipperComponent = false;
  }

  delete(shipper: Shipper) {
    Swal.fire({
      title: 'Confirmar',
      html: `¿Estás segura de que quieres eliminar el Transporte: <b>${ shipper.Name }</b>?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: '¡Si, eliminar!',
      cancelButtonText: 'No'
    }).then((result:any) => {
      if (result.value) {
        Swal.fire({
            title: 'Por favor espere',
            showConfirmButton: false,
        });
        Swal.showLoading();
        this.shippersService.deleteShipper(shipper.Id).subscribe({
          next: res => {
            this.getShippers();
            Swal.close();
            const closeModalBtn = document.getElementById('add-edit-modal-close');
            if (closeModalBtn) {
              closeModalBtn.click();
            }
            const showDeleteSuccess = document.getElementById('delete-success-alert');
            if (showDeleteSuccess) {
              showDeleteSuccess.style.display = "block";
            }
            setTimeout(function() {
              if (showDeleteSuccess) {
                showDeleteSuccess.style.display = "none";
              }
            }, 4000);
          },
          error: err => {
            Swal.close();
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'No es posible eliminar el Transporte en este momento. Por favor vuelva a intentar más tarde.'
            });
          }
        });
      }
    });
  }

  feedbackAddEdit(data: boolean) {
    if (data) {
      this.getShippers();
    }
  }
}
