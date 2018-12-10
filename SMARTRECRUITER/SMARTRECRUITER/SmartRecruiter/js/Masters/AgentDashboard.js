
var ObjAgentDashBoard = new AgentDashBoard();
var isValidation = 0;

function AgentDashBoard() {

    this.init = function () {

        try {
            this.FillDashBoard();
            this.SelectAgentDashBoard();
        }
        catch (ex) {
            alert(ex + 'Initialize AgentDashBoard')
        }
    };

    
    this.SelectAgentDashBoard = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/Recruiters/SelectRecruitersStatusCount",
                cache: false,
                type: "GET",
                data: {},
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    try {
                        var Mydata = JSON.parse(data.table);
                      
                        
                        if (Mydata.length > 0) {

                            $.each(Mydata, function (key, val) {
                                statusarray.push([val.StatusName, val.StatusCount]);  
                            });


                        }

                        var Mydata1 = JSON.parse(data.table1);                      
                        if (Mydata1.length > 0) {

                            $.each(Mydata1, function (key, val) {
                               
                                StatusNamearray.push([val.AgName]);
                                StatusCountarray.push([val.ProcessCount]);
                            });
                        }
                        var Mydata2 = JSON.parse(data.table2);
                        
                        var datevari = [];
                        var tempstats = '';
                        var jsonObj = {}; 
                        if (Mydata2.length > 0) {

                            $.each(Mydata2, function (key, val) {

                                if (tempstats === '')
                                {
                                    tempstats = val.StatusName;
                                }
                                else {
                                        if (tempstats !== val.StatusName)
                                        {
                                            periodarray.push({ name: tempstats, data: datevari });
                                            tempstats = val.StatusName;
                                            datevari = [];
                                        }
                                   }

                                            
                                
                               // alert(val.TransDate.substring(6, 10) + '' + val.TransDate.substring(3, 5) + '' + val.TransDate.substring(0, 2))
                                datevari.push([Date.UTC(val.TransDate.substring(6, 10), val.TransDate.substring(3, 5), val.TransDate.substring(0, 2)), val.StatusCount]);

                                

                            });
                            periodarray.push({ name: tempstats, data: datevari });
                        }


                        var Mydata3 = JSON.parse(data.table3);
                        if (Mydata2.length > 0) {
                            $.each(Mydata3, function (key, val) {

                                OpenRequest.push([val.OpenRequest]);
                                OpenCount.push([val.OpenCount]);
                                CloseCount.push([val.FillingCount]);
                                Joined.push([val.Joined]);
                                OverDuePositionReq.push([val.OverDue]);

                            });

                        }
                        
                       
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

    this.FillDashBoard = function (PageIndex) {

        try {
            $.ajax({
                url: api_url + "/Recruiters/SelectAgentDashBoard",
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
                                $('#OpenTkts').html(val.OpnTkts);
                                $('#PendingTkts').html(val.Tasks);
                                $('#ResolvedTkts').html(val.ResTickets);
                                $('#OverDueTkts').html(val.OverDueCount);
                                $('#AgentOverDueTkts').html(val.AgentOverDueCount); 
                                $('#TotalClosed').html(val.ClosedTickets)
                                $('#TotalAssigned').html(val.AssignedTickets)
                                $('#TotalTickets').html(val.TotalTickets)


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