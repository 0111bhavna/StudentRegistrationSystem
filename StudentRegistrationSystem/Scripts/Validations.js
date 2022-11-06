function EmailValidation(element) {
    
    if (element.value.length == 0) {
        toastr.error("Invalid Email");
    }
    else if (element.value.length < 8 || element.value.length > 50) {
        toastr.error("Email is not in correct format");
    }
   
}
function PasswordValidation(element) {
    if (element.value.length < 8 || element.value.length > 25) {
        toastr.error("password must be specified");
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
    if (!NIDRegexCharacter.test(element.value)) {
        toastr.error("National Id should be between 9 and 15 characters");
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