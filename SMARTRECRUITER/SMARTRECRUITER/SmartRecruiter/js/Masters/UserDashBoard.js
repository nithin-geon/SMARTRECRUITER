
var ObjUsertDashBoard = new UserDashBoard();
var isValidation = 0;
function UserDashBoard() {

    this.init = function () {

        try {
            this.FillDashBoard();
        }
        catch (ex) {
            alert(ex + 'Initialize UserDashBoard')
        }
    };

    this.FillDashBoard = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/UserDashboard/SelectUserDashBoard",
                cache: false,
                type: "GET",
                data: { },
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    try {
                        var Mydata = JSON.parse(data);
                        var RecordCount = "0";
                        var html = "";
                        if (Mydata.length > 0) {

                            $.each(Mydata, function (key, val) {
                                $("#OpenTkts").html(val.OpenTickets);
                                //$('#MyTickets').html(val.MyTickets);
                                $('#Unseen').html(val.Unseen);
                                $('#ResolvedTickets').html(val.ResolvedTickets);
                                $('#ClosedTickets').html(val.ClosedTickets);

                            });
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
}