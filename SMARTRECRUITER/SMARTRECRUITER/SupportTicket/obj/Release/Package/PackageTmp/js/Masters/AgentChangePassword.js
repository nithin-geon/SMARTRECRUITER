
var ObjAgentChangePassword = new AgentChangePassword();
var isValidation = 0;
function AgentChangePassword() {

    this.init = function () {

        try {
            this.Show(1);
            this.Clear();
            this.FillAgentChangePassword();
        }
        catch (ex) {
            alert(ex + 'Initialize AgentChangePassword')
        }
    };


    this.Clear = function () {

        $('#AgentId').val("");
        //$('#txtAgentName').val("");
        //$("#txtAgentName").removeClass("validateerror");
        //$('#txtAgentUserName').val("");
        //$("#txtAgentUserName").removeClass("validateerror");
        $('#txtAgentCurrentPassword').val("");
        $("#txtAgentCurrentPassword").removeClass("validateerror");
        $('#txtAgentNewPassword').val("");
        $("#txtAgentNewPassword").removeClass("validateerror");
        $('#txtAgentConfirmPassword').val("");
        $("#txtAgentConfirmPassword").removeClass("validateerror");

        $("#txtAgentName").attr("disabled", "disabled");
        $("#txtAgentUserName").attr("disabled", "disabled");
        isValidation = 0;
    };


    this.Show = function (id) {

        //if (id == 1) {
        //    $("#AddAgent").hide();
        //    $("#ViewAgent").show();

        //}
        //else {
        //    $("#ViewAgent").hide();
        //    $("#AddAgent").show();

        //}
        $("#ChangePassword").show();
    };
    this.Validate = function () {

        if (isValidation == 1) {
            var _Error = 0;

            if ($('#txtAgentName').val() == "") {
                $('#txtAgentName').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentName').removeClass("validateerror");
            }

            if ($('#txtAgentUserName').val() == "") {
                $('#txtAgentUserName').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentUserName').removeClass("validateerror");
            }

            if ($('#txtAgentCurrentPassword').val() == "") {
                $('#txtAgentCurrentPassword').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentCurrentPassword').removeClass("validateerror");
            }

            if ($('#txtAgentNewPassword').val() == "" || CheckPasswordSubmit('txtAgentNewPassword')) {
                $('#txtAgentNewPassword').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentNewPassword').removeClass("validateerror");
            }

            if ($('#txtAgentConfirmPassword').val() == "" || compare('txtAgentNewPassword', 'txtAgentConfirmPassword') || CheckPasswordSubmit('txtAgentConfirmPassword')) {
                $('#txtAgentConfirmPassword').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentConfirmPassword').removeClass("validateerror");
            }
            return _Error;
        }

    }

    this.Submit = function () {
        isValidation = 1;
        if (this.Validate() <= 0) {
            ObjAgentChangePassword.Save();
        }
        else {

            return false;
        }
    };


    this.Save = function () {
        try {
            var ObjBlAgent = {
                MasterID: $('#AgentId').val() == '' ? '0' : $('#AgentId').val(),
                AgName: $('#txtAgentName').val(),
                AgUserName: $('#txtAgentUserName').val(),
                AgPassword: $('#txtAgentNewPassword').val(),
                CurrentPassword: $('#txtAgentCurrentPassword').val()
            };

            var DATA = JSON.stringify(ObjBlAgent);
            $.ajax({
                url: api_url + '/Recruiters/UpdateAgentChangePassword',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#AgentId').val() == '' ? '0' : $('#AgentId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtAgentName');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtAgentName');
                            }

                            ObjAgentChangePassword.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtAgentName');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateAgentChangePassword');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Agent/UpdateAgentChangePassword');
        }

    }
    this.FillAgentChangePassword = function () {
        $.ajax({
            url: api_url + "/Recruiters/FillAgentChangePassword",
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {                  
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlAgent = value;
                            $('#AgentId').val(ObjBlAgent.ID_Agent);
                            $('#txtAgentName').val(ObjBlAgent.AgName);
                            $('#txtAgentUserName').val(ObjBlAgent.AgUserName);
                        }
                        )
                    };
                    ObjAgentChangePassword.Show(2);
                }
                catch (e) {
                    alert(e + 'FillAgentChangePassword');
                }

            }
        });

    }

}