<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section6.aspx.cs" Inherits="Examination_Centere_Allocation.section6" %>

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
            margin-bottom: -18px; /* Space between each radio button */
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

            /* Additional styling for radio button text */
            .radio-button input[type="checkbox"] {
                margin-right: 10px; /* Add some space between radio button and label */
                margin-left: 5px;
                width: 15px;
                height: 15px;
            }

        .space {
            padding-left: 30px;
        }
    </style>
    <script>
        function allowNumbersOnly(input) {
            // Use a regular expression to allow numbers only
            input.value = input.value.replace(/[^0-9.]/g, '');
        }
    </script>
    <div class="container-fluid">
        <div class="row ms-5">
            <div class="col-lg-12 col-md-12 col-sm-12 ms-5">
                <asp:Label Text="Section 6: Accessibility And Transport" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />

                <asp:Label Text="Parking Availability:" runat="server" CssClass="fw-bold "></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span><br />
                <asp:RadioButton ID="rb1" runat="server" Text="Available" CssClass="ms-lg-5 radio-button" OnCheckedChanged="rb1_CheckedChanged" AutoPostBack="true" GroupName="park" /><br />
                <asp:Label ID="parking1" runat="server" Text="Parking Space" CssClass="fw-bold ms-5 space" Visible="false"></asp:Label>
                <asp:CheckBoxList ID="checkpark" runat="server" Visible="false" CssClass="ms-5 radio-button mb-1 space">
                    <asp:ListItem Text="Examiners" Value="Examiners"></asp:ListItem>
                    <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                </asp:CheckBoxList>
                <asp:RadioButton ID="rb2" runat="server" Text="Not Available" CssClass="ms-lg-5 radio-button" OnCheckedChanged="rb2_CheckedChanged" AutoPostBack="true" GroupName="park" /><br />

                <asp:Label Text="Select Parking Availability" Width="200px" runat="server" ID="lbpark" Visible="false" CssClass="fw-bold" ForeColor="red" Font-Bold="true"></asp:Label><br />

                <asp:Label Text="Proximity to Transport:" runat="server" CssClass="fw-bold"></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span><br />
                <asp:RadioButton Text="Near by Railway Station" ID="rb3" runat="server" CssClass="ms-lg-5 radio-button" OnCheckedChanged="rb3_CheckedChanged" AutoPostBack="true" GroupName="Proximity" /><br />
                <asp:RadioButton Text="Near by Bus Stand" ID="rb4" runat="server" CssClass="ms-lg-5 radio-button" OnCheckedChanged="rb4_CheckedChanged" AutoPostBack="true" GroupName="Proximity" /><br />
                <asp:RadioButton Text="Others" ID="rb5" runat="server" CssClass="ms-lg-5 radio-button" OnCheckedChanged="rb5_CheckedChanged" AutoPostBack="true" GroupName="Proximity" /><br />
                <asp:Label Text="Select Proximity to Transport" Width="290px" runat="server" ID="lbproximity" Visible="false" CssClass="fw-bold" ForeColor="red" Font-Bold="true"></asp:Label><br />

                <asp:Label ID="lbl1" runat="server" Text="Name of Transport:" CssClass="fw-bold ms-1"></asp:Label>
                <asp:TextBox ID="transport" Columns="40" runat="server" CssClass="ms-1 rounded-2" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                <asp:RequiredFieldValidator ID="lbl1valid" ValidationGroup="validations" runat="server" ControlToValidate="transport" ErrorMessage="Enter the name of transport column" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>

                <asp:Label ID="lbl2" runat="server" Text="Distance(approx kms):" CssClass="fw-bold"></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span>
                <asp:TextBox ID="distance1" runat="server" CssClass="ms-1 rounded-2" oninput="allowNumbersOnly(this)"></asp:TextBox>
                <span style="color: blue; font-weight: bold">(kms)</span>
                <asp:RequiredFieldValidator ID="lbl2valid" ValidationGroup="validations" runat="server" ControlToValidate="distance1" ErrorMessage="Enter the distance column" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>

            </div>
        </div>
    </div>
    <hr />
    <div class="container-fluid ">

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
