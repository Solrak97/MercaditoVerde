function VerCarrito() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('contenido').innerHTML = this.responseText;
            document.getElementById('carrito').style.display = 'block';
        }
    };
    xhr.open('GET', '/Carrito/VerCarrito', true);
    xhr.send();
}

function agregarProducto(id, cantidad) {
    var obj = {
        id: id,
        cantidad: cantidad
    };

    $.ajax({
        url: "/Carrito/AgregarProducto",
        type: 'POST',
        data: obj,
        success: function (response) {
            console.log(response);
        },
        error: function (response) {
            console.log("error");
            console.log(response);
        }
    });
}

function EliminarProducto(id) {
    var obj = {
        id: id,
    };

    $.ajax({
        url: "/Carrito/EliminarProducto",
        type: 'POST',
        data: obj,
        success: function (response) {
            console.log(response);
        },
        error: function (response) {
            console.log("error");
            console.log(response);
        }
    });

    VerCarrito();
}