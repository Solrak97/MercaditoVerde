function VerCarrito() {
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('contenido').innerHTML = this.responseText;
            document.getElementById('carrito').style.display = 'block';
        }
    };
    xhr.open('GET', '/Carrito/VerCarrito');
    xhr.send();
}

function AgregarProducto(id) {
    document.getElementById('mensaje-exito').style.display = 'block';
    var number = document.getElementById('number' + id);
    var currentValue = Number(number.value) || 0;

    if (currentValue > 0) {
        var obj = {
            id: id,
            cantidad: currentValue
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
        number.value = 0;
        document.getElementById('mensaje').innerHTML = 'Producto añadido con exito';
        document.getElementById('mensaje').style = "color:green; font-size:30px";
    }
    else {
        document.getElementById('mensaje').innerHTML = 'Hay un error en las cantidades ingresadas';
        document.getElementById('mensaje').style = "color:red; font-size:30px";
    }
}

function AgregarPaquete(id) {
    document.getElementById('mensaje-exito').style.display = 'block';
    var number = document.getElementById('number' + id);
    var currentValue = Number(number.value) || 0;

    if (currentValue > 0) {
        var obj = {
            id: id,
            cantidad: currentValue
        };

        $.ajax({
            url: "/Carrito/AgregarPaquete",
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
        number.value = 0;
        document.getElementById('mensaje').innerHTML = 'Paquete añadido con exito';
        document.getElementById('mensaje').style = "color:green; font-size:30px";
    }
    else {
        document.getElementById('mensaje').innerHTML = 'Hay un error en las cantidades ingresadas';
        document.getElementById('mensaje').style = "color:red; font-size:30px";
    }
}

function EliminarProducto(id) {
    var obj = {
        id: id,
    };

    $.ajax({
        url: "/Carrito/EliminarProducto",
        type: 'POST',
        data: obj,
        async: false,
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

function EliminarPaquete(id) {
    var obj = {
        id: id,
    };

    $.ajax({
        url: "/Carrito/EliminarPaquete",
        type: 'POST',
        data: obj,
        async: false,
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


function Add(id) {
    var number = document.getElementById('number' + id);
    var currentValue = Number(number.value) || 0;
    number.value = currentValue + 1;
}

function Sub(id) {
    var number = document.getElementById('number' + id);
    var currentValue = Number(number.value) || 0;
    currentValue = currentValue - 1
    if (currentValue < 0) {
        currentValue = 0;
    }
    number.value = currentValue;
}