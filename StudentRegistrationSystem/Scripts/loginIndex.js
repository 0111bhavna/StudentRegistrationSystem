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
    var emailAddress = $("#email").val();
    var password = $("#password").val(); 
    var authObj = { email: emailAddress, password: password };
    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Successful Authentication. Redirecting to relevent page.....");
            window.location.href = response.url;
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
