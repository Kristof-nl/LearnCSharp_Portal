var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#table').DataTable({
        "ajax": {
            "url": "/Admin/Tutorial/GetAll"
        },
        "bDestroy": true,
        "lengthMenu": [7, 15, 25, 50, 100],

        "columns": [
            { "data": "title", "width": "23%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "11%" },
            { "data": "subcategory.name", "width": "15%" },
            { "data": "source.name", "width": "11%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-100 btn-group" role="group">
                        <a href="/Admin/Tutorial/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>  Edit  </a>
                        <a onClick=Delete('/Admin/Tutorial/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "15%"
            }

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

