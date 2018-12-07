var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope) {

   
    var checkValidity = function () {
        var str1 = removeSpaces(document.getElementById('txtCaptcha').value);
       
        var a = $scope.captchain;
      
        if (a == str1) {
          

            $scope.capvalid = true;

        } else {
            
            $scope.capvalid = false
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

