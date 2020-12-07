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

function agregarProducto(id) {
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
    }
    else {

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