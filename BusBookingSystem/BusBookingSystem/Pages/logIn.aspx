<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="Web.logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>BusBooking | Login</title>
  <link rel="icon" href="../images/favicon-color.png"/>
  <link href='https://fonts.googleapis.com/css?family=Righteous' rel='stylesheet'/>
  <link rel="stylesheet" type="text/css" href="../css/logIn.css" />
</head>

<body>
  <div class="split left">
    <div class="centered">
      <a href="index.aspx"><img style= "width: 100%"; src="..\images\logo.png" alt="logo"/></a>
      <p style="color:white"; >Bus Booking</p>
    </div>
  </div>

  <div class="container">
    <div class="card">
      <h2>Log In</h2>
      <form runat="server">
        <label for="username">Username</label>
        <input type="text" id="username" placeholder="Enter your username" runat="server"/>

        <label for="password">Password</label>
        <input type="password" id="password" placeholder="Enter your password" runat="server"/>

        <button type="submit" value="Submit" runat="server" onserverclick="LoginSubmitButton">Log In</button>
      </form>
      <div class="switch">Want to create an account? <a href="register.aspx">Register here</a></div>
    </div>
  </div>
</body>
</html>