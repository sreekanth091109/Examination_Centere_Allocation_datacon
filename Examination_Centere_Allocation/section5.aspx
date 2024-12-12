<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section5.aspx.cs" Inherits="Examination_Centere_Allocation.section5" %>

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
    <script>
        function handleClick() {
            // Get the label element by its client-side ID
            const label = document.getElementById('<%= options.ClientID %>');

            // Set the visibility of the label
            if (label) {
                label.style.display = 'none'; // Hide the label
            }

            console.log('Radio button clicked, label visibility set to false');
        }
    </script>
    <br />
    <div class="container-fluid">
        <div class="row ms-5">
            <div class="col-lg-6  justify-content-left ms-5">
                <asp:Label Text="Section 5: Security And Surveillance" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span><br />
                <br />
                <%--<asp:Label Text="Boundary Wall" runat="server" CssClass="fw-bold "></asp:Label>
                <asp:DropDownList ID="ddlbwall" runat="server" Width="280px" Height="30px" CssClass="ms-5"></asp:DropDownList>
                <asp:Label Text="Total Area" runat="server" CssClass="fw-bold ms-5"></asp:Label>
                <asp:TextBox ID="tblarea" runat="server"></asp:TextBox><br />
                <asp:RadioButton text="Open from One Side" ID="rdbone" runat="server" /><br />
                <asp:RadioButton text="Open from two Side" ID="rdbtwo" runat="server" /><br />
                <asp:RadioButton text="Open from three Side" ID="rdbthree" runat="server" /><br />
                <asp:RadioButton text="Open from four Side" ID="rdbfour" runat="server" /><br />
                <asp:Label Text="No Of Rooms" runat="server" CssClass="fw-bold"></asp:Label>
                <asp:DropDownList ID="ddlnoofrooms" runat="server" Width="280px" Height="30px" CssClass="ms-5"></asp:DropDownList>           
                <br />--%>


                <%-- H29-11-24--%>
                <fieldset class="mb-3">
                    <%--<b><legend class="col-form-label">CCTV Surveillance</legend></b>--%>
                    <b class="col-form-label">CCTV INSTALLED
                        <span class="require fw-bold" style="color: red;">*</span>
                    </b>

                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="options" id="option1" runat="server" onclick=" handleClick()">
                        <label class="form-check-label" for="option1" runat="server">Yes</label>
                    </div>

                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="options" id="option2" runat="server" value="option2" onclick=" handleClick()">
                        <label class="form-check-label" for="option2" runat="server">No</label>

                    </div>
                    <asp:Label Text="Please Select Option" Width="200px" Font-Bold="true" Visible="false" ID="options" runat="server" ForeColor="red"></asp:Label>
                </fieldset>


                <!-- Multiline Textbox -->
                <div class="mb-3">
                    <b>
                        <label for="message" class="form-label">Security Personnel</label></b>
                    <textarea class="form-control" id="message" runat="server" rows="4" placeholder="Enter your message here..." oninput="this.value = this.value.toUpperCase();"></textarea>
                    <asp:RequiredFieldValidator ID="message1" runat="server" ValidationGroup="validations" ControlToValidate="message" ErrorMessage="Enter the message textarea column" ForeColor="Red"></asp:RequiredFieldValidator><br />
                </div>
                <%--H29-11-24--%>
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
