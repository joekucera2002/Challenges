$(document).ready(function () {
    $("#UpdateEmployee").click(function () {
        updateEmployee();
    });
});

// Ajax Functions
function updateEmployeeCost() {
    var id = $("#Id").val();
    var location = "/Employee/GetEmployeeCost/" + id;

    $.ajax({
        url: location,
        type: "GET",
        dataType: "text",
        success: function (data) {
            $("#EmployeeDeduction").val(parseFloat(data).toFixed(2));
        }
    });
}

function updateTotalCost() {
    var id = $("#Id").val();
    var location = "/Employee/GetTotalCost/" + id;

    $.ajax({
        url: location,
        type: "GET",
        dataType: "text",
        success: function (data) {
            $("#TotalCost").val(parseFloat(data).toFixed(2));
        }
    });
}

function updateEmployee() {
    var id = $("#Id").val();
    var firstName = $("#FirstName").val();
    var lastName = $("#LastName").val();
    var age = $("#Age").val();

    var employee = {};
    employee.Id = id;
    employee.FirstName = firstName;
    employee.LastName = lastName;
    employee.Age = age;

    $.ajax({
        url: "/Employee/Update",
        type: "POST",
        data: JSON.stringify(employee),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            updateEmployeeCost();
            updateTotalCost();
        }
    });
}

function update(location, obj) {
    var result;



    return result;
}