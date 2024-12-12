<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="Preview1.aspx.cs" Inherits="Examination_Centere_Allocation.Preview1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--   <asp:Label Text="Section 1: Basic Details" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />--%>
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
    </style>

    <div class="container-fluid border-custom ms-4" style="margin-left: 110px; width: 950px;">
        <div class="container">
            <div class="row">
                <!-- Section Title -->
                <div class="col-12  mt-3">
                    <asp:Label Text="Section 1: Basic Details" runat="server" Font-Size="22px" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>

            <!-- District Name -->
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="District Name" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8">
                    <asp:Label ID="lbldistrict" runat="server" Font-Bold="true" ForeColor="#0000ff" CssClass="form-control ms-3 rounded-2" Width="98%" Height="40px"></asp:Label>
                </div>
            </div>

            <!-- Exam Center Name -->
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Exam Center Name" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8">
                    <asp:Label ID="lblexamcentname" Font-Bold="true" ForeColor="#0000ff" runat="server" CssClass="form-control ms-3 rounded-2" Width="98%" Height="50px" TextMode="MultiLine"></asp:Label>
                </div>
            </div>

            <!-- Division Name and Exam Center Address -->
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Division Name" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8">
                    <asp:Label ID="lbldivison" Font-Bold="true" ForeColor="#0000ff" runat="server" CssClass="form-control ms-3 rounded-2" Width="98%" Height="40px"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Exam Center Address" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8">
                    <asp:Label ID="lbladrdess" Font-Bold="true" ForeColor="#0000ff" runat="server" CssClass="form-control ms-3 rounded-2" Width="98%" Height="50px" TextMode="MultiLine"></asp:Label>
                </div>
            </div>

            <!-- GPS Location -->
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="GPS Location (Latitude & Longitude)" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">
                    <i class="fas fa-map-marker-alt" style="font-size: 20px; color: red;"></i>
                    <asp:Label TextMode="MultiLine" Font-Bold="true" ForeColor="#0000ff" runat="server" ID="lblgpsaddress" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;" placeholder="Enter latitude and longitude here..."></asp:Label>
                </div>
            </div>

            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 2: Physical Attributes" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Boundary Wall" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblboundarywall" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lbloption" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>

                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Text Area" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lbltextarea" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Number Of Rooms" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblnoofrooms" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>





            <div class="row mt-3">

                <div class="col-lg-12 col-md-12 d-flex align-items-center">

                    <div class="container mt-3">
                        <!-- Gridview Wrapper for Responsiveness -->
                        <div class="row">
                            <div class="col-12">
                                <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-responsive">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Room Number" SortExpression="Room_No">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Room_No") %>' class="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("Room_No") %>' class="form-control-static"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Capacity Of Room">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("[capacity_of_room]") %>' class="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("[capacity_of_room]") %>' class="form-control-static"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sitting Allocation For Examination">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("[Sitting_Allocation]") %>' class="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("[Sitting_Allocation]") %>' class="form-control-static"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Number Of Desks">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("[no_of_desks]") %>' class="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("[no_of_desks]") %>' class="form-control-static"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Number Of Benches">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("[no_of_benches]") %>' class="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" Font-Bold="true" ForeColor="#0000ff" runat="server" Text='<%# Bind("[no_of_benches]") %>' class="form-control-static"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 3: Building Information" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>


            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Number Of Floors" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" ID="lblnooffloors" Font-Bold="true" ForeColor="#0000ff" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>


            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Accessibility" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblaccessibility" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblothers" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 4: Facilities" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>


            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Electricity" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblelectricity" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="BackUp Power Supply" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblbackuppower" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Drinking Water" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lbldrinkingwater" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Toilets Availability" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="txttoilets" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <%--   <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Toilets Availability" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="Label1" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>--%>

            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 5: Security and Surveillance" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="CCTV Surveillance" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="txtcctvsurveillance" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Security Personal" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblsecuritysurveillence" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>
            <%--   <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" id="lblsecuritypersonal" Font-Bold="true" ForeColor="#0000ff"  CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>--%>
            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 6:Accessibility And Transport" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Parking Availability" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblparkingavailbility" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Proximity to Transport" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblproximityTransport" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Name Of Transport" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblnameoftranspoirt" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Distance" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lbldistance" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row">
                <!-- Section Title -->
                <div class="col-12 mt-3">
                    <asp:Label Text="Section 7:Additional Information" Font-Size="22px" runat="server" CssClass="fw-bold" ForeColor="#ff0000"></asp:Label>
                </div>
            </div>


            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Examination Hall Type" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblexaminationhalltype" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="Emergency Exits" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblemergencyexits" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>

                </div>
            </div>

            <div class="row mt-3">
                <div class="col-lg-3 col-md-4">
                    <asp:Label Text="No Of Exits Available" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
                <div class="col-lg-9 col-md-8 d-flex align-items-center">

                    <asp:Label runat="server" Font-Bold="true" ForeColor="#0000ff" ID="lblemergencyexitsavailble" CssClass="form-control ms-3 rounded-2" Style="width: 100%; height: 50px; margin-left: 1px;"></asp:Label>

                </div>
            </div>


            <div class="row mt-3">
                <div class="row ms-5 d-flex justify-content-center">

                    <%-- <button type="submit" runat="server" data-bs-toggle="modal" data-bs-target="#myModal" id="Button1" style="height: 80px; width: 200px; background-color: chocolate" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline ">
                        <i class="fas fa-file-alt folded fa-2x" style="color: darkturquoise"></i>
                        <br />
                        Submit
                    </button>--%>
                    <button type="button" runat="server" id="Button4"
                     style="height: 70px; width: 180px; background-color:chocolate"
                        class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline "
                        data-bs-toggle="modal"
                        data-bs-target="#myModal">
                        <i class="fas fa-file-alt folded fa-2x" style="color: darkturquoise"></i>Submit

                    </button>
                </div>



            </div>
            <div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h5 class="modal-title" id="myModalLabel">Final Submition</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            If You Want Submit Click Yes...! If You want Edit Click No...!
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
            <div class="container-fluid mt-5">
            </div>
            <div class="container-fluid mt-5">
            </div>

        </div>
    </div>










    <%--<div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true">
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
    
    
    --%>















    <%--<div class="container-fluid ms-4">
        <div class="row">
            <div class="col-lg-12 col-md-12 justify-content-left ms-5">
                <asp:Label Text="Section 1: Basic Details" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label><br />
                <asp:Label Text="District Name" runat="server" CssClass="fw-bold ms-3"></asp:Label>
                <asp:TextBox ID="txtdistrictName" CssClass="fw-bold ms-3" runat="server"></asp:TextBox>



            </div>
        </div>
        <div class="row">
            <asp:Label Text="DiVision Name" runat="server" CssClass="fw-bold ms-3"></asp:Label>
            <asp:TextBox ID="txtdivisionname" CssClass="fw-bold ms-3" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <i class="fas fa-map-marker-alt" style="font-size: 20px; color: red; margin-left: -7px;"></i>
            <asp:TextBox TextMode="MultiLine" ID="textaddress" CssClass="rounded-2"
                runat="server"
                Style="width: 280px; margin-left: 1px;"
                placeholder="Enter latitude and longitude here...">
            </asp:TextBox>

            <asp:TextBox ID="txtgps" CssClass="fw-bold ms-3" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <asp:Label Text="Exam Ceneter Name" runat="server" CssClass="fw-bold ms-5"></asp:Label>

            <asp:TextBox ID="txtcent" runat="server" TextMode="MultiLine" CssClass="rounded-2 ms-5" Width="300px" Height="50px"></asp:TextBox>
        </div>

    </div>--%>
</asp:Content>

