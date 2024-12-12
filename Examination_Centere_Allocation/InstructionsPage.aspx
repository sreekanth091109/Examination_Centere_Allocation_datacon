<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructionsPage.aspx.cs" Inherits="Examination_Centere_Allocation.InstructionsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <title></title>
    <style>
        .border-circle {
            border: 5px solid #000; /* Add border around the circle */
            border-radius: 50%; /* This creates the circular shape */
            width: 500px; /* Set a fixed width */
            height: 500px; /* Set a fixed height (same as width for perfect circle) */
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .row {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .col-lg-12 {
            text-align: center; /* Center align the content inside the column */
        }

        btn-3d {
            background: linear-gradient(145deg, #007bff, #0056b3); /* 3D gradient effect */
            box-shadow: 4px 4px 10px rgba(0, 0, 0, 0.3), inset -2px -2px 5px rgba(255, 255, 255, 0.3);
            transition: transform 0.2s, box-shadow 0.2s;
            border: none; /* Remove any default border */
            color: white; /* Text color */
            font-weight: bold; /* Optional: Make the text bold */
        }

        /* Hover Effect */
        .btn-3d:hover {
            transform: translateY(-2px);
            box-shadow: 6px 6px 15px rgba(0, 0, 0, 0.4), inset -3px -3px 8px rgba(255, 255, 255, 0.5);
        }

        /* Active (Clicked) State */
        .btn-3d:active {
            transform: translateY(2px);
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.3), inset -1px -1px 3px rgba(255, 255, 255, 0.2);
        }
    </style>
</head>
<body style="background-color: lightblue">
    <form id="form1" runat="server">
        <div class="container-fluid d-flex justify-content-center mt-5">
            <div class="row d-flex justify-content-center rounded-circle border-circle"
                style="font-size: 50px; background: linear-gradient(to right, red, orange, yellow, blue);">
                <div class="col-lg-12 col-md-3 rounded-1">
                    <asp:Label runat="server" Text="Examination" CssClass="ms-5 fw-bold"></asp:Label><br />
                    <asp:Label runat="server" Text="Centre Allocation" CssClass="ms-1 fw-bold"></asp:Label><br />
                    <asp:Label runat="server" Text="BSEB,BIHAR" CssClass="border-5 fw-bold"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row well bg-l col-12 col-md-12 justify-content-center mt-2 ms-5  bg-light rounded-5">
                <div class=" text-decoration-underline">Important Instruction</div>
                <span class="" style="color: red; font-size: large; font: 200">1.The Prospective School(s)/Institute(s) aspirants are, therefore, cautioned not to fall 
                    prey to the designs of such unscrupulous elements who try to dupe the <>unsuspecting 
                    aspirants/ school/institutes for their personal gain. School/Institutes are 
                    advised to apply through BSEB, Patna Website (https://secondary.biharboardonline.com) only.</span>
                <span style="color: green; font: 200; font-size: large;">2.School(s)/Institute(s) in their own interest are advised not to 
                    wait till the last date and time to submit their Applications.
                     BSEB shall not be responsible if School(s)/Institute(s) are not able 
                    to submit their Applications due to the Last minute rush.
                </span>
                <span style="color: red; font: 200; font-size: large">3.Site best viewed at 1024x786 resolution in Chrome 50+
                </span>
                <span style="color: green; font: 200; font-size: large;">4.Delete the cache memory by pressing Ctrl and h key together (Ctrl+h)
                </span>
                <span style="color: red; font: 200; font-size: large;">5.Enable JavaScript in Internet Explorer, Mozilla, Firefox, Google Chrome
                </span>
                <span style="color: red; font: 200; font-size: large;">6.Disable popup blocker
                </span>
                <span>We would request you to please ensure that you have downloaded the latest 
                    version of the browsers and are initiating payments from the new browsers that
                     support TLS v 1.1 and v 1.2 onwards, else payment page will not open if 
                    redirected from your web-site from the browsers mentioned above.
                </span>
                <asp:Button ID="btnnext" runat="server" Text="Next" Width="100px" BackColor="Green" CssClass="btn btn-primary btn-3d rounded-3" OnClick="btnnext_Click" />
            </div>

        </div>

    </form>
</body>
</html>
