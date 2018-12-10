
//Added By Nithin das H

// Function for integer checking
function CheckInteger(e) {
    var t = e.keyCode ? e.keyCode : e.charCode ? e.charCode : e.which;
    8 != t && 9 != t && (48 > t || t > 57) && (e.preventDefault ? e.preventDefault() : e.returnValue = !1)
}


// Function in Mobile blur checking :this event 
function CheckMobileNumberBlur(inputtxt) {
    try {
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if ((inputtxt.value.match(phoneno))) {
            $("#" + inputtxt.id).removeClass("validateerror");
        }
        else {
            $("#" + inputtxt.id).addClass("validateerror");

        }
    }
    catch (e) {
        alert(e + ' Check Mobile Number')
    }
}


// Function in Validate  submit button: control name:MobileNo
function CheckMobileNumberSubmit(inputtxt) {
    try {

        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if (($("#" + inputtxt).val().match(phoneno))) {
            return false;
        }
        else {
            return true;
        }

    }
    catch (e) {
        alert(e + ' Check Mobile Number')
    }
}

// Function in EmailId blur checking :this event 
function CheckEmailBlur(inputtxt) {
    try {
        var email = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
        if ((inputtxt.value.match(email))) {
            $("#" + inputtxt.id).removeClass("validateerror");
        }
        else {
            $("#" + inputtxt.id).addClass("validateerror");

        }

    }
    catch (e) {
        alert(e + ' Check Email')
    }
}

// Function in Validate  submit button: control name :Email
function CheckEmailSubmit(inputtxt) {
    try {
        var email = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
        if (($("#" + inputtxt).val().match(email))) {
            return false;
        }
        else {
            return true;
        }

    }
    catch (e) {
        alert(e + ' Check Email')
    }
}

// Function in Compare blur checking :text1 and text2
function compare(a, b) {
    var pass = $("#" + a).val();
    var confirmpass = $("#" + b).val();
    var valid = pass == confirmpass;
    if (!valid) {
        MessageText('-22', '', '')
        return true;
    }
    else {
        return false;
    }
}

// Function in CheckPassword blur checking :in Password field
function CheckPasswordBlur(inputtxt) {

    
    var paswd = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    if (inputtxt.value.match(paswd)) {
        return false;
    }
    else {
        MessageText('-23', '', '')
        return true;
    }
}

// Function in CheckPassword Submit checking :in Password field
function CheckPasswordSubmit(inputtxt) {
    var paswd = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    if ($("#" + inputtxt).val().match(paswd)) {
        return false;
    }
    else {
        MessageText('-23', '', '')
        return true;
    }
}

// Function of CheckCharacter
function CheckCharacter(e) {

    try {
        var inputValue = e.keyCode ? e.keyCode : e.which;
        if (((inputValue == 8) || (inputValue >= 65 && inputValue <= 90) || (inputValue >= 97 && inputValue <= 122) || (inputValue >= 37 && inputValue <= 40)) && (inputValue != 32)) {
        }
        else {
            e.preventDefault();
        }

    }

    catch (err) {

        alert(err + inputValue);

    }
}



function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
}
function ToJavaScriptDateTime(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return dt.toUTCString().split(' ').slice(0, 5).join(' ');
}

this.SyncValues = function (txt1, txt2,txt3) {
    var n1 = document.getElementById(txt1);
    var n2 = document.getElementById(txt2);
    var n3 = document.getElementById(txt3);

    n2.value = n1.value;
    n3.value = n1.value;
};
