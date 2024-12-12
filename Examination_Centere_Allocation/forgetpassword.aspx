<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="Examination_Centere_Allocation.forgetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', (event) => {
            // Select the button and the password field
            const togglePassword = document.getElementById('togglePassword1');
            const passwordField = document.getElementById('txtnPassword');


            // Add a click event listener to the button
            togglePassword.addEventListener('click', function () {
                // Check the current type of the password field
                const type = passwordField.getAttribute('type');

                // Toggle the type attribute and the button text
                if (type === 'password') {
                    passwordField.setAttribute('type', 'text');
                    //this.textContent = 'Hide';
                } else {
                    passwordField.setAttribute('type', 'password');
                    //this.textContent = 'Show';
                }
            });
        });
        document.addEventListener('DOMContentLoaded', (event) => {
            // Select the button and the password field
            const togglePassword = document.getElementById('togglePassword2');
            const passwordField = document.getElementById('txtconfpassword1');


            // Add a click event listener to the button
            togglePassword.addEventListener('click', function () {
                // Check the current type of the password field
                const type = passwordField.getAttribute('type');

                // Toggle the type attribute and the button text
                if (type === 'password') {
                    passwordField.setAttribute('type', 'text');
                    //this.textContent = 'Hide';
                } else {
                    passwordField.setAttribute('type', 'password');
                    //this.textContent = 'Show';
                }
            });
        });
        function allowNumbersOnly(input) {
            input.value = input.value.replace(/\D/g, '');

            // If the input length exceeds 10 digits, truncate it to 10 digits
            if (input.value.length > 10) {
                input.value = input.value.slice(0, 10);
            }
        }
        function validatePasswordStrength() {
            const passwordInput = document.getElementById("<%= txtnPassword.ClientID %>");
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
            const passwordInput = document.getElementById("<%= txtconfpassword1.ClientID %>");
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
                        <h3 class="text-left text-decoration-underline text-black mb-4" style="font-weight: bold;">Forgot Password</h3>

                        <label for="Mobileno" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">Mobile Number</label>
                        <input type="text" class="form-control rounded-2" runat="server" id="Mobileno" placeholder="Enter your Mobile Number" maxlength="10" oninput="allowNumbersOnly(this);" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="form-validator" runat="server" ForeColor="Red" ErrorMessage="Enter the Mobile Number" ValidationGroup="validations" ControlToValidate="Mobileno"></asp:RequiredFieldValidator>

                        <label for="npassword" class="form-label" runat="server" style="font-weight: bold; margin-top: -5px;">New Password</label>
                        <div class="input-group" style="width: 430px;">
                            <asp:TextBox ID="txtnPassword" runat="server" TextMode="Password" Width="80%" oninput="validatePasswordStrength()" CssClass="form-control" Placeholder="Enter Password" />
                            <button type="button" id="togglePassword1" class="btn btn-outline-secondary">
                                <i class="fa fa-eye"></i>
                            </button>
                        </div>
                        <asp:Label ID="lblMessage" runat="server" Height="5px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="form-validator mt-2" runat="server" ForeColor="Red" ErrorMessage="Enter the New Password" ValidationGroup="validations" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtnPassword"></asp:RequiredFieldValidator>

                        <label for="cpassword" class="form-label" style="font-weight: bold; margin-top: -5px;" runat="server">Confirm Password</label>
                        <div class="input-group" style="width: 430px;">
                            <asp:TextBox ID="txtconfpassword1" runat="server" TextMode="Password" CssClass="form-control" oninput="validatePasswordStrength1()" Width="80%" Placeholder="Enter Confirm Password" />
                            <button type="button" id="togglePassword2" class="btn btn-outline-secondary">
                                <i class="fa fa-eye"></i>
                            </button>
                        </div>
                        <asp:Label ID="lblMessage1" runat="server" Height="5px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="form-validator mt-2" runat="server" ForeColor="Red" ErrorMessage="Enter the Confirm Password" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ValidationGroup="validations" ControlToValidate="txtconfpassword1"></asp:RequiredFieldValidator>


                        <button type="submit" runat="server" id="btnsubmit" validationgroup="validations" onserverclick="btnsubmit_ServerClick" class="btn btn-primary mb-2 mt-2 w-25 fw-bold">Submit</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
