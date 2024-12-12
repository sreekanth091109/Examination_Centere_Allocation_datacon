<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Siginin.aspx.cs" Inherits="Examination_Centere_Allocation.Siginin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <title></title>
    <style>
        /* Your content container */
        /*.content {
            text-align: center;*/ /* Optional, depending on your content */
        /*padding: 20px;
            border: 1px solid #000;
        }*/
    </style>
</head>

<body style="background-color: lightblue;">
    <form id="form1" runat="server" autocomplete="off">

        <div class="container">
            <div class="row justify-content-center mt-5 " style="width: 1500px;">
                <div class="col-md-4">
                    <div class="card p-4">
                        <h3 class="text-center mb-4" style="font-weight: bold;">Login</h3>

                        <div class="mb-3">
                            <label for="email" class="form-label" style="font-weight: bold;">User Name</label>
                            <input type="text" class="form-control" id="txtusername" runat="server" placeholder="Enter your email" />
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label" style="font-weight: bold;">Password</label>
                            <input type="password" class="form-control" id="password" runat="server" placeholder="Enter your password" />
                        </div>
                        <button type="submit" runat="server" id="btnSignin" onserverclick="btnSignin_ServerClick" class="btn btn-primary w-25" style="font-weight: bold;">Sign in</button>
                        <div class="text-left mt-3">
                            <a href="#" onclick="window.location='forgetpassword.aspx';" class="text-muted small">Forgot Password?</a>
                        </div>
                        <span class="border-bottom mt-1"></span>
                        <div class="mb-1">
                            <label for="password" style="font-weight: bold;" class="form-label">New user</label>
                        </div>
                        <button type="submit" class="btn btn-primary w-25" id="signup" runat="server" onserverclick="signup_ServerClick">Sign Up</button>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
