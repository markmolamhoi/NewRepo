
//46=. 47 = / 45=-
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 45 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

//check number only 0,1,2,3,4,5,6,7,8,9
function isNumber(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}