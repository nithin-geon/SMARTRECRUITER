

var ObjStatus = new Status();
var isValidation = 0;
function Status() {



    this.init = function () {

        try {         
            this.Show(1);
            this.Clear();           
            this.FillGrid();
        }
        catch (ex) {
            alert(ex + 'Initialize Status')
        }
    };


    this.Clear = function () {

        $('#StatusId').val("");       
        $('#txtStatusCode').val("");
        $("#txtStatusCode").removeClass("validateerror");
        $('#txtStatusName').val("");
        $("#txtStatusName").removeClass("validateerror");
        $('#txtSortOrder').val("");
        $("#txtSortOrder").removeClass("validateerror");
        $('#chkActive').prop("checked", true);
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
            if ($('#txtStatusCode').val().trim() == "") {
                $('#txtStatusCode').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtStatusCode').removeClass("validateerror");
            }

            if ($('#txtStatusName').val().trim() == "") {
                $('#txtStatusName').addClass("validateerror");
                _Error++;
            }
            else {
                $('#txtStatusName').removeClass("validateerror");
            }
          
            return _Error;
        }

    }

    this.Submit = function () {
        isValidation = 1;
        if (this.Validate() <= 0) {
            ObjStatus.Save();
        }
        else {

            return false;
        }
    };


    this.Save = function () {
        try {
            var ObjBlStatus = {
                MasterID: $('#StatusId').val() == '' ? '0' : $('#StatusId').val(),             
                StatusCode: $('#txtStatusCode').val().trim(),
                StatusName: $('#txtStatusName').val().trim(),
                SortOrder: $('#txtSortOrder').val(),
                Active: $('#chkActive').is(":checked")
            };

            var DATA = JSON.stringify(ObjBlStatus);
            $.ajax({
                url: api_url + '/Status/UpdateStatus',
                cache: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: DATA,
                dataType: 'json',
                success: function (data) {
                    try {                                                                                               
                        if (data.statusCode > 0) {
                            if ($('#StatusId').val() == '' ? '0' : $('#StatusId').val() == 0) {
                                MessageText(data.statusCode, 'Saved Successfully', '#txtStatusCode');
                            }
                            else {
                                MessageText(data.statusCode, 'Updated Successfully', '#txtStatusCode');
                            }
                           
                            ObjStatus.init();
                        }
                        else {
                            MessageText(data.statusCode, '', '#txtStatusCode');
                        }
                    }
                    catch (ex) {
                        alert(ex + 'return issue');
                    }
                },
                error: function (error) {
                    alert(error + ' : UpdateStatus');

                }

            });
        }
        catch (e) {
            alert(e + '   : /Status/UpdateStatus');
        }




    }


    //this.LoadWarehouse = function () {
    //    $.ajax({
    //        url: api_url + "Configuration/GetAllWarehouse",
    //        dataType: "json",
    //        data: { "BranchId": user.BranchId, "Culture": culture },
    //        type: "get",
    //        success: function (data, status) {
    //            if (data.HttpStatusCode == 200 && data.StatusCode == 1) {
    //                if (data.resultList[0].DataTable.length > 0) {
    //                    var optionhtml = "<option value='0' >Select an Option</option>";
    //                    $.each(data.resultList[0].DataTable, function (i, value) {
    //                        optionhtml += '<option value=' + value.WarehouseId + '>' + value.WarehouseName + '</option>';
    //                    });
    //                    $("#ddlWarehouse").html(optionhtml);
    //                    $("#ddlWarehouse").trigger("chosen:updated");

    //                }
    //            }
    //        },

    //        error: function (request, textStatus, err) {
    //            // alerts(request.responseJSON.ExceptionMsg, "error");
    //        }

    //    })
    //};
    
    this.FillGrid = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/Status/SelectStatusAll",
                cache: false,
                type: "GET",
                data: { 'PageIndex': PageIndex, 'SearchItem': $('#txtSearch').val() },
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    try
                    {
                        var Mydata = JSON.parse(data);
                        var RecordCount = "0";
                        var html = "";
                        if (Mydata.length > 0) {

                            html += "<table width = '100%' id='example1' class='table table-bordered table-striped'>" +
                                      "<thead background-color='rgb(60, 141, 188)'>" +
                                          "<tr>" +
                                          "<th style = 'display:none' width  = '10%' >ID_Status</th>" +                                       
                                           "<th width  = '20%' >SlNo</th>" +
                                          "<th width  = '20%' >Code</th>" +
                                          "<th width  = '25%' >Name</th>" +
                                          "<th width  = '15%' >SortOrder</th>" +
                                          "</tr>" +
                                      "</thead>";

                            $.each(Mydata, function (key, val) {
                                var htmlActionTd = "<td>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjStatus.FillStatus(" + val.ID_Status + ")' class='edit'><i class='glyphicon glyphicon-edit'></i>" + "</a>" +
                                                   "<a href ='javascript:void(0)' onclick = 'ObjStatus.DeleteBranch(" + val.ID_Status + ")' class='remove'><i class='glyphicon glyphicon-trash'></i>" + "</a>" +
                                                   "</td>";
                                html += "<tr>" +

                                            "<td style = 'display:none'>" + val.ID_Status + "</td>" +                                           
                                            "<td>" + val.SlNo + "</td>" +
                                            "<td>" + val.StatusCode + "</td>" +
                                            "<td>" + val.StatusName + "</td>" +
                                            "<td>" + val.SortOrder + "</td>" +
                                            htmlActionTd +
                                            "</tr>";
                                RecordCount = val.RecordCount;

                            });
                          
                            try   //Page Indexing Starts here
                            {
                                var temppagecount = parseInt(RecordCount) / 10
                               
                                var pageCount = parseInt(Math.ceil(parseFloat(temppagecount)))
                                if (!PageIndex)
                                {
                                    PageIndex = 1;
                                }
                              
                                var i;
                              
                                if (parseInt(PageIndex) <= 10)
                                {
                                    i = 1;
                                }
                                else
                                {
                                   
                                    i = PageIndex;                                  
                                    var j = parseInt(i) % 10;                                   
                                    if (parseInt(j) == parseInt(0))
                                    {
                                        i = parseInt(i) - parseInt(9);                                      
                                    }
                                    else
                                    {
                                        i = (parseInt(i) - parseInt(j) + parseInt(1));                                       
                                    }
                                   
                                }
                              
                                if (parseInt(pageCount) > 0)
                                {                                   
                                    html += "</table><div class='box-footer clearfix'><ul class='pagination pagination-sm no-margin pull-right'>" +
                                        "<li><a href ='javascript:void(0)' onclick = 'ObjStatus.FillGrid(1)' class= '" + (parseInt(PageIndex) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>First</a></li>" +
                                   "<li><a href ='javascript:void(0)'  onclick = 'ObjStatus.FillGrid(" + (parseInt(i) - parseInt(10)) + ")'   class= '" + (parseInt(i) > parseInt(1) ? "activeAnchor" : "not-activeAnchor") + " '>«</a></li>"
                                    while (parseInt(i) <= parseInt(pageCount)) {
                                        html += "<li><a href ='javascript:void(0)' onclick = 'ObjStatus.FillGrid(" + i + ")'  class='" + (parseInt(i) != parseInt(PageIndex) ? "activeAnchor" : "not-activeAnchorSelected") + "'   >" + i + "</a></li>"
                                        if (parseInt(i) % parseInt(10) == 0) {
                                            break;
                                        }
                                        i++;
                                    }
                                    html += "<li><a href ='javascript:void(0)' onclick = 'ObjStatus.FillGrid(" + (parseInt(i) + parseInt(1)) + ")'   class= '" + ((parseInt(pageCount) - parseInt(PageIndex)) > 10 ? "activeAnchor" : "not-activeAnchor") + " ' >»</a></li>"+
                                    "<li><a href ='javascript:void(0)' onclick = 'ObjStatus.FillGrid(" + pageCount + ")'   class= '" + (parseInt(PageIndex) < parseInt(pageCount) ? "activeAnchor" : "not-activeAnchor") + "'>Last</a></li>" +
                                   "</ul></div>";

                                }
                            }   //Page Indexing Starts here
                            catch (er)
                            {
                                alert(er + 'Page Indexing');
                            }                          
                        }
                        $("#Grid").html(html);
                    }
                    catch (ex)
                    {
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


    this.FillStatus = function (ID_Status) {       
        $.ajax({
            url: api_url + "/Status/FillStatus",
            data: { 'ID_Status': ID_Status },
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                try {
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {
                        $.each(Mydata, function (key, value) {
                            var ObjBlStatus = value;
                            $('#StatusId').val(ObjBlStatus.ID_Status);                           
                            $('#txtStatusCode').val(ObjBlStatus.StatusCode);
                            $('#txtStatusName').val(ObjBlStatus.StatusName);
                            $('#txtSortOrder').val(ObjBlStatus.SortOrder);
                            if (ObjBlStatus.Active == true) {
                                $('#chkActive').prop("checked", true);
                            }
                            else {
                                $('#chkActive').prop("checked", false);
                            }
                        }
                        )
                    };
                    ObjStatus.Show(2);
                }
                catch (e) {
                    alert(e + 'FillStatus');
                }

            }
        });

    }

    this.DeleteBranch = function (ID_Status) {
        if (confirm('Do you want to delete..?')) {
            $.ajax({
                url: api_url + "/Status/DeleteStatus",
                data: { 'ID_Status': ID_Status },
                cache: false,
                type: 'Get',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {                                                        
                if (data.statusCode > 0) {                    
                    MessageText(data.statusCode, 'Deleted Successfully', '#txtStatusCode');  
                }
                else  {
                    MessageText(data.statusCode, '', '#txtStatusCode');
                }                   
                ObjStatus.init();


                }
            });
        } 
       

    }
}