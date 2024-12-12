<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section3.aspx.cs" Inherits="Examination_Centere_Allocation.section3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
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
            margin-bottom: -8px; /* Space between each radio button */
            display: block; /* Ensure each radio button is on its own line */
        }

            /* Additional styling for radio button text */
            .radio-button input[type="checkbox"] {
                margin-right: 10px; /* Add some space between radio button and label */
                margin-left: 5px;
                width: 15px;
                height: 15px;
                font-size: smaller;
            }
    </style>
    <div class="container-fluid">
        <div class="row ms-5">
            <div class="col-lg-12  justify-content-left">
                <asp:Label Text="Section 3: Building Information" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />
                <br />
                <asp:Label Text="Number of Floors:" runat="server" CssClass="fw-bold "></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span>
                <asp:DropDownList ID="floor1" runat="server" Width="280px" Height="30px" CssClass="ms-1 rounded-2 fw-bold">
                    <asp:ListItem Text="Select Exam Hall Type" Value="" Enabled="true" Selected="false" />
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" />
                    <asp:ListItem Text="6" Value="6" />
                    <asp:ListItem Text="7" Value="7" />
                    <asp:ListItem Text="8" Value="8" />
                    <asp:ListItem Text="9" Value="9" />
                    <asp:ListItem Text="10" Value="10" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="Floors" ValidationGroup="validations" runat="server" ControlToValidate="floor1" ErrorMessage="Select the number of floors" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />

                <asp:Label Text="Accessibility:<span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold"></asp:Label>
                <br />


                <asp:RadioButton ID="RadioButton1" runat="server" CssClass="ms-5 radio_butt" Text="Applicable" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="true" GroupName="AccessibilityGroup" />
                <asp:RadioButton ID="RadioButton2" runat="server" CssClass="ms-5 radio_butt" Text="Not Applicable" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="true" GroupName="AccessibilityGroup" />


                <asp:Label ID="lbaplicable" runat="server" Text="Please Check value " ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>

                <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="ms-5 radio-button fw-bold" Visible="false" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Ramps</asp:ListItem>
                    <asp:ListItem>Elevators</asp:ListItem>
                    <asp:ListItem>Physical Helpers</asp:ListItem>
                    <asp:ListItem>Wheel Chairs</asp:ListItem>
                    <asp:ListItem>Parking</asp:ListItem>
                    <asp:ListItem>Other Provisions</asp:ListItem>
                </asp:CheckBoxList>

                <asp:Label ID="lbapplicable" runat="server" Text="Please Select Accessibility " ForeColor="Red" Font-Bold="true" CssClass="ms-5" Visible="false"></asp:Label>

                <asp:TextBox ID="access1" runat="server" Visible="false" TextMode="MultiLine" Columns="30" CssClass="ms-5 mt-3 rounded-2" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
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
