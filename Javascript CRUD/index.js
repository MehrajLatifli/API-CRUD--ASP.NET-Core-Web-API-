let response = "";

function Get() {
    try {
        var userUrl = `https://${document.getElementById('linktext').value}/Customer/GetOrderModelOrderBy`;

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {

            try {
                if (this.readyState == 4) {

                    // var response = JSON.parse(this.responseText, function (key, value) {


                    //     if (key == "productName") {

                    //         document.getElementById("result").innerHTML = value;
                    //     }
                    // });


                    document.getElementById("result").innerHTML = " ";


                    response = JSON.stringify(JSON.parse(this.responseText));





                    //  document.getElementById("result").innerHTML = response;

                    // document.getElementById("result").innerHTML= JSON.parse(this.responseText)[17].productName;




                    JSON.parse(this.responseText).forEach(function (r) {

                        document.getElementById("result").innerHTML += '<p>' + r.orderID + '&nbsp' + r.customerName + '&nbsp' + r.companyName + '&nbsp' + r.shipName + '</p>' + '<br/>';

                    });


                }
            }
            catch (erMs) {
                document.getElementById("result").innerHTML = erMs;
            }
        };
        xhttp.open("GET", userUrl, true);
        xhttp.setRequestHeader('Content-Type', 'text/plain');
        xhttp.send();
    }
    catch (erMsg) {
        document.getElementById("idCurrentName").innerHTML = erMsg;
    }
}




let obj = {};

function Post() {


    obj= new Object();


    obj.CustomerIdinOrders = document.getElementById('CustomerIdinOrders').value;
    obj.orderDate =  "2022-05-06T12:20:29.148Z";
    obj.requiredDate =  "2022-05-06T12:20:29.148Z";
    obj.shippedDate = "2022-05-06T12:20:29.148Z";
    obj.ShipVia = document.getElementById('ShipVia').value;
    obj.Freight = document.getElementById('Freight').value;
    obj.ShipName = document.getElementById('ShipName').value;
    obj.ShipAddress = document.getElementById('ShipAddress').value;
    obj.ShipCity = document.getElementById('ShipCity').value;
    obj.ShipRegion = document.getElementById('ShipRegion').value;
    obj.ShipPostalCode = document.getElementById('ShipPostalCode').value;
    obj.ShipCountry = document.getElementById('ShipCountry').value;

    var p = JSON.stringify(obj);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("result").innerHTML = request.responseText;
        }
    };

    request.open("POST", `https://${document.getElementById('linktext').value}/Customer/PostOrder`, true);
    request.setRequestHeader("Content-type", "application/json; charset=UTF-8");


    request.send(p);

    Get();



}


function Delete() {
    try {




        obj.OrderId = document.getElementById('OrderId').value;
        obj.CustomerIdinOrders = document.getElementById('CustomerIdinOrders').value;
        obj.OrderDate = "NULL";
        obj.RequiredDate ="NULL";
        obj.ShippedDate = "NULL";
        obj.ShipVia = document.getElementById('ShipVia').value;
        obj.Freight = document.getElementById('Freight').value;
        obj.ShipName = document.getElementById('ShipName').value;
        obj.ShipAddress = document.getElementById('ShipAddress').value;
        obj.ShipCity = document.getElementById('ShipCity').value;
        obj.ShipRegion = document.getElementById('ShipRegion').value;
        obj.ShipPostalCode = document.getElementById('ShipPostalCode').value;
        obj.ShipCountry = document.getElementById('ShipCountry').value;

        $.ajax({

            url: `https://${document.getElementById('linktext').value}/Customer/DeleteOrder/${obj.OrderId}`,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            type: 'Delete',
            data: JSON.stringify(obj.OrderId),
            success: function (result) {
                alert('Delete');

                Get();
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Error in Operation');
            }
        })


    } catch (error) {

    }
}


function Update() {
    try {

        obj= new Object();

        obj.idorder = document.getElementById('OrderId').value;
        obj.customerIdinOrders = document.getElementById('CustomerIdinOrders').value;
        obj.orderDate =  "2022-05-06T12:20:29.148Z";
        obj.requiredDate =  "2022-05-06T12:20:29.148Z";
        obj.shippedDate = "2022-05-06T12:20:29.148Z";
        obj.shipVia = document.getElementById('ShipVia').value;
        obj.freight = document.getElementById('Freight').value;
        obj.shipName = document.getElementById('ShipName').value;
        obj.shipAddress = document.getElementById('ShipAddress').value;
        obj.shipCity = document.getElementById('ShipCity').value;
        obj.shipCity = document.getElementById('ShipRegion').value;
        obj.shipPostalCode = document.getElementById('ShipPostalCode').value;
        obj.shipPostalCode = document.getElementById('ShipCountry').value;


        var url = `https://${document.getElementById('linktext').value}/Customer/OrderPut`;
        
        var p = JSON.stringify(obj);

        var request = new XMLHttpRequest();
        request.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 204) {
                document.getElementById("result").innerHTML = request.responseText;
            }
        };
    
        request.open("Put", url, true);
        request.setRequestHeader("Content-type", "application/json; charset=UTF-8");
    
    
        request.send(p);



    } catch (error) {

    }
}


