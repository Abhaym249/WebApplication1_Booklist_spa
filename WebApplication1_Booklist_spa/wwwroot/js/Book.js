var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": '/api/book',
            "type": 'GET',
            "datatype": 'json'
        },
        "columns": [
            { "data": 'title', width: '15%' },
            { "data": 'author', width: '15%' },
            { "data": 'description', width: '20%' },
            { "data": 'isbn', width: '20%' },
            { "data": 'price', width: '15%' },
            {
                "data": 'id',
                "render": function (data) {
                    return `<div class="text-center">
                             <a href="/BookList/Upsert?id=${data}" class="btn btn-info">
                               <i class="fas fa-edit"></i>
                             </a>
                             <a class="btn btn-danger" onclick="Delete('/api/book?id=${data}')">
                               <i class="fas fa-trash-alt"></i>
                             </a>
                            </div>`;
                },
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Want to Delete Data ?",
        icon: "warning",
        text: "Data will be deleted permanently",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}