

var ObjAgentGroup = new AgentGroup();
var isValidation = 0;
function AgentGroup() {



    this.init = function () {
       
        try {
            this.Show(1);
            this.Clear();
            // this.FillDepartmentDropdown();
            this.FillGrid();
        }
        catch (ex) {
            alert(ex + 'Initialize AgentGroup')
        }
    };


    this.Clear = function () {

        $('#AgentGroupId').val("");
        $('#txtAgentGroupCode').val("");
        $("#txtAgentGroupCode").removeClass("validateerror");
        $('#txtAgentGroupName').val("");
        $("#txtAgentGroupName").removeClass("validateerror");
        $('#txtAgentGroupOverdueHours').val("");
        $("#txtAgentGroupOverdueHours").removeClass("validateerror");
        $('#txtAgentGroupSortOrder').val("");
        $("#txtAgentGroupSortOrder").removeClass("validateerror");
        $('#chkAdministrator').prop("checked", false);
        $('#chkAdd').prop("checked", false);
        $('#chkModify').prop("checked", false);
        $('#chkDelete').prop("checked", false);
        $('#chkView').prop("checked", false);
        isValidation = 0;


    };


    this.Show = function (id) {

        if (id == 1) {
            $("#AddAgentGroup").hide();
            $("#ViewAgentGroup").show();

        }
        else {
            $("#ViewAgentGroup").hide();
            $("#AddAgentGroup").show();

        }
    };
    this.Validate = function () {

        if (isValidation == 1) {
            var _Error = 0;


            if ($('#txtAgentGroupCode').val().trim() == "") {
                $('#txtAgentGroupCode').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentGroupCode').removeClass("validateerror");
            }

            if ($('#txtAgentGroupName').val().trim() == "") {
                $('#txtAgentGroupName').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentGroupName').removeClass("validateerror");
            }

            if ($('#txtAgentGroupOverdueHours').val().trim() == "") {
                $('#txtAgentGroupOverdueHours').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAgentGroupOverdueHours').removeClass("validateerror");
            }

          

            return _Error;
        }

    }

    this.Submit = function () {

        isValidation = 1;
        if (this.Validate() <= 0) {

            ObjAgentGroup.Save();
        }
        else {

            return false;
        }
    };


    this.Save = function () {
        try {
            var ObjBlAgentGroup = {
                MasterID: $('#AgentGroupId').val() == '' ? '0' : $('#AgentGroupId').val(),
                AgentGroupCode: $('#txtAgentGroupCode').val().trim(),
                AgentGroupName: $('#txtAgentGroupName').val().trim(),
                AgentGroupOverdueHours: $('#txtAgentGroupOverdueHours').val().trim(),
                SortOrder: $('#txtAgentGroupSortOrder').val(),
                AggAdministrator: $('#chkAdministrator').is(":checked"),
                AggAdd: $('#chkAdd').is(":checked"),
                AggModify: $('#chkModify').is(":checked"),
                AggDelete: $('#chkDelete').is(":checked"),
                AggView: $('#chkView').is(":checked")

            };

            var DATA = JSON.stringify(ObjBlAgentGroup);
            $.ajax({
                url: api_url + '/AgentGroup/UpdateAgentGroup',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#AgentGroupId').val() == '' ? '0' : $('#AgentGroupId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtAgentGroupCode');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtAgentGroupCode');
                            }

                            ObjAgentGroup.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtAgentGroupCode');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateAgentGroup');

                }

            });
        }
        catch (e) {
            alert(e + '   : /AgentGroup/UpdateAgentGroup');
        }




    }


    this.FillGrid = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/AgentGroup/SelectAgentGroupAll",
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
                                          "<th style = 'display:none' width  = '10%' >ID_AgentGroup</th>" +
                                          //"<th style = 'display:none' width  = '10%' >ID_Department</th>" +
                                           "<th width  = '10%' >SlNo</th>" +
                                          "<th width  = '20%' >Code</th>" +
                                          "<th width  = '25%' >Name</th>" +
                                          "<th width  = '15%' >SortOrder</th>" +
                                          "</tr>" +
                                      "</thead>";

                            $.each(Mydata, function (key, val) {
                                var htmlActionTd = "<td>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjAgentGroup.FillAgentGroup(" + val.ID_AgentGroup + ")' class='edit'><i class='glyphicon glyphicon-edit'></i>" + "</a>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjAgentGroup.DeleteAgentGroup(" + val.ID_AgentGroup + ")' class='remove'><i class='glyphicon glyphicon-trash'></i>" + "</a>" +
                                                   "</td>";
                                html += "<tr>" +

                                            "<td style = 'display:none'>" + val.ID_AgentGroup + "</td>" +
                                            //"<td style = 'display:none'>" + val.FK_DefaultDepartment + "</td>" +
                                            "<td>" + val.SlNo + "</td>" +
                                            "<td>" + val.AggCode + "</td>" +
                                            "<td>" + val.AggName + "</td>" +
                                            "<td>" + val.SortOrder + "</td>" +
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
                                        "<li><a href ='javascript:void(0)' onclick = 'ObjAgentGroup.FillGrid(1)' class= '" + (parseInt(PageIndex) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>First</a></li>" +
                                   "<li><a href ='javascript:void(0)'  onclick = 'ObjAgentGroup.FillGrid(" + (parseInt(i) - parseInt(10)) + ")'   class= '" + (parseInt(i) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>«</a></li>"
                                    while (parseInt(i) <= parseInt(pageCount)) {
                                        html += "<li><a href ='javascript:void(0)' onclick = 'ObjAgentGroup.FillGrid(" + i + ")'  class='" + (parseInt(i) != parseInt(PageIndex) ? "activeAnchor" : "not-activeAnchorSelected") + "'   >" + i + "</a></li>"
                                        if (parseInt(i) % parseInt(10) == 0) {
                                            break;
                                        }
                                        i++;
                                    }
                                    html += "<li><a href ='javascript:void(0)' onclick = 'ObjAgentGroup.FillGrid(" + (parseInt(i) + parseInt(1)) + ")'   class= '" + ((parseInt(pageCount) - parseInt(PageIndex)) > 10 ? "activeAnchor" : "not-activeAnchor") + " ' >»</a></li>" +
                                    "<li><a href ='javascript:void(0)' onclick = 'ObjAgentGroup.FillGrid(" + pageCount + ")'   class= '" + (parseInt(PageIndex) < parseInt(pageCount) ? "activeAnchor" : "not-activeAnchor") + "'>Last</a></li>" +
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


    this.FillAgentGroup = function (ID_AgentGroup) {
        $.ajax({
            url: api_url + "/AgentGroup/FillAgentGroup",
            data: { 'ID_AgentGroup': ID_AgentGroup },
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlAgentGroup = value;
                            $('#AgentGroupId').val(ObjBlAgentGroup.ID_AgentGroup);
                            $('#txtAgentGroupOverdueHours').val(ObjBlAgentGroup.AggOverdueHours);
                            $('#txtAgentGroupCode').val(ObjBlAgentGroup.AggCode);
                            $('#txtAgentGroupName').val(ObjBlAgentGroup.AggName);
                            $('#txtAgentGroupSortOrder').val(ObjBlAgentGroup.SortOrder);

                            if (ObjBlAgentGroup.AggAdministrator == true) {
                                $('#chkAdministrator').prop("checked", true);
                            }
                            else {
                                $('#chkAdministrator').prop("checked", false);
                            }

                            if (ObjBlAgentGroup.AggAdd == true) {
                                $('#chkAdd').prop("checked", true);
                            }
                            else {
                                $('#chkAdd').prop("checked", false);
                            }

                            if (ObjBlAgentGroup.AggModify == true) {
                                $('#chkModify').prop("checked", true);
                            }
                            else {
                                $('#chkModify').prop("checked", false);
                            }

                            if (ObjBlAgentGroup.AggDelete == true) {
                                $('#chkDelete').prop("checked", true);
                            }
                            else {
                                $('#chkDelete').prop("checked", false);
                            }

                            if (ObjBlAgentGroup.AggView == true) {
                                $('#chkView').prop("checked", true);
                            }
                            else {
                                $('#chkView').prop("checked", false);
                            }
                       }
                        )
                    };
                    ObjAgentGroup.Show(2);
                }
                catch (e) {
                    alert(e + 'FillAgentGroup');
                }

            }
        });

    }

    this.DeleteAgentGroup = function (ID_AgentGroup) {
        if (confirm('Do you want to delete..?')) {
            $.ajax({
                url: api_url + "/AgentGroup/DeleteAgentGroup",
                data: { 'ID_AgentGroup': ID_AgentGroup },
                cache: false,
                type: 'Get',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var msg = "";
                    if (data.statusCode > 0) {
                        MessageText(data.statusCode, 'Deleted Successfully', '#txtAgentGroupCode');
                    }
                    else {
                        MessageText(data.statusCode, '', '#txtAgentGroupCode');
                    }
                    ObjAgentGroup.init();


                }
            });
        }


    }
}