

var ObjAgentUserLimit = new AgentUserLimit();
var isValidation = 0;
function AgentUserLimit() {



    this.init = function () {

        try {
            this.Show(1);
            this.Clear();
            this.FillCompanyDropdown();
            this.FillGrid();

        }
        catch (ex) {
            alert(ex + 'Initialize AgentUserLimit')
        }
    };


    this.Clear = function () {

        $('#AgentUserLimitId').val("");
        $('#ddlCompanyMaster').val(0);
        $("#ddlCompanyMaster").removeClass("validateerror");
        $('#txtUserLimit').val("");
        $("#txtUserLimit").removeClass("validateerror");
        $('#txtAgentLimit').val("");
        $("#txtAgentLimit").removeClass("validateerror");
        isValidation = 0;


    };


    this.Show = function (id) {

        if (id == 1) {
            $("#AddBranch").hide();
            $("#ViewBranch").show();

        }
        else {
            $("#ViewBranch").hide();
            $("#AddBranch").show();

        }
    };
    this.Validate = function () {

        if (isValidation == 1) {
            var _Error = 0;

            if ($('#ddlCompanyMaster option:selected').val() == '0') {
                $('#ddlCompanyMaster').addClass("validateerror");
                _Error++;
            }
            else {
                $('#ddlCompanyMaster').removeClass("validateerror");
            }
            if ($('#txtUserLimit').val().trim() == "") {
                $('#txtUserLimit').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtUserLimit').removeClass("validateerror");
            }

            if ($('#txtAgentLimit').val().trim() == "") {
                $('#txtAgentLimit').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentLimit').removeClass("validateerror");
            }

            //if ($('#txtAgentUserLimitSortOrder').val() == "") {
            //    $('#txtAgentUserLimitSortOrder').addClass("validateerror");
            //    _Error++;
            //}
            //else {
            //    $('#txtAgentUserLimitSortOrder').removeClass("validateerror");
            //}

            return _Error;
        }

    }

    this.Submit = function () {

        isValidation = 1;
        if (this.Validate() <= 0) {

            ObjAgentUserLimit.Save();
        }
        else {

            return false;
        }
    };


    this.Save = function () {
        try {
            var ObjBlAgentUserLimit = {
                MasterID: $('#AgentUserLimitId').val() == '' ? '0' : $('#AgentUserLimitId').val(),
                AgentLimit: $('#txtAgentLimit').val().trim(),
                UserLimit: $('#txtUserLimit').val().trim(),
                FK_CompanyMaster: $('#ddlCompanyMaster option:selected').val()

            };

            var DATA = JSON.stringify(ObjBlAgentUserLimit);
            $.ajax({
                url: api_url + '/AgentUserLimit/UpdateAgentUserLimit',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#AgentUserLimitId').val() == '' ? '0' : $('#AgentUserLimitId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtAgentUserLimitCode');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtAgentUserLimitCode');
                            }

                            ObjAgentUserLimit.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtAgentUserLimitCode');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateAgentUserLimit');

                }

            });
        }
        catch (e) {
            alert(e + '   : /AgentUserLimit/UpdateAgentUserLimit');
        }




    }


    this.FillGrid = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/AgentUserLimit/SelectAgentUserLimitAll",
                cache: false,
                type: "GET",
                data: { 'PageIndex': PageIndex, 'SearchItem': $('#txtSearch').val() },
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    try {
                        var Mydata = JSON.parse(data);
                        var RecordCount = "0";
                        var html = "";
                        if (Mydata.length > 0) {

                            html += "<table width = '100%' id='example1' class='table table-bordered table-striped'>" +
                                      "<thead background-color='rgb(60, 141, 188)'>" +
                                          "<tr>" +
                                          "<th style = 'display:none' width  = '10%' >ID_AgentUserLimit</th>" +
                                          //"<th style = 'display:none' width  = '10%' >ID_Department</th>" +
                                           "<th width  = '20%' >SlNo</th>" +
                                          "<th width  = '20%' >Company</th>" +
                                          "<th width  = '25%' >Agent Limit</th>" +
                                          "<th width  = '15%' >User Limit</th>" +
                                          "</tr>" +
                                      "</thead>";

                            $.each(Mydata, function (key, val) {
                                var htmlActionTd = "<td>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.FillAgentUserLimit(" + val.ID_AgentUserLimit + ")' class='edit'><i class='glyphicon glyphicon-edit'></i>" + "</a>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.DeleteAgentUserLimit(" + val.ID_AgentUserLimit + ")' class='remove'><i class='glyphicon glyphicon-trash'></i>" + "</a>" +
                                                   "</td>";
                                html += "<tr>" +

                                            "<td style = 'display:none'>" + val.ID_FK_CompanyMaster + "</td>" +
                                            //"<td style = 'display:none'>" + val.FK_DefaultDepartment + "</td>" +
                                            "<td>" + val.SlNo + "</td>" +
                                           "<td>" + val.CompName + "</td>" +
                                            "<td>" + val.AgentLimit + "</td>" +
                                             "<td>" + val.UserLimit + "</td>" +
                                            htmlActionTd +
                                            "</tr>";
                                RecordCount = val.RecordCount;

                            });

                            try   //Page Indexing Starts here
                            {
                                var temppagecount = parseInt(RecordCount) / 10

                                var pageCount = parseInt(Math.ceil(parseFloat(temppagecount)))
                                if (!PageIndex) {
                                    PageIndex = 1;
                                }

                                var i;

                                if (parseInt(PageIndex) <= 10) {
                                    i = 1;
                                }
                                else {

                                    i = PageIndex;
                                    var j = parseInt(i) % 10;
                                    if (parseInt(j) == parseInt(0)) {
                                        i = parseInt(i) - parseInt(9);
                                    }
                                    else {
                                        i = (parseInt(i) - parseInt(j) + parseInt(1));
                                    }

                                }

                                if (parseInt(pageCount) > 0) {
                                    html += "</table><div class='box-footer clearfix'><ul class='pagination pagination-sm no-margin pull-right'>" +
                                        "<li><a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.FillGrid(1)' class= '" + (parseInt(PageIndex) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>First</a></li>" +
                                   "<li><a href ='javascript:void(0)'  onclick = 'ObjAgentUserLimit.FillGrid(" + (parseInt(i) - parseInt(10)) + ")'   class= '" + (parseInt(i) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>«</a></li>"
                                    while (parseInt(i) <= parseInt(pageCount)) {
                                        html += "<li><a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.FillGrid(" + i + ")'  class='" + (parseInt(i) != parseInt(PageIndex) ? "activeAnchor" : "not-activeAnchorSelected") + "'   >" + i + "</a></li>"
                                        if (parseInt(i) % parseInt(10) == 0) {
                                            break;
                                        }
                                        i++;
                                    }
                                    html += "<li><a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.FillGrid(" + (parseInt(i) + parseInt(1)) + ")'   class= '" + ((parseInt(pageCount) - parseInt(PageIndex)) > 10 ? "activeAnchor" : "not-activeAnchor") + " ' >»</a></li>" +
                                    "<li><a href ='javascript:void(0)' onclick = 'ObjAgentUserLimit.FillGrid(" + pageCount + ")'   class= '" + (parseInt(PageIndex) < parseInt(pageCount) ? "activeAnchor" : "not-activeAnchor") + "'>Last</a></li>" +
                                   "</ul></div>";

                                }
                            }   //Page Indexing Starts here
                            catch (er) {
                                alert(er + 'Page Indexing');
                            }
                        }
                        $("#Grid").html(html);
                    }
                    catch (ex) {
                        alert(ex);
                    }

                },
                Error: function (response) {
                    try {
                        alert('ExceptionType: ' + r.ExMessge);
                    }
                    catch (ex) {
                        alert(ex);
                    }
                }


            });
        }
        catch (e) {
            alert(e);
        }
    }


    this.FillAgentUserLimit = function (ID_AgentUserLimit) {
        $.ajax({
            url: api_url + "/AgentUserLimit/FillAgentUserLimit",
            data: { 'ID_AgentUserLimit': ID_AgentUserLimit },
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlAgentUserLimit = value;
                            $('#AgentUserLimitId').val(ObjBlAgentUserLimit.ID_AgentUserLimit);
                            $('#txtAgentLimit').val(ObjBlAgentUserLimit.AgentLimit);
                            $('#txtUserLimit').val(ObjBlAgentUserLimit.UserLimit);
                            $('#ddlCompanyMaster').val(ObjBlAgentUserLimit.FK_CompanyMaster);
                           
                        }
                        )
                    };
                    ObjAgentUserLimit.Show(2);
                }
                catch (e) {
                    alert(e + 'FillAgentUserLimit');
                }

            }
        });

    }

    this.FillCompanyDropdown = function () {
        try {
            $.ajax({

                url: api_url + '/AgentUserLimit/CompanyDropDownFill',
                cache: false,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        var optionhtml = '<option value=' + 0 + '>Select</option>';
                        try {
                            $.each(Mydata, function (i, value) {
                                optionhtml += '<option value=' + value.ID_Company + '>' + value.CompName + '</option>';
                            });
                        }
                        catch (exx) {
                            alert(exx);
                        }
                    }
                    $('#ddlCompanyMaster').html(optionhtml);
                },

                error: function (xhr, status, error) {
                    var err = eval('(' + xhr.responseText + ')');
                    alert(err.Message);
                }

            });
        }
        catch (ex) {
            alert(ex + ' Exception FillAgentGroupDropdown');
        }
    }



    this.DeleteAgentUserLimit = function (ID_AgentUserLimit) {
        if (confirm('Do you want to delete..?')) {
            $.ajax({
                url: api_url + "/AgentUserLimit/DeleteAgentUserLimit",
                data: { 'ID_AgentUserLimit': ID_AgentUserLimit },
                cache: false,
                type: 'Get',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var msg = "";
                    if (data.statusCode > 0) {
                        MessageText(data.statusCode, 'Deleted Successfully', '#txtAgentUserLimitCode');
                    }
                    else {
                        MessageText(data.statusCode, '', '#txtAgentUserLimitCode');
                    }
                    ObjAgentUserLimit.init();


                }
            });
        }


    }
}