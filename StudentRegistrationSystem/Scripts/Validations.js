function EmailValidation(element) {
    
    if (element.value.length == 0) {
        toastr.error("Invalid Email");
    }
    else if (element.value.length < 8 || element.value.length > 50) {
        toastr.error("Email is not in correct format");
    }
    else {
        ValidateData(element.value,'/User/isEmailValid').then((response) => {
            if (response.result) {
                $("#emailErr").html("Email already exists!");
            }
        }).catch((error) => {
                console.error(error);
                toastr.error('Unable to make request!!');
        });
    }
}
function PasswordValidation(element) {
    if (element.value.length < 5 || element.value.length > 25) {
        toastr.error("password must be between 5 and 25 characters");
    }
}
function FirstNameValidation(element) {
    if (element.value.length < 2 || element.value.length > 100) {
        var attributeName = element.getAttribute("name");
        toastr.error("Firstname should be between 2 and 100 characters");
    }
}
function SurnameValidation(element) {
    if (element.value.length < 2 || element.value.length > 100) {
        var attributeName = element.getAttribute("name");
        toastr.error("Surname should be between 2 and 100 characters");
    }
}
function NationalIdValidation(element) {
    var minLength = 9;
    var maxLength = 15;
    var NIDRegexCharacter = /^[a-zA-Z0-9]*$/;
    if (element.value.length < minLength || element.value.length > maxLength) {
        toastr.error("National Id should be between 9 and 15 characters");
    }
    else if (!NIDRegexCharacter.test(element.value)) {
        toastr.error("National Id should be between 9 and 15 characters");
    }

    else {
        ValidateNId(element.value, '/Student/isNidValid').then((response) => {
            if (response.result) {
                $("#NIdErr").html("National ID already exists!");
            }
        }).catch((error) => {
            console.error(error);
            toastr.error('Unable to make request!!');
        });
    }

}
function StreetValidation(element) {
    if ((element.value.length)< 2 || element.value.length > 30) {
        toastr.error("Street should be between 2 and 15 characters");
    }
}
function CityValidation(element) {
    if ((element.value.length) < 2 || element.value.length > 30) {
        toastr.error("City should be between 2 and 15 characters");
    }
}
function CountryValidation(element) {
    if ((element.value.length) < 2 || element.value.length > 30) {
        toastr.error("Invalid Country Name");
    }
}
function GuardianNameValidation(element) {
    if (element.value.length < 2 || element.value.length > 100) {
        var attributeName = element.getAttribute("name");
        toastr.error("Surname should be between 2 and 100 characters");
    }
}

function PhoneNumberValidation(element) {

    ValidatePhoneNumber(element.value, '/Student/isPhoneNumberValid').then((response) => {
        if (response.result) {
            $("#PhoneNumberErr").html("Phone Number already exists!");
        }
    }).catch((error) => {
        console.error(error);
        toastr.error('Unable to make request!!');
    });

}

function ValidateData(UserData, urlValidate) {
   
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: urlValidate,
            data: {email: UserData },
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
function ValidateNId(UserData, urlValidate) {

    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: urlValidate,
            data: { NationalId: UserData },
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
function ValidatePhoneNumber(UserData, urlValidate) {

    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: urlValidate,
            data: { PhoneNumber: UserData },
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