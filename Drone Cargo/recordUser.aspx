<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recordUser.aspx.cs" Inherits="Drone_Cargo.recordUser" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<script>

   // window.alert("lblKayit");
</script>
<head runat="server">
    <title>Drone Cargo</title>

    <link href="/style.css" rel="stylesheet">
    
</head>
<body>
    <form id="droneForm" runat="server">
        <div id="wrapper">
            <header>
                <a href="/" class="logo">
                    DRONE CARGO 
                </a>
                <nav>
                    <ul>
                        <li>
                            <a href="recordUser.aspx">Sign Up</a>
                        </li>
                    </ul>
                </nav>

                <nav>
                    <ul>
                        <li>
                            <a href="about.aspx">About</a>
                        </li>
                    </ul>
                </nav>

            </header>

            <div class="banner"></div>
            <div class="content">
                <div class="signUp column">
                    <div class="contentTitle">
                        User Information
                    </div>
                    <div class="signUpForm">
                        <div class="recordUsername">
                            <span>* Username</span>
                            <asp:TextBox ID="text_rUsername" runat="server" />
                        </div>

                        <div class="recordName">
                            <span>* Name</span>
                            <asp:TextBox ID="text_rName" runat="server" />
                        </div>

                        <div class="recordSurame">
                            <span>* Surname</span>
                            <asp:TextBox ID="text_rSurname" runat="server" />
                        </div>

                        <div class="recordPassword">
                            <span>* Password</span>
                            <asp:TextBox ID="text_rPassword" runat="server" />
                        </div>


                         <div class="recordConfirmPassword">
                            <span>* Confirm Password</span>
                            <asp:TextBox ID="text_rConfirmPassword" runat="server"/>
                            <asp:Label ID="confirmLabel" runat="server" Text=""></asp:Label>

                        </div>



                    </div>
                </div>                
                <div class="shipment column">
                    <div class="contentTitle">
                        Adress Information
                    </div>
                    <div class="shipmentForm">

                        <div class="recordNumber">
                            <span>Your Phone Number</span>
                            <asp:TextBox ID="text_rPhoneNumber" runat="server"/>
                            <br />
                        </div>

                        <div class="recordAddress">
                            <span>Your Address</span>
                            <asp:TextBox ID="text_rAdress" runat="server" TextMode="MultiLine" Rows="10" />
                            <br />
                        </div>

                        <div class="recordShippingAddress1">
                            <span>Shipping Address - 1</span>
                            <asp:TextBox ID="text_rShippingAddress1" runat="server" TextMode="MultiLine" Rows="10" />
                            <br />
                        </div>

                        <div class="recordShippingAddress2">
                            <span>Shipping Address - 2</span>
                            <asp:TextBox ID="text_rShippingAddress2" runat="server" TextMode="MultiLine" Rows="10" />
                            <br />
                        </div> 
                       
                    </div>
                    

                </div>
                

                <div class="track column">
                    <div class="contentTitle">
                        Information
                    </div>

                    <div class="trackForm">
                        Username should not be used by someone else.
                        <br />
                        <br />
                        Username, Name, Surname and Password fields are required. <br />
                        <br />
                        Address It is not mandatory to fill in the information. However, you will be prompted for Address information when sending.<br />
                        <br />
                         <asp:Label ID="recordMessage" runat="server" Text=""></asp:Label>
                        <asp:Button ID="recordButton" Text="Sign Up" CssClass="btn recordButton" runat="server" OnClick="recordButton_Click" />
                    </div>

                </div>


             


            </div>

            <footer>
                Created by Drone Cargo Company - 2017
            </footer>
        </div>
    </form>
</body>
</html>
