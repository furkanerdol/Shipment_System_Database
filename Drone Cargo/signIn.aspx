<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="Drone_Cargo.signIn" %>

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
                            <a href="recordUser.aspx">Record Me</a>
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
                 <div runat="server" id="signup" class="signUp column">
                    <div class="contentTitle">
                        Welcome<br />
                    </div>
                    <div class="signUpForm">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ButtonSignOut" runat="server" CssClass="btn btnKayit3" OnClick="ButtonSignOut_Click" Text="Sign Out" />
                    </div>
                </div>
                <div class="shipment column">
                    <div class="contentTitle">
                        Create a Shipment
                    </div>

                    <div class="shipmentForm">
                        <div class="name-surname">
                            <span>Name</span>
                            <asp:TextBox ID="txtName" runat="server" />
                        </div>
                        <div class="name-surname">
                            <span>Surname</span>
                            <asp:TextBox ID="txtSurname" runat="server" />
                        </div>

                        <div class="phoneNumber">
                            <span>Phone Number</span>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" />
                        </div>
                        <div class="address">
                            <span>Address</span>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="10" />
                        </div>

                        <div class="name-surname">
                            <span>Receiver Name</span>
                            <asp:TextBox ID="txtReceiverName" runat="server" />
                        </div>
                        <div class="name-surname">
                            <span>Receiver Surname</span>
                            <asp:TextBox ID="txtReceiverSurname" runat="server" />
                        </div>

                        <div class="phoneNumber">
                            <span>Receiver Phone Number</span>
                            <asp:TextBox ID="txtReceiverPhoneNum" runat="server" />
                        </div>
                        <div class="address">
                            <span>Destination Address</span>
                            <asp:TextBox ID="txtDestinationAddress" runat="server" TextMode="MultiLine" Rows="10" />
                        </div>

                        <div class="weightOfCargo">
                            <span>Weight of Cargo</span>
                            <asp:TextBox ID="txtWeightOfCargo" runat="server" />
                        </div>
                        <asp:Button ID="Button2" Text="Ship" CssClass="btn btnKayit2" runat="server" OnClick="btn2_Click" />
                    </div>
                </div>
                <div class="track column">
                    <div class="contentTitle">
                        Track Your Shipment
                    </div>

                    <div class="trackForm">
                        <div class="gonderi">
                            Tracking Number&nbsp;
                            <asp:TextBox ID="txtSorgu" runat="server" />
                        </div>

                        <asp:Button ID="Button3" Text="Shipment Inquiry" CssClass="btn btnKayit3" runat="server" OnClick="Button3_Click" />
                        <br />
                        <asp:TextBox ID="CargoText" runat="server" TextMode="MultiLine" Rows="20" />


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
