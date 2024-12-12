<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section4.aspx.cs" Inherits="Examination_Centere_Allocation.section4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />


    <%--H29-11-24--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">

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
        /* Custom styling for checkboxes */
        .checkbox-list {
            margin-top: 20px;
        }

        /* Initially hide the textarea */
        #othersTextArea {
            display: none; /* Hidden by default */
        }

        .checkbox-list {
            margin-bottom: 8px; /* Space between each radio button */
            display: block; /* Ensure each radio button is on its own line */
        }

            /* Additional styling for radio button text */
            .checkbox-list input[type="checkbox"] {
                margin-right: 10px; /* Add some space between radio button and label */
                margin-left: 5px;
                width: 15px;
                height: 15px;
            }
    </style>
    <%--H29-11-24--%>
    <script type="text/javascript">
        function uncheckOthers(checkboxList) {
            var checkboxes = checkboxList.getElementsByTagName("input");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== event.target && checkboxes[i].type === "checkbox") {
                    checkboxes[i].checked = false;
                }
            }

        }


    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-6  justify-content-left">
                <asp:Label Text="Section 4: Facilities" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />

                <%--H29-11-24--%>
                <%--<div class="container mt-5">--%>
                <div class="row ms-5">
                    <!-- Electricity Section (Left) -->
                    <div class="col-md-6 col-sm-6 col-lg-6 col-6">
                        <div class="checkbox-list">
                            <asp:Label ID="elect1" runat="server" Text="Electricity:" CssClass="fw-bold fs-4"></asp:Label>
                            <span class="require fw-bold" style="color: red;">*</span>
                            <asp:CheckBoxList ID="electricity1" runat="server" CssClass="ms-5 checkbox-list" Style="margin-top: -3px" AutoPostBack="true" OnSelectedIndexChanged="electricity1_SelectedIndexChanged" onClick="uncheckOthers(this)">
                                <asp:ListItem Text="Available" Value="Available"></asp:ListItem>
                                <asp:ListItem Text="Not Available" Value="Not Available"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            </asp:CheckBoxList>

                            <asp:Label ID="lbelecteric" Visible="false" runat="server" CssClass="fw-bold ms-4" Text="Select Electricity" ForeColor="red"></asp:Label>
                            <asp:TextBox ID="electricity2" runat="server" Rows="3" Visible="false" TextMode="MultiLine" Columns="40" CssClass="rounded-2 ms-5" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Backup Power Supply Section (Right) -->
                    <div class="col-md-6">
                        <div class="checkbox-list">

                            <asp:Label ID="backup1" runat="server" Text="Backup Power Supply:" CssClass="fw-bold fs-4"></asp:Label>
                            <span class="require fw-bold" style="color: red;">*</span>
                            <asp:CheckBoxList ID="power" runat="server" CssClass="ms-5 checkbox-list" Style="margin-top: -3px" AutoPostBack="true" onClick="uncheckOthers(this)" OnSelectedIndexChanged="power_SelectedIndexChanged">
                                <asp:ListItem Text="Available" Value="Available"></asp:ListItem>
                                <asp:ListItem Text="Not Available" Value="Not Available"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="lbpower" Visible="false" runat="server" CssClass="fw-bold ms-4" Text="Select Power" ForeColor="red"></asp:Label>
                            <asp:TextBox ID="power1" runat="server" Rows="3" Visible="false" TextMode="MultiLine" Columns="40" CssClass="rounded-2 ms-5" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <!-- Drinking Water and Toilets Section (Side by Side) -->
                <div class="row mt-2">
                    <!-- Drinking Water Section (Left) -->
                    <div class="col-md-6 col-lg-6 col-sm-6 col-6 ms-5">
                        <div class="checkbox-list ">
                            <asp:Label ID="water1" runat="server" Text="Drinking Water:" CssClass="fw-bold fs-4"></asp:Label>
                            <span class="require fw-bold" style="color: red;">*</span>
                            <asp:CheckBoxList ID="check_water" runat="server" CssClass="ms-5 checkbox-list" Style="margin-top: -3px" AutoPostBack="true" onClick="uncheckOthers(this)" OnSelectedIndexChanged="check_water_SelectedIndexChanged">
                                <asp:ListItem Text="Available" Value="Available"></asp:ListItem>
                                <asp:ListItem Text="Not Available" Value="Not Available"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="lbwater" Visible="false" runat="server" CssClass="fw-bold ms-4" Text="Select Water" ForeColor="red"></asp:Label>
                            <asp:TextBox ID="txtwater" runat="server" Rows="3" Visible="false" TextMode="MultiLine" Columns="40" CssClass="rounded-2 ms-5" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Toilets Section (Right) -->
                    <div class="col-md-5 col-lg-5 col-sm-5 col-5">
                        <div class="checkbox-list">
                            <%--<h4>Toilets availability:</h4>--%>

                            <!-- Gender Radio Buttons -->
                            <asp:Label ID="toilet" runat="server" Text="Toilet Availability:" CssClass="fw-bold fs-4"></asp:Label>
                            <span class="require fw-bold" style="color: red;">*</span>
                            <asp:CheckBoxList ID="check_toilet" runat="server" CssClass="ms-5 checkbox-list" Style="margin-top: -3px" OnSelectedIndexChanged="check_toilet_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="lbtoilet" Visible="false" runat="server" CssClass="fw-bold ms-4" Text="Select Toilets" ForeColor="red"></asp:Label>
                        </div>
                    </div>
                </div>
                <!-- Bootstrap JS (optional, for additional Bootstrap functionality) -->
                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
                <%--H29-11-24--%>
                <br />
            </div>

            <hr />
            <div class="container-fluid">
                <div class="row ms-5 d-flex justify-content-center">
                    <div class="col-12 col-lg-12 d-flex justify-content-center">
                        <button type="submit" runat="server" style="height: 80px; width: 100px;" validationgroup="validation" id="btnSave" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white" onserverclick="btnSave_ServerClick">
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
