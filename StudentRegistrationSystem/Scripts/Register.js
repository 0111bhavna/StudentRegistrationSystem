$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function register() {
    var Email = $("#Email").val();
    var Password = $("#Password").val();
    var ConfirmPassword = $("#ConfirmPassword").val();
    var NationalId = $("#NationalId").val();
    var FirstName = $("#FirstName").val();
    var Surname = $("#Surname").val();
    var Street = $("#Street").val();
    var City = $("#City").val();
    var Country = $("#Country").val();
    var PhoneNumber = $("#PhoneNumber").val();
    var DateofBirth = $("#DateofBirth").val();
    var GuardianName = $("#GuardianName").val();

    var address = {
        Street: $("#Street").val(),
        City: $("#City").val(),
        Country: $("#Country").val()
    };

    var studentObj = {
        NationalId: $("#NationalId").val(), FirstName: $("#FirstName").val(),
        Surname: $("#Surname").val(), Address: address, PhoneNumber: PhoneNumber, DateOfBirth: DateofBirth, GuardianName: GuardianName
    };
    var UserObj = {
        Email: $("#Email").val(),
        Password: $("#Password").val(),
        Student: studentObj
    };
    sendData(UserObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
            window.location.href = '/Login/Login';
        }
        else {
            toastr.error('Unable to Authenticate user');
            return false;
        }
    }).catch((error) => {
        console.error(error);
        toastr.error('Unable to make request!!');
    });
}

function sendData(student) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Register/CreateStudent",
            data: student,
            dataType: "json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}

