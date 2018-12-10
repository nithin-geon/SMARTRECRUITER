var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope) {


    var checkValidity = function () {
        var str1 = removeSpaces(document.getElementById('txtCaptcha').value);

        var a = $scope.captchain;
        if (document.getElementById('txtCaptchaInput').value.length == 2) {
            if (a == str1) {
                $('#lblLogin').text('');
                $('#divLoginError').hasClass('visible')
                {
                    $('#divLoginError').removeClass('visible');
                    $('#divLoginError').addClass('invisible');
                }
                $scope.capvalid = true;

            } else {
                $('#lblLogin').text('Captcha Mismatch');
                $('#divLoginError').hasClass('invisible')
                {
                    $('#divLoginError').removeClass('invisible');
                    $('#divLoginError').addClass('visible');
                }
                $scope.capvalid = false
            }
        }
        else {
            $scope.capvalid = false;
        }

    };

    $scope.$watch('captchain', function () {
        checkValidity();
    });

});


// Remove the spaces from the entered and generated code
function removeSpaces(string) {
    return string.split(' ').join('');
}

