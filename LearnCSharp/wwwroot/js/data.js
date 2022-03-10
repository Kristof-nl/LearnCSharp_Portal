var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $(this.#table).DataTable({
        "ajax": {
            "url": "/Admin/Tutorial/GetAll"
        },
        "columns": [
            { "data": "Title", "width": "15%" },
            { "data": "Author", "width": "15%" },
        ]
    });
}
