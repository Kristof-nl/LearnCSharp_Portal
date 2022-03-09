var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable();
        "ajax": {
            "url":"/Admin/Product/GetAll"
    },
    "columns": [
        { "data": "Title", "width": "15%" },
        { "data": "Author", "width": "15%" },
        { "data": "Category", "width": "15%" },
        { "data": "Subcategory", "width": "15%" },
        { "data": "Source", "width": "15%" }
        ]
    });

}