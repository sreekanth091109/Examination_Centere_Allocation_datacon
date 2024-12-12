<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section2.aspx.cs" Inherits="Examination_Centere_Allocation.section2" %>

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
        /* Custom Border Style */
        .border-custom {
            border: 2px solid black; /* Blue border */
            padding: 2px; /* Padding around the container */
            border-radius: 10px; /* Optional rounded corners */
            margin-left: 10px;
            background-color: #f8f9fa; /* Light background color */
        }

        /* Add space between the radio buttons and their labels */
        .radio-button {
            margin-bottom: -8px; /* Space between each radio button */
            display: block; /* Ensure each radio button is on its own line */
        }

            /* Additional styling for radio button text */
            .radio-button input[type="radio"] {
                margin-right: 5px; /* Add some space between radio button and label */
                margin-left: 20px;
                width: 25px;
                height: 15px;
            }
    </style>
    <%--   Gridview control--%>
    <style>
        /* Custom CSS to ensure the GridView is centered */
        .container-center {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh; /* Full viewport height */
        }
    </style>
    <%--   Gridview control--%>
    <style>
        /* Custom CSS for ensuring responsive design */
        .container-start {
            display: flex;
            justify-content: center;
            align-items: flex-start;
            flex-direction: column;
            padding: 20px;
        }

        .custom-border-radius {
            border-radius: 15px; /* Rounds all corners with 15px radius */
        }


        /* Responsive design for the grid container */
        .grid-container {
            width: 100%;
            max-width: 1200px;
            border-radius: 10px;
            border: 3px solid black;
        }

        /* Adding some space between grid columns and rows */
        .form-control {
            margin-bottom: 10px; /* Space between textboxes */
        }

        /* Custom Table styling for GridView */
        .table {
            width: 100%;
            table-layout: fixed;
            margin-top: 10px;
        }

        /* Making sure the GridView columns are responsive */
        @media (max-width: 768px) {
            .table th, .table td {
                font-size: 12px; /* Adjust font size on smaller screens */
            }
        }

        .btn-hover-effect:hover {
            background-color: #007bff;
            color: #fff;
            box-shadow: 0px 4px 15px rgba(0, 123, 255, 0.4);
        }
    </style>
    <script>
        function allowNumbersOnly1(input) {
            // Use a regular expression to allow numbers only
            input.value = input.value.replace(/[^0-9]/g, '');
        }
        function allowNumbersOnly(input) {
            // Use a regular expression to allow numbers only
            input.value = input.value.replace(/[^0-9-]/g, '');
        }
        function allowNumbersOnly2(input) {
            // Use a regular expression to allow numbers only
            input.value = input.value.replace(/[^0-9.]/g, '');
        }
    </script>
    <br />
    <div class="container-fluid ">
        <div class="row ms-4">
            <!-- Section heading -->
            <div class="col-12 ms-5">
                <asp:Label Text="Section 2: Physical Attributes" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />
                <br />
            </div>
        </div>
        <!-- First row with Boundary Wall and Total Area controls side by side -->

        <div class="row ms-4">
            <!-- Boundary Wall Label and DropDownList side by side -->

            <div class="col-lg-12 col-md-12 justify-content-left ms-5">
                <asp:Label
                    runat="server"
                    CssClass="fw-bold me-2"
                    Text="Boundary Wall <span class='require fw-bold' style='color: red;'>*</span>">
                </asp:Label>
                <asp:DropDownList ID="ddlbwall" runat="server" Width="20%" Font-Bold="true" Height="40px" CssClass="ms-2 rounded-2 ">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Needs Repair</asp:ListItem>
                    <asp:ListItem>Not Present</asp:ListItem>
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" InitialValue="Select" ErrorMessage="SelectBoundary wall" ValidationGroup="validations" ControlToValidate="ddlbwall"></asp:RequiredFieldValidator>



                <asp:Label Text="Total Area <span class='require fw-bold' style='color: red;'>*</span>" Width="100px" runat="server" CssClass="fw-bold me-2"> 
                </asp:Label>

                <asp:TextBox ID="tblarea" runat="server" Height="40px" Font-Bold="true" placeholder="Input for the total area(in Square meters)" oninput="allowNumbersOnly2(this)" CssClass="ms-2 rounded-2 w-30" Width="20%"></asp:TextBox>
                <asp:Label Text="(Square meters/acres)" Width="190px" ForeColor="Blue" runat="server" CssClass="fw-bold me-2"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Area  Square" ValidationGroup="validations" ControlToValidate="tblarea"></asp:RequiredFieldValidator>




            </div>

        </div>
        <div class="container-fluid ms-5" width="550px">
            <div class="row ms-5 mt-3">
                <!-- Boundary Wall Label and DropDownList side by side -->
                <!-- Make sure the radio buttons are wrapped within a container (e.g., div) to keep the layout intact -->
                <div class=" col-sm-4 col-md-4 col-lg-4 ms-5">
                    <div class="border-custom ms-5">
                        <!-- Radio Buttons with the same GroupName to ensure they are mutually exclusive -->
                        <asp:RadioButton Text="Open from One Side" ID="rdbone" runat="server" CssClass="radio-button" GroupName="doorOpening" OnCheckedChanged="rdbone_CheckedChanged" AutoPostBack="true" /><br />
                        <asp:RadioButton Text="Open from Two Side" ID="rdbtwo" runat="server" CssClass="radio-button" GroupName="doorOpening" OnCheckedChanged="rdbtwo_CheckedChanged" AutoPostBack="true" /><br />
                        <asp:RadioButton Text="Open from Three Side" ID="rdbthree" runat="server" CssClass="radio-button" GroupName="doorOpening" OnCheckedChanged="rdbthree_CheckedChanged" AutoPostBack="true" /><br />
                        <asp:RadioButton Text="Examination room is next to the road" ID="rdbfour" runat="server" CssClass="radio-button" GroupName="doorOpening" OnCheckedChanged="rdbfour_CheckedChanged" AutoPostBack="true" /><br />
                        <asp:Label Text="Please Select one" Width="150px" runat="server" ID="lbselect" Visible="false" ForeColor="Red" Font-Bold="true" CssClass="fw-bold me-2 ms-5"></asp:Label>
                    </div>
                </div>
                <div class="col-4 col-lg-4 col-md-4 col-sm-4 mt-5">
                    <!-- Labels -->
                    <asp:Label runat="server" ID="lbboundery" Text="boundry wall" Font-Bold="true" Visible="false" ForeColor="Green" CssClass="fw-bold me-2 mt-5  fs-5"></asp:Label>
                </div>

            </div>

        </div>


    </div>
 <div class="row">
     <div class="col-12 col-md-12 col-lg-12 col-sm-12 mt-3 ms-5">
         <div class="d-flex align-items-center mb-3">
             <div class="container-fluid">
                 <div class="row">
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="Number Of Rooms <span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold ms-4"></asp:Label><br />
                         <asp:TextBox ID="txtnorooms" runat="server" Height="40px" Width="180px" Font-Bold="true"  placeholder="Enter total No of Rooms" CssClass=" rounded-2 ms-4" oninput="allowNumbersOnly1(this)" ValidationGroup="validations"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Number of Rooms" ValidationGroup="validations" ControlToValidate="txtnorooms"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-12  col-lg-2 col-sm-12">
                         <asp:Label Text="Capacity of room <span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold me-2 ms-4"></asp:Label><br />
                         <asp:TextBox ID="capacity" runat="server" Height="40px" Width="180px" Font-Bold="true"  OnTextChanged="capacity_TextChanged" placeholder="Enter Capacity" CssClass=" rounded-2 ms-3" oninput="allowNumbersOnly1(this)" ValidationGroup="validations"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Enter Capacity" ValidationGroup="validations" ControlToValidate="capacity"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="Sitting Allocation <span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold me-2 ms-4"></asp:Label><br />
                         <asp:TextBox ID="allocation" runat="server" Height="40px" Width="180px" Font-Bold="true"  placeholder="Enter total No of Rooms" CssClass=" rounded-2 ms-3" oninput="allowNumbersOnly(this)" ValidationGroup="validations"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Enter the sitting allocation" ValidationGroup="validations" ControlToValidate="allocation"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="No Of Desks <span class='require fw-bold' style='color: red;'>*</span>" runat="server" OnTextChanged="txtnorooms_TextChanged" CssClass="fw-bold me-2 ms-4"></asp:Label><br />
                         <asp:TextBox ID="desks" runat="server" Height="40px" Width="180px" Font-Bold="true"  placeholder="Enter total No of Rooms" CssClass="rounded-2 ms-3" oninput="allowNumbersOnly1(this)" ValidationGroup="validations"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Enter the No od Desk" ValidationGroup="validations" ControlToValidate="desks"></asp:RequiredFieldValidator>

                     </div>
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="No Of Tables <span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold me-2 ms-4"></asp:Label><br />
                         <asp:TextBox ID="tables" runat="server" Height="40px" Width="180px" Font-Bold="true"  placeholder="Enter total No of Rooms" CssClass=" rounded-2 ms-3 " oninput="allowNumbersOnly1(this)" ValidationGroup="validations"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Enter the No of Tables" ValidationGroup="validations" ControlToValidate="tables"></asp:RequiredFieldValidator>
                     </div>


                 </div>
             </div>

         </div>

     </div>
 </div>
 <div class="row">
     <div class="col-12 col-md-12 col-lg-12 col-sm-12 mt-3 ms-5">
         <div class="d-flex align-items-center mb-3">
             <div class="container-fluid">
                 <div class="row">
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="Select Pattern <span class='require fw-bold' style='color: red;'>*</span>" runat="server" CssClass="fw-bold me-2 ms-4"></asp:Label><br />
                         <asp:DropDownList ID="ddlall" runat="server" CssClass="ms-4 rounded-2" OnSelectedIndexChanged="ddlall_SelectedIndexChanged" AutoPostBack="true" Width="180px">
                             <asp:ListItem>Select</asp:ListItem>
                             <asp:ListItem>All</asp:ListItem>
                             <asp:ListItem>same</asp:ListItem>
                             <asp:ListItem>Single</asp:ListItem>
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select the pattern" InitialValue="Select" ValidationGroup="validations" ControlToValidate="ddlall"></asp:RequiredFieldValidator>

                     </div>
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Label Text="Availble Rooms <span class='require fw-bold' style='color: red;'>*</span>" runat="server"  ID="avRooms" CssClass="fw-bold me-2 ms-4"></asp:Label>
                         <asp:DropDownList ID="Ddlselect" runat="server" Width="180px" CssClass="ms-4 rounded-2"  OnSelectedIndexChanged="Ddlselect_SelectedIndexChanged">
                             <asp:ListItem>Select</asp:ListItem>
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select the pattern" InitialValue="Select" ValidationGroup="validations" ControlToValidate="Ddlselect"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-12 col-md-6 col-lg-2 col-sm-12">
                         <asp:Button ID="btnaddAdd" runat="server" Text="Add" OnClick="btnaddAdd_Click" CssClass="ms-1 mt-4 rounded-2" Width="100px" />
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>

    <hr />
    <div class="container-start">
        <div class="row">
            <!-- GridView container wrapped in Bootstrap grid system for responsiveness -->
            <div class="grid-container col-12 col-md-10 col-lg-8 ms-5 " id="gdv1" runat="server" visible="false" style="margin-top: -25px">
                <!-- Heading above the GridView -->
                <asp:Label ID="lblgrid" class="text-center mb-4" Style="margin-left: 280px" Visible="false" Font-Bold="true" runat="server"></asp:Label>


                <!-- GridView with columns for input fields -->
                <div class="d-flex justify-content-center">
                    <asp:GridView ID="gvDynamic" runat="server" BorderColor="Black" HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="table table-bordered custom-border-radius" OnRowDataBound="gvDynamic_RowDataBound" ShowFooter="true">
                        <Columns>

                            <asp:BoundField HeaderText="SNo." SortExpression="SNo" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="True" />

                            <asp:TemplateField HeaderText="Room Number">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtroomno" runat="server" CssClass="form-control" oninput="allowNumbersOnly(this)" placeholder="Room Number" />
                                    <asp:RequiredFieldValidator ID="room1" ValidationGroup="validations" runat="server" ControlToValidate="txtroomno" ErrorMessage="Enter Rooms" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Capacity of the Room">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcapacityroomno" runat="server" CssClass="form-control" oninput="allowNumbersOnly(this)" OnTextChanged="txtroomno_TextChanged" AutoPostBack="true" placeholder="Capacity" />
                                    <asp:RequiredFieldValidator ID="room2" ValidationGroup="validations" runat="server" ControlToValidate="txtcapacityroomno" ErrorMessage="Enter Capacity" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sitting Allocation for Examination">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtsittingallocation" runat="server" CssClass="form-control" placeholder="Sitting Allocation" />
                                    <asp:RequiredFieldValidator ID="room3" ValidationGroup="validations" runat="server" ControlToValidate="txtsittingallocation" ErrorMessage="Enter Sitting Allocation" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Number Of Desks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtnoofdesks" runat="server" CssClass="form-control" oninput="allowNumbersOnly(this)" placeholder="No. of Desks" />
                                    <asp:RequiredFieldValidator ID="room4" ValidationGroup="validations" runat="server" ControlToValidate="txtnoofdesks" ErrorMessage="Enter Number Of Desks" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Number of Tables / Benches">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtnoofbenches" runat="server" CssClass="form-control" oninput="allowNumbersOnly(this)" placeholder="No. of Benches" />
                                    <asp:RequiredFieldValidator ID="room5" ValidationGroup="validations" runat="server" ControlToValidate="txtnoofbenches" ErrorMessage="Enter No of Benches" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator><br />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-2 col-lg-2">
                <asp:Label Width="490px" runat="server" ID="lbgrivalue" Visible="false" ForeColor="Red" Font-Bold="true" CssClass="fw-bold me-2 ms-5"></asp:Label>
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


<%--              <asp:Label Text="No Of Rooms" runat="server" CssClass="fw-bold"></asp:Label>
                     <asp:DropDownList ID="ddlnoofrooms" runat="server" Width="280px" Height="30px" CssClass="ms-5"></asp:DropDownList>
                     <br />
                     <hr />
                     <asp:Button Text="Save" ID="btnsave" runat="server" CssClass="fw-bold " />
                     &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
<asp:Button Text="Submit" ID="btnsubmit" runat="server" CssClass="fw-bold " />
                     &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
<asp:Button Text="Clear" ID="btnclear" runat="server" CssClass="fw-bold " />
                     &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
<asp:Button Text="Preview" ID="btnpreview" runat="server" CssClass="fw-bold " />
                     &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp--%>