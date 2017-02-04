<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LoginMasterPage.master" CodeFile="01_02_ChangePassword.aspx.cs" Inherits="_01_UserAuthentication_01_02_ChangePassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            //do stuff
        })

        function update() {
            var updatefield = $("#ContentPlaceHolder1_txtForgetUserName").val();
            var email = $("#txtForgetEmail").val();
            //var aall = "hh";
            alert(email);
            $.ajax({
                url: "../01_UserAuthentication/01_01_Default.aspx/GeneratePassword",
                type: "POST",

                contentType: "application/json",
                datatype: "json",
                data: JSON.stringify({ par: updatefield, par1: email }),
                success: function (data) {
                    alert("Email Has been sent successfully");
                    //new PNotify({
                    //    title: 'Branch updated',
                    //    text: 'Update user for same',
                    //    type: 'success'
                    //});
                },
                failure: function (response) {
                    alert(response.d);
                    alert("Please Check the user name and email");
                }
            });
        }



    </script>
    <div class="">
        <a class="hiddenanchor" id="toregister"></a>
        <div id="wrapper">
            <div id="login" class="animate form">
                <section class="login_content">
                    <form runat="server">
                        <h1>Change Password</h1>

                        <div>
                            <input type="text" runat="server" id="txtOTP" class="form-control" placeholder="OTP" required="" />
                        </div>
                        <div>
                            <input type="password" runat="server" id="txtPassword" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <input type="password" runat="server" id="txtConfirmPass" class="form-control" placeholder="Confirm Password" required="" />
                        </div>
                        <div>
                            <asp:Button runat="server" CssClass="btn btn-default submit" Text="Login" ID="btnLogin" OnClick="btnLogin_Click"  />

                            <a href="#toregister" class="to_register">Forgot Password? </a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="separator">

                            <p class="change_link">
                                New to site?                 
                            </p>
                            <div class="clearfix">
                                <label runat="server" id="txtError" class="label-danger"></label>
                            </div>
                            <br />
                            <div>
                                <h1><i class="fa" style="font-size: 26px;"></i>TechnoKraft Training And Solution</h1>
                                <p>©2015 All Rights Reserved.TechBona Softwares Privacy and Terms</p>
                            </div>
                        </div>
                    </form>
                    <!-- form -->
                </section>
                <!-- content -->
            </div>



        </div>
    </div>

</asp:Content>


