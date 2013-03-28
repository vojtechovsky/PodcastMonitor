$(document).ready(function () {
    // Send an AJAX request
    $.getJSON("api/feeds/",
    function (data) {
        // On success, 'data' contains a list of products.
        $.each(data, function (key, val) {

            // Format the text to display.
            var str = val.Name + ': $ ' + val.Category;

            // Add a list item for the product.
            $('<li/>', { text: str })
            .appendTo($('#feeds'));
        });
    });
});

function find() {
    var id = $('#feedId').val();
    $.getJSON("api/feeds/" + id,
        function (data) {
            var str = data.Name + ': $ ' + data.Price;
            $('#feed').text(str);
        })
    .fail(
        function (jqXHR, textStatus, err) {
            $('#feed').text('Error: ' + err);
        });
}