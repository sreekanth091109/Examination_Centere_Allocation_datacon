<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section7.aspx.cs" Inherits="Examination_Centere_Allocation.section7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
 <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
 <style>
     .form-validator {
         font-size: calc(0.5vw + 4px);
         /* Adjust size based on viewport width*/
     }
 </style>
 <script>
     // Manually trigger the modal to stay open
     document.getElementById('Button3').addEventListener('click', function (event) {
         // Prevent form submission or other actions that could close the modal
         event.preventDefault();

         // Create a new Bootstrap modal instance and show the modal
         var myModal = new bootstrap.Modal(document.getElementById('myModal'));
         myModal.show();
     });

     // Optional: Prevent modal from closing when clicked outside or by pressing escape
     var modalElement = document.getElementById('myModal');
     modalElement.addEventListener('hidden.bs.modal', function (event) {
         // Handle any actions when the modal is closed (if needed)
         console.log('Modal closed');
     });

     // Optional: Manually close the modal if needed
     function closeModal() {
         var myModal = new bootstrap.Modal(document.getElementById('myModal'));
         myModal.hide();
     }
 </script>
    <style>
        .radio-button {
            margin-bottom: 8px; /* Space between each radio button */
            display: block; /* Ensure each radio button is on its own line */
        }

            /* Additional styling for radio button text */
            .radio-button input[type="radio"] {
                margin-right: 10px; /* Add some space between radio button and label */
                margin-left: 5px;
                width: 15px;
                height: 15px;
                font-size: smaller;
            }

        .space {
            padding-left: 30px;
        }

        .space1 {
            margin-left: 31px;
        }
    </style>
    <script>
        function allowNumbersOnly(input) {
            // Use a regular expression to allow numbers only
            input.value = input.value.replace(/[^0-9]/g, '');
        }

        function handleSave() {
            // Check if Section 7 is being saved
            let currentSection = 7; // Example: Pass this dynamically in a real application

            if (currentSection === 7) {
                let progressBar = document.getElementById("progress - bar - container");

                // Gradually fill the progress bar
                let width = 0;
                let interval = setInterval(() => {
                    if (width >= 100) {
                        clearInterval(interval); // Stop when full
                        alert("Progress Complete!");
                    } else {
                        width++;
                        progressBar.style.width = width + "%";
                    }
                }, 20); // Adjust speed by changing the interval time
            } else {
                alert("Save functionality works only for Section 7!");
            }

    </script>
    <br />

    <div class="container-fluid">
        <div class="row ms-5">
            <div class="col-lg-5 col-md-5 col-sm-5  justify-content-left ms-5">
                <asp:Label Text="Section 7: Additional Information" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />
                <br />
                <div class="container border">
                    <div class="mt-2">
                        <asp:Label Text="Examination Hall Type:" runat="server" CssClass="fw-bold"></asp:Label>
                        <span class="require fw-bold" style="color: red;">*</span>
                        <asp:DropDownList ID="ddlbwall" runat="server" Width="280px" Height="30px" CssClass="ms-1 rounded-2">
                            <asp:ListItem Text="Select Exam Hall Type" Value="" Enabled="true" Selected="false" />
                            <asp:ListItem Text="Class Room" Value="ClassRoom" />
                            <asp:ListItem Text="Class Room/Auditorium" Value="ClassRoom/" />
                            <asp:ListItem Text="Open Space/Auditorium" Value="OpenSpace" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="Exam_hall_type" Font-Bold="true" ValidationGroup="validations" runat="server" ControlToValidate="ddlbwall" InitialValue="" ErrorMessage="Select the examination hall type" ForeColor="Red" Display="Dynamic" /><br />
                        <br />

                        <asp:Label Text="Emergency Exits:<span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold"></asp:Label>
                        <asp:RadioButton ID="exrb1" runat="server" Text="Available" class="ms-5 radio-button" OnCheckedChanged="exrb1_CheckedChanged" AutoPostBack="true" GroupName="exitsGroup" />
                        <asp:Label ID="emergency" runat="server" Text="How many emergency exits are there?" CssClass="fw-bold ms-5  mt-5" Visible="false"></asp:Label>

                        <asp:TextBox ID="txtemergency" runat="server" Visible="false" Width="120px" CssClass="rounded-2" oninput="allowNumbersOnly(this)"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Visible="false" ValidationGroup="validations" runat="server" ControlToValidate="txtemergency" Font-Bold="true" ErrorMessage="Select No of Exits" ForeColor="Red" Display="Dynamic" />

                        <asp:TextBox ID="etext1" CssClass=" ms-5  rounded-2 mt-2" runat="server" TextMode="MultiLine" oninput="this.value = this.value.toUpperCase();"
                            Visible="false" Rows="4" Columns="56"></asp:TextBox>
                        <asp:RadioButton ID="exrb2" runat="server" Text="Not Available" class="ms-5 radio-button" OnCheckedChanged="exrb2_CheckedChanged" AutoPostBack="true" GroupName="exitsGroup" />
                        <%--<asp:Label Text="Select Value " runat="server" ForeColor="Red"" Visible="false" ID="lbemergency1" CssClass="fw-bold"></asp:Label>--%>

                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
     <hr />
 <div class="container-fluid">

     <div class="row ms-5 d-flex justify-content-center">
         <div class="col-12 col-lg-12 d-flex justify-content-center">
             <button type="submit" runat="server" validationgroup="validations" style="height: 80px; width: 100px;" id="btnSave" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white" onserverclick="btnSave_ServerClick">
                 <i class="fas fa-save fa-2x text-primary"></i>
                 <br />
                 Save
             </button>
             <button type="submit" runat="server" id="Button1" style="height: 80px; width: 100px;" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white">
                 <i class="fas fa-file-alt folded fa-2x" style="color: darkturquoise"></i>
                 <br />
                 Submit
             </button>
             <button type="submit" runat="server" id="Button2" style="height: 80px; width: 100px;" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white" onserverclick="Button2_ServerClick">
                 <i class="fa-solid fa-arrows-rotate fa-2x text-success"></i>
                 <br />
                 Clear
             </button>
                        <button type="button" runat="server" id="Button4"
                style="height: 80px; width: 100px;"
                class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white"
                data-bs-toggle="modal"
                data-bs-target="#myModal">
                <i class="fa-solid fa-eraser fa-2x" style="color: forestgreen"></i>Preview

            </button>

        </div>
    </div>
</div>
<div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h5 class="modal-title" id="myModalLabel">Modal Heading</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">
                If You Want Preview Click Yes...!
<div class="mt-5 ms-5 d-flex align-content-center">
    <button type="button" style="width: 110px" class="btn btn-primary" runat="server" onserverclick="yes_ServerClick">Yes</button>
    &nbsp &nbsp &nbsp &nbsp
      <button type="button" style="width: 110px" runat="server" onserverclick="no_ServerClick" class="btn btn-danger">No</button>
</div>
            </div>

            <!-- Modal footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
            </div>

        </div>
    </div>
</div>
</asp:Content>
