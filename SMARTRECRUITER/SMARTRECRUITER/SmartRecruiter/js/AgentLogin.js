

var ObjAgentlogin = new Agentlogin();
var isValidation = 0;
function Agentlogin() {


    this.init = function () {

        try {
            this.Clear();
            this.DrawCaptcha();


        }
        catch (ex) {
            alert(ex + 'Initialise Product')
        }
    };

    this.Clear = function () {

        $('#txtUserName').val("");
        $("#txtUserName").removeClass("validateerror");
        $('#txtPassword').val("");
        $("#txtPassword").removeClass("validateerror");
        isValidation = 0;

    };

    this.Validate = function () {
        try {
            if (isValidation == 1) {
                var _Error = 0;
                if (($('#txtUserName').val() == "") || ($('#txtUserName').val() == "User Name")) {
                    $('#txtUserName').addClass("validateerror");
                    $('#txtUserName').focus();
                    _Error++;
                }
                else {
                    $('#txtUserName').removeClass("validateerror");
                }
                if (_Error == 0) {
                    if (($('#txtPassword').val() == "") || ($('#txtPassword').val() == "Password")) {
                        $('#txtPassword').addClass("validateerror");
                        $('#txtPassword').focus();
                        _Error++;
                    }
                    else {
                        $('#txtPassword').removeClass("validateerror");
                    }
                }
                return _Error;
            }
        } catch (e) {
            alert(e);
        }


    }
    this.Submit = function () {
        isValidation = 1;
        if (this.Validate() <= 0) {
            ObjAgentlogin.AgentloginCheck();
        }
        else {

            return false;
        }
    };

    this.AgentloginCheck = function () {
        try {
            var ObjBlAgent = {
                AgUserName: $('#txtUserName').val(),
                AgPassword: $('#txtPassword').val(),

            };

            var DATA = JSON.stringify(ObjBlAgent);

            $.ajax({
                url: api_url + '/Home/AgentloginCheck',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode == 2) {

                            //alert('UserName and password mismatch');
                            $('#lblLogin').text('Invalid Username or Password');
                            $('#divLoginError').hasClass('invisible')
                            {
                                $('#divLoginError').removeClass('invisible');
                                $('#divLoginError').addClass('visible');
                            }
                            //window.location.href = data.Url;
                            ObjAgentlogin.DrawCaptcha();
                            $('#btnSubmit').prop('disabled', true);
                            //$('button').prop('disabled', false); 
                            $('#txtCaptchaInput').val('');
                        }
                        else {
                            $('#lblLogin').html('');
                            $('#divLoginError').hasClass('visible')
                            {
                                $('#divLoginError').removeClass('visible');
                                $('#divLoginError').addClass('invisible');
                            }
                            window.location.href = data.Url;

                        }



                    }
                    catch (ex) {
                        alert('llll');
                        alert(ex + 'return issue');
                    }

                }
                ,

                error: function (error) {
                    alert(error + ' : AgentloginCheck');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Home/AgentloginCheck');
        }




    }

    this.DrawCaptcha = function () {
        function randString(x) {
            var s = "";
            while (s.length < x && x > 0) {
                var r = Math.random();
                s += (r < 0.1 ? Math.floor(r * 100) : String.fromCharCode(Math.floor(r * 27) + (r > 0.5 ? 97 : 65)));
            }
            return s;
        }

        document.getElementById("txtCaptcha").value = randString(2);
    }





}