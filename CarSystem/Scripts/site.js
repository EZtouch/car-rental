$('.delete-btn').on('click', deleteRecord);
    
function deleteRecord(event) {
    console.log('I am delete record function');
    $.ajax({
        type : 'DELETE',
        url : 'http://localhost:56346/api/Cars/' + event.target.dataset.id,
        dataType : 'json',
        /*data: {
            id : deleteBtn.dataset.id
        },*/
        contentType: 'application/json',
        success : function(data){
            $(event.target).parent().parent().remove();
            console.log('removed ' + event.target.dataset.id);
        },
        error : function(XMLHttpRequest, textStatus, errorThrown) {
            console.log(XMLHttpRequest);
        }
    });
}

$('#delete-all').on('click', deleteSelected);

function deleteSelected() {
    $('body > div.container.body-content > table > tbody td:nth-child(1) > input[type="checkbox"]:checked').each(
        function () {
            $('.delete-btn[data-id=' + this.dataset.id + ']').trigger('click');
        }
    );
}