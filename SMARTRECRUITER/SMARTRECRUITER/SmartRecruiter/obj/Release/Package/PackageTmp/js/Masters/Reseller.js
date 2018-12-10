var objReseller = new Reseller();

function Reseller() {

    this.init = function () {
        try {
            this.Show(1);
            this.Clear();
            this.FillGrid();
        } catch (ex) {
            alert(ex + 'Initialise Reseller')

        }
    }
    this.Show = function (id) {

        if (id == 1) {
            $("#AddReseller").hide();
            $("#ViewReseller").show();

        }
        else {
            $("#ViewReseller").hide();
            $("#AddReseller").show();

        }
    };
    this.Clear = function () {

        $('#hfResellerId').val("");
        $('#txtResellerCode').val("");
        $("#txtResellerCode").removeClass("validateerror");
        $('#txtResellerName').val("");
        $("#txtResellerName").removeClass("validateerror");
        $('#txtAddress1').val("");
        $("#txtAddress1").removeClass("validateerror");
        $('#txtAddress2').val("");
        $("#txtAddress2").removeClass("validateerror");
        $('#txtEmail').val("");
        $("#txtEmail").removeClass("validateerror");
        $('#txtMobile').val("");
        $("#txtMobile").removeClass("validateerror");
        $('#txtPhone').val("");
        $("#txtPhone").removeClass("validateerror");
        $('#ddlReseller').val("0");
        $('#txtResellerSortOrder').val("");
        $("#txtResellerSortOrder").removeClass("validateerror");      
        $('#chkActive').prop("checked", true);
        isValidation = 0;
    };
    this.Validate = function () {

        if (isValidation == 1) {
            var _Error = 0;
            if ($('#txtResellerCode').val().trim() == "") {
                $('#txtResellerCode').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtResellerCode').removeClass("validateerror");
            }
            if ($('#txtResellerName').val().trim() == "") {
                $('#txtResellerName').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtResellerName').removeClass("validateerror");
            }
            if ($('#txtAddress1').val().trim() == "") {
                $('#txtAddress1').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAddress1').removeClass("validateerror");
            }
            if ($('#txtAddress2').val().trim() == "") {
                $('#txtAddress2').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtAddress2').removeClass("validateerror");
            }
            if ($('#txtEmail').val() == "" || CheckEmailSubmit('txtEmail')) {
                $('#txtEmail').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtEmail').removeClass("validateerror");
            }
            if ($('#txtMobile').val() == "" || CheckMobileNumberSubmit('txtMobile')) {
                $('#txtMobile').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtMobile').removeClass("validateerror");
            }
            if ($('#txtPhone').val() == "" || CheckMobileNumberSubmit('txtPhone')) {
                $('#txtPhone').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtPhone').removeClass("validateerror");
            }
            return _Error;
        }

    }
    this.Submit = function () {

        isValidation = 1;
        if (this.Validate() <= 0) {

            objReseller.Save();
        }
        else {

            return false;
        }
    };
    this.Save = function () {
        try {
            
          //  alert($('#chkActive').is(":checked"))
            var blReseller = {
                MasterID: $('#hfResellerId').val() == '' ? '0' : $('#hfResellerId').val(),
                ResCode: $('#txtResellerCode').val().trim(),
                ResName: $('#txtResellerName').val().trim(),
                ResAddress1: $('#txtAddress1').val().trim(),
                ResAddress2: $('#txtAddress2').val().trim(),
                ResEmail: $('#txtEmail').val(),
                ResMob: $('#txtMobile').val(),
                ResPhone: $('#txtPhone').val(),
                SortOrder: $('#txtResellerSortOrder').val(),
                Active: $('#chkActive').is(":checked")
            };

            var DATA = JSON.stringify(blReseller);
            $.ajax({
                url: api_url + '/Reseller/UpdateReseller',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {
                        if (data.statusCode > 0) {
                            if ($('#hfResellerId').val() == '' ? '0' : $('#hfResellerId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtResellerCode');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtResellerCode');
                            }

                            objReseller.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtResellerCode');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                }
                 ,

                error: function (request, status, error) {
                    alert(error + ' : UpdateReseller');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Reseller/UpdateReseller');
        }
    }
    this.FillGrid = function (PageIndex) {
        try {
            $.ajax({
                url: api_url + "/Reseller/SelectResellerAll",
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
                                          "<th style = 'display:none' width  = '10%' >ID_Reseller</th>" +
                                           "<th width  = '20%' >SlNo</th>" +
                                          "<th width  = '20%' >Code</th>" +
                                          "<th width  = '25%' >Name</th>" +
                                          "<th width  = '15%' >Email</th>" +
                                          "</tr>" +
                                      "</thead>";

                            $.each(Mydata, function (key, val) {
                                var htmlActionTd = "<td>" +
                                                   "<a href ='javascript:void(0)' onclick = 'objReseller.FillReseller(" + val.ID_Reseller + ")' class='edit'><i class='glyphicon glyphicon-edit'></i>" + "</a>" +
                                                   "<a href ='javascript:void(0)' onclick = 'objReseller.DeleteReseller(" + val.ID_Reseller + ")' class='remove'><i class='glyphicon glyphicon-trash'></i>" + "</a>" +
                                                   "</td>";
                                html += "<tr>" +

                                            "<td style = 'display:none'>" + val.ID_Reseller + "</td>" +
                                            "<td>" + val.SlNo + "</td>" +
                                            "<td>" + val.ResCode + "</td>" +
                                            "<td>" + val.ResName + "</td>" +
                                            "<td>" + val.ResEmail + "</td>" +
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
                                        "<li><a href ='javascript:void(0)' onclick = 'objReseller.FillGrid(1)' class= '" + (parseInt(PageIndex) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>First</a></li>" +
                                   "<li><a href ='javascript:void(0)'  onclick = 'objReseller.FillGrid(" + (parseInt(i) - parseInt(10)) + ")'   class= '" + (parseInt(i) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>«</a></li>"
                                    while (parseInt(i) <= parseInt(pageCount)) {
                                        html += "<li><a href ='javascript:void(0)' onclick = 'objReseller.FillGrid(" + i + ")'  class='" + (parseInt(i) != parseInt(PageIndex) ? "activeAnchor" : "not-activeAnchorSelected") + "'   >" + i + "</a></li>"
                                        if (parseInt(i) % parseInt(10) == 0) {
                                            break;
                                        }
                                        i++;
                                    }
                                    html += "<li><a href ='javascript:void(0)' onclick = 'objReseller.FillGrid(" + (parseInt(i) + parseInt(1)) + ")'   class= '" + ((parseInt(pageCount) - parseInt(PageIndex)) > 10 ? "activeAnchor" : "not-activeAnchor") + " ' >»</a></li>" +
                                    "<li><a href ='javascript:void(0)' onclick = 'objReseller.FillGrid(" + pageCount + ")'   class= '" + (parseInt(PageIndex) < parseInt(pageCount) ? "activeAnchor" : "not-activeAnchor") + "'>Last</a></li>" +
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
    this.FillReseller = function (ID_Reseller) {
        $.ajax({
            url: api_url + "/Reseller/FillReseller",
            data: { 'ID_Reseller': ID_Reseller },
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlReseller = value;
                            $('#hfResellerId').val(ObjBlReseller.ID_Reseller);
                            $('#txtResellerCode').val(ObjBlReseller.ResCode);
                            $('#txtResellerName').val(ObjBlReseller.ResName);
                            $('#txtAddress1').val(ObjBlReseller.ResAddress1);
                            $('#txtAddress2').val(ObjBlReseller.ResAddress2);
                            $('#txtEmail').val(ObjBlReseller.ResEmail);
                            $('#txtMobile').val(ObjBlReseller.ResMob);
                            $('#txtPhone').val(ObjBlReseller.ResPhone);
                            $('#txtResellerSortOrder').val(ObjBlReseller.SortOrder);
                            if (ObjBlReseller.Active == true) {
                                $('#chkActive').prop("checked", true);
                            }
                            else {
                                $('#chkActive').prop("checked", false);
                            }
                        }
                        )
                    };
                    objReseller.Show(2);
                }
                catch (e) {
                    alert(e + 'FillReseller');
                }

            }
        });

    }
    this.DeleteReseller = function (ID_Reseller) {
        if (confirm('Do you want to delete..?')) {
            $.ajax({
                url: api_url + "/Reseller/DeleteReseller",
                data: { 'ID_Reseller': ID_Reseller },
                cache: false,
                type: 'Get',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    if (data.statusCode > 0) {
                        MessageText(data.statusCode, 'Deleted Successfully', '#txtResellerCode');
                    }
                    else {
                        MessageText(data.statusCode, '', '#txtResellerCode');
                    }
                    objReseller.init();


                }
            });
        }


    }
}