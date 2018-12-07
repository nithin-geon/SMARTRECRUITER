var ObjSettings = new Settings();
function Settings() {

    this.init = function () {

        try {
            this.Show(1);
            this.Clear();
            //this.FillAgentDropdown();
            this.FillSettings();
        }
        catch (ex) {
            alert(ex + 'Initialize Settings')
        }
    };



    this.Clear = function () {
        $('#SettingsId').val("");
        $('#chkAuto').prop("checked", false);
        $('#txtPrefix').val("");
        $("#txtPrefix").removeClass("validateerror");
        isValidation = 0;
    };

    this.ClearAutoclose = function () {
        $('#SettingsId').val("");
        $('#chkAutoClose').prop("checked", false);
        $('#AutoCloseDays').val("");
        $("#AutoCloseDays").removeClass("validateerror");
        isValidation = 0;
    };



    this.Show = function (id) {

        if (id == 1) {

            $("#AddSettings").show();

        }
        else {
            $("#AddSettings").show();


        }
    };


    this.Submit = function () {

        ObjSettings.Save();
    };

    this.SubmitAutoclose = function () {

        ObjSettings.SaveAutoclose();
    };

    this.Save = function () {
        try {

            var ObjBlSettings = {
                MasterID: $('#SettingsId').val() == '' ? '0' : $('#SettingsId').val(),
                AutoGen: $('#chkAuto').is(":checked"),
                Prefix: $('#txtPrefix').val().trim()
            };
            var DATA = JSON.stringify(ObjBlSettings);
            $.ajax({
                url: api_url + '/Settings/UpdateSettings',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#SettingsId').val() == '' ? '0' : $('#SettingsId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtPrefix');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtPrefix');
                            }

                            ObjSettings.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtPrefix');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateSettings');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Settings/UpdateSettings');
        }




    }

    this.SaveAutoclose = function () {
        try {

            var ObjBlSettings = {
                MasterID: $('#SettingsId').val() == '' ? '0' : $('#SettingsId').val(),
                AutoCloseDays: $('#AutoCloseDays').val().trim() == '' ? '0' : $('#AutoCloseDays').val().trim()              
            };           
            var DATA = JSON.stringify(ObjBlSettings);
            $.ajax({
                url: api_url + '/Settings/UpdateSettingsAutoclose',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#SettingsId').val() == '' ? '0' : $('#SettingsId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#AutoCloseDays');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#AutoCloseDays');
                            }

                            ObjSettings.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#AutoCloseDays');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateSettingsAutoclose');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Settings/UpdateSettings');
        }




    }


    this.FillSettings = function (Module, SubModule) {
        $.ajax({
            url: api_url + "/Settings/FillSettings",
            data: { 'Module': Module, 'SubModule': SubModule },
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlSettings = value;
                            if (ObjBlSettings.Name == 'AUTO') {
                                if (ObjBlSettings.Value == true) {
                                    $('#chkAuto').prop("checked", true);
                                }
                                else {
                                    $('#chkAuto').prop("checked", false);
                                }
                            }
                            if (ObjBlSettings.Name == 'PRF') {
                                $('#txtPrefix').val(ObjBlSettings.Value);
                            }
                            if (ObjBlSettings.Name == 'ACL') {
                                $('#AutoCloseDays').val(ObjBlSettings.Value);
                            }
                        }
                        )
                    };
                }
                catch (e) {
                    alert(e + 'FillSettings');
                }

            }
        });

    }
}