
var ObjUserProfile = new UserProfile();
var isValidation = 0;
function UserProfile() {

    this.init = function () {
        try {
            this.FillUserProfile();

        }
        catch (ex) {
            alert(ex + 'Initialize FillUserProfile')
        }
    };


    this.FillUserProfile = function () {
        $.ajax({
            url: api_url + "/Partial/PostreplayCount",
            cache: false,
            type: 'Get',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {

                try {
                    
                    var Mydata = JSON.parse(data);
                    if (Mydata.length > 0) {            
                        $.each(Mydata, function (key, value) {
                            
                            $('#UsprofileCode').val(Mydata[0].UsCode);
                            $('#ClientName').val(Mydata[0].ClientName);
                            $('#UsprofileName').val(Mydata[0].UsName);
                            $('#UsMobile').val(Mydata[0].UsMob);
                            $('#UsEmail').val(Mydata[0].Usemail);
                            $("#UsprofileCode").attr('disabled', 'disabled');
                            $("#UsprofileName").attr('disabled', 'disabled');
                            $("#UsMobile").attr('disabled', 'disabled');
                            $("#UsEmail").attr('disabled', 'disabled');
                            $("#ClientName").attr('disabled', 'disabled');
                           
                            var affiliateCode = Mydata[0].FullImage;
                            $('#userpropic').attr('src', $('#userpropic').attr('src') + affiliateCode);
                           
                        }
                        )
                    };

                }
                catch (e) {
                    alert(e + 'FillUserProfile');
                }

            }
        });

    }


}