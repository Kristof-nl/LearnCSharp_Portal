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
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "author", "width": "15%" }
        ]
    });
}