$(document).ready(function () {
    $("#btnModal").click(function () {
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Producto agregado al carrito',
            text: '¡Gracias :D!',
            showConfirmButton: false,
            timer: 1700
        })
    });
});
