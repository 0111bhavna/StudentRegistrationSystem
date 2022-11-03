
$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});

function registration() {
    var url = Url.Action("Registration", "LoginRegister")
    window.location = url;
}

function login() {

    //alert("ok");
    var emailAddress = $("#email").val();
    var password = $("#password").val(); 
    //alert(emailAddress);
    var authObj = { email: emailAddress, password: password };

    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
            window.location.href = '/HomePage/Index';
        }
        else {
            toastr.error('Unable to Authenticate user');
            return false;
        }
    })
        .catch((error) => {
            toastr.error(error);
        });
}

function sendData(userCredential) {

    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Login/Authentication",
            data: userCredential,
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
