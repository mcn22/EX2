var dataTable;

$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblUsuarios").DataTable({
        "ajax": {
            "url": "/admin/usuario/listar",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "rol", "width": "15%" },
            {
                "data": {
                    "id": "id",
                    "lockoutEnd": "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout;

                    if (data.lockoutEnd != null) {
                        lockout = new Date(data.lockoutEnd).getTime();
                    }

                    if (lockout == undefined || lockout < today) {
                        return `
                            <div class="text-center">
                                <a onclick="LockUnlock('${data.id}')" class="btn btn-sm btn-danger text-white" style='cursor:pointer; width: 150px;'>
                                    <i class="fa fa-lock"></i> Bloquear
                                </a>
                            </div>
                           `;
                    }
                    else {
                        return `
                            <div class="text-center">
                                <a onclick="LockUnlock('${data.id}')" class="btn btn-sm btn-success text-white" style='cursor:pointer; width: 150px;'>
                                    <i class="fa fa-lock-open"></i> Desbloquear
                                </a>
                            </div>
                           `;
                    }

                }
            }
        ],
        "language": {
            "lengthMenu": "Desplegando _MENU_ registros por página",
            "zeroRecords": "Lo sentimos, no se han encontrado registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros disponibles.",
            "infoFiltered": "(filtrado de _MAX_ registros.)",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Filtrar:",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function LockUnlock(id) {
    $.ajax({
        "url": '/admin/usuario/lockunlock',
        "type": "POST",
        "contentType": "application/json",
        "data": JSON.stringify(id),
        "dataType": "json",
        "success": function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });
}