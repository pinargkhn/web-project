<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Web.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>BusBooking | Register</title>
  <link rel="icon" href="../images/favicon-color.png"/>
  <link href='https://fonts.googleapis.com/css?family=Righteous' rel='stylesheet'/>
  <link rel="stylesheet" type="text/css" href="../css/register.css" />
</head>

<body>
  <div class="split left">
    <div class="centered">
     <a href="../Default.aspx"><img style= "width: 100%"; src="..\images\logo.png" alt="logo"/></a>
     <p style="color:white"; >Bus Booking</p>
    </div>
  </div>

  <div class="container">
    <div class="card">
      <h2>Register</h2>
      <form runat="server">
        <label for="username">Username</label>
        <input type="text" id="username" placeholder="Enter your username" runat="server"/>

        <label for="email">Email</label>
        <input type="email" id="email" placeholder="Enter your email" runat="server"/>

        <label for="new-password">New Password</label>
        <input type="password" id="newPassword" placeholder="Enter your new password" runat="server"/>

        <button type="submit" runat="server" onserverclick="RegisterSubmitButton">Register</button>
      </form>
      <div class="switch">Already have an account? <a href="logIn.aspx">Log in here</a></div>
    </div>
  </div>
</body>
</html>