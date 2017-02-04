<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LoginMasterPage.master" CodeFile="01_01_Default.aspx.cs" Inherits="_01_UserAuthentication_01_01_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <a class="hiddenanchor" id="toregister"></a>
        <a class="hiddenanchor" id="tologin"></a>

        <div id="wrapper">
            <div id="login" class="animate form">
                <section class="login_content">
                    <form runat="server">
                        <h1>Login Form</h1>
                        <div>
                            <input id="txtUserName" runat="server" type="text" class="form-control" placeholder="Username" required="" />
                        </div>
                        <div>
                            <input type="password" runat="server" id="txtPassword" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <asp:Button runat="server" CssClass="btn btn-default submit" Text="Login" ID="btnLogin" OnClick="btnLogin_Click" />

                            <a href="#toregister" class="to_register">Forgot Password? </a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="separator">

                            <%--<p class="change_link">New to site?
              
              </p>--%>
                            <div class="clearfix">
                                <label runat="server" id="txtError" class="label-danger"></label>
                            </div>
                            <br />
                            <div>
                                <h1><i class="fa fa-pagelines" style="font-size: 26px;"></i>Watermelon Resort</h1>


                            </div>
                        </div>
                    </form>
                    <!-- form -->
                </section>
                <!-- content -->
            </div>
            <div id="register" class="animate form">
                <section class="login_content">
                    <form>
                        <h1>Enter Your Email</h1>
                        <div>
                            <input type="text" class="form-control" placeholder="Username" required="" />
                        </div>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <a class="btn btn-default" href="index.html">Submit</a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="separator">

                            <p class="change_link">
                                Already a member ?
               
                                <a href="#tologin" class="to_register">Log in </a>
                            </p>
                            <div class="clearfix"></div>
                            <br />
                            <div>
                                <h1><i class="fa fa-paw" style="font-size: 26px;"></i>Watermelon Resort</h1>

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

