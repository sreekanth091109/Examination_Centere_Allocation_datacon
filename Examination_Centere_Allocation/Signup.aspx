<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Examination_Centere_Allocation.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <title></title>
    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            const togglePassword = document.getElementById('togglePassword1');
            const passwordField = document.getElementById('txtPassword');
            togglePassword.addEventListener('click', function () {
                const type = passwordField.getAttribute('type');
                if (type === 'password') {
                    passwordField.setAttribute('type', 'text');
                } else {
                    passwordField.setAttribute('type', 'password');
                }
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            const togglePassword = document.getElementById('togglePassword2');
            const passwordField = document.getElementById('txtPassword1');
            togglePassword.addEventListener('click', function () {
                const type = passwordField.getAttribute('type');
                if (type === 'password') {
                    passwordField.setAttribute('type', 'text');
                } else {
                    passwordField.setAttribute('type', 'password');
                }
            });
        });
        function allowNumbersOnly(input) {
            input.value = input.value.replace(/\D/g, '');
            if (input.value.length > 10) {
                input.value = input.value.slice(0, 10);
            }
        } function validatePasswordStrength() {
            const passwordInput = document.getElementById("<%= txtPassword.ClientID %>");
            const messageLabel = document.getElementById("<%= lblMessage.ClientID %>");
            const password = passwordInput.value;

            if (password.length < 8) {
                messageLabel.textContent = "Contain 8 Character, Password week.";
                messageLabel.style.color = "red";
            } else if (!/[A-Z]/.test(password) || !/[a-z]/.test(password) || !/\d/.test(password) || !/[!@#$%^&*]/.test(password)) {
                messageLabel.textContent = "Weak password. Use upper, lower, numbers, and symbols.";
                messageLabel.style.color = "orange";
            } else {
                messageLabel.textContent = "Strong Password.";
                messageLabel.style.color = "green";
            }
        }
        function validatePasswordStrength1() {
            const passwordInput = document.getElementById("<%= txtpassword1.ClientID %>");
    const messageLabel = document.getElementById("<%= lblMessage1.ClientID %>");
            const password = passwordInput.value;

            if (password.length < 8) {
                messageLabel.textContent = "Contain 8 Character, Password week.";
                messageLabel.style.color = "red";
            } else if (!/[A-Z]/.test(password) || !/[a-z]/.test(password) || !/\d/.test(password) || !/[!@#$%^&*]/.test(password)) {
                messageLabel.textContent = "Weak password. Use upper, lower, numbers, and symbols.";
                messageLabel.style.color = "orange";
            } else {
                messageLabel.textContent = "Strong Password.";
                messageLabel.style.color = "green";
            }
        }
    </script>
    <style>
        .input-group {
            display: flex;
            align-items: center;
        }

        #togglePassword2 {
            background-color: transparent;
            border: none;
            cursor: pointer;
        }

            #togglePassword2 i {
                font-size: 1.2em;
            }

        #togglePassword1 {
            background-color: transparent;
            border: none;
            cursor: pointer;
        }

            #togglePassword1 i {
                font-size: 1.2em;
            }

        input, label {
            margin-top: -5px;
        }
    </style>
</head>
<body style="background-color: lightblue;">
    <form id="form1" runat="server" autocomplete="off">

        <div class="container">
            <div class="row justify-content-center mt-5 " style="width: 1500px;">
                <div class="col-md-4">
                    <div class="card p-4">
                        <h3 class="text-left text-decoration-underline text-black mb-4" style="font-weight: bold;">Sign Up</h3>

                        <label for="first" class="form-label" style="font-weight: bold; margin-top: -5px;" runat="server">First Name</label>
                        <asp:TextBox ID="firstname" runat="server" class="form-control rounded-2" oninput="this.value = this.value.toUpperCase();" placeholder="Enter your First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the First Name" ValidationGroup="validations" ControlToValidate="firstname"></asp:RequiredFieldValidator>

                        <label for="lastname" class="form-label" style="font-weight: bold; margin-top: -5px;" runat="server">Last Name</label>
                        <input type="text" class="form-control rounded-2" id="lastname" runat="server" oninput="this.value = this.value.toUpperCase();" placeholder="Enter your Last Name" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the Last Name" ValidationGroup="validations" ControlToValidate="lastname"></asp:RequiredFieldValidator>

                        <label for="username" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">User Name</label>
                        <input type="text" class="form-control rounded-2" runat="server" id="username" placeholder="Enter your User Name" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the User Name" ValidationGroup="validations" ControlToValidate="username"></asp:RequiredFieldValidator>

                        <label for="email" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">Email ID</label>
                        <input type="text" class="form-control rounded-2" runat="server" id="emailid" placeholder="Enter your email" />
                        <asp:Label ID="lblemail" runat="server" Text="Invalid e-mail format!" Visible="false" Height="5px" CssClass="text-danger" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the email" ValidationGroup="validations" ControlToValidate="emailid"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="emailid" ErrorMessage="Invalid email format!" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>

                        <label for="mobileno" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">Mobile Number</label>
                        <input type="text" class="form-control rounded-2" runat="server" id="mobileno" placeholder="Enter your Mobile Number" maxlength="10" oninput="allowNumbersOnly(this)" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the Mobile Number" ValidationGroup="validations" ControlToValidate="mobileno"></asp:RequiredFieldValidator>

                        <label for="password" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">Password</label>
                        <div class="input-group" style="width: 430px;">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="80%" oninput="validatePasswordStrength()" CssClass="form-control" Placeholder="Enter Password" />
                            <button type="button" id="togglePassword1" class="btn btn-outline-secondary">
                                <i class="fa fa-eye"></i>
                            </button>
                           <asp:Label ID="lblMessage" runat="server" Height="5px" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="form-validator mt-2" runat="server" ForeColor="Red" ErrorMessage="Enter the Password" ValidationGroup="validations" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>

                        <label for="cpassword" class="form-label" style="font-weight: bold; margin-top: -5px;" runat="server">Confirm Password</label>
                        <div class="input-group" style="width: 430px;">
                            <asp:TextBox ID="txtpassword1" runat="server" TextMode="Password" CssClass="form-control" oninput="validatePasswordStrength1()" Width="80%" Placeholder="Enter Confirm Password" />
                            <button type="button" id="togglePassword2" class="btn btn-outline-secondary">
                                <i class="fa fa-eye"></i>
                            </button>
                           <asp:Label ID="lblMessage1" runat="server" Height="5px" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="form-validator mt-2" runat="server" ForeColor="Red" ErrorMessage="Enter the Confirm Password" ValidationGroup="validations" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtpassword1"></asp:RequiredFieldValidator>

                        <button type="submit" runat="server" id="btnSignup" validationgroup="validations" onserverclick="btnSignup_ServerClick" onclick="" class="btn btn-primary mb-2 mt-2 w-25" style="font-weight: bold;">Sign Up</button>

                        <span class="border-bottom mt-1"></span>
                        <div class="text-center mt-3">
                            Already have an account?
                            <a href="#" onclick="window.location='Siginin.aspx';" class="text-primary small fw-bold">Login here</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
