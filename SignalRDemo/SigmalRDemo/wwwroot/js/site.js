document.addEventListener("DOMContentLoaded", function () {
    $(".details-btn").on('click', function () {
        let productId = $(this).data("product-id");
        $.ajax({
            type: "GET",
            url: "/Product/Details",
            data: { Id: productId },
            success: function (product) {
                $("#productName").text(product.name);
                $("#productPrice").text(product.price);
                $("#productQuantity").text(product.quantity);
                $("#detailsModal").modal("show");
            },
            error: function () {
                console.log("Failed to load details.")
            }
        });
    });
});