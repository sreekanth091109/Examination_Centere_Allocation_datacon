<%@ Page Language="C#" MasterPageFile="~/eca.Master" AutoEventWireup="true" CodeBehind="section1.aspx.cs" Inherits="Examination_Centere_Allocation.section1" %>

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
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>

    <style>
        .form-validator {
            font-size: calc(0.5vw + 4px);
            Adjust size based on viewport width
        }
    </style>
<script>
    // Function to clear the location textbox if the Exam Center or Exam Center Address is cleared
    function clearLocationTextbox() {
        var examCenterName = document.getElementById('<%= tblecn.ClientID %>').value;
        var examCenterAddress = document.getElementById('<%= txtadrdess.ClientID %>').value;

        // If both Exam Center Name and Exam Center Address are empty, clear the Location Address Textbox
        if (examCenterName === "" && examCenterAddress === "") {
            document.getElementById('<%= textaddress.ClientID %>').value = "";  // Clear Location Address Textbox

            //07-12-24
            // Clear the Google Maps link (if any)
            document.getElementById('addressLinkDiv').innerHTML = "";

            // Optionally clear the Division Name and District Name if desired
            document.getElementById('<%= ddldistrict.ClientID %>').value = "";
            document.getElementById('<%= ddldivison.ClientID %>').value = "";
            //07-12-24
        }
    }

    // Function to get address, latitude, and longitude based on Exam Center Name and Address
    function getAddressFromText(text) {
        var address = text.trim();
        if (address !== "") {
            var url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(address)}`;

            // Make an AJAX request to OpenStreetMap Nominatim API
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    if (data && data.length > 0) {
                        // If data is found, use the first result
                        var formattedAddress = data[0].display_name; // Get the formatted address
                        var latitude = data[0].lat;  // Get latitude
                        var longitude = data[0].lon; // Get longitude

                        // Get N, S, E, W directions for latitude and longitude
                        var latDirection = latitude > 0 ? "N" : "S";
                        var lonDirection = longitude > 0 ? "E" : "W";

                        // Format the address with latitude, longitude, and directions
                        /*var addressWithCoordinates = `${formattedAddress} Latitude: ${Math.abs(latitude)}° ${latDirection}, Longitude: ${Math.abs(longitude)}° ${lonDirection}`;*/
                        /*var addressWithCoordinates = `Latitude: ${Math.abs(latitude)}° ${latDirection}, Longitude: ${Math.abs(longitude)}° ${lonDirection}`;*/
                        var addressWithCoordinates = `${Math.abs(latitude)}° ${latDirection}, ${Math.abs(longitude)}° ${lonDirection}`;



                        // Set the formatted address with coordinates in the Location Address Textbox
                        document.getElementById('<%= textaddress.ClientID %>').value = addressWithCoordinates;

                        /*6 -12 -24*/
                        /*Create a Google Maps link*/
                        var googleMapsLink = `https://www.google.com/maps?q=${encodeURIComponent(addressWithCoordinates)}`;

                        // Create a new div to display the clickable link
                        var linkDiv = document.createElement('div');
                        linkDiv.innerHTML = `<a href="${googleMapsLink}" target="_blank" style="text-decoration: none; color: blue;">Click here to view the location on Google Maps</a>`;

                        // Append the link div to the page
                        document.getElementById('addressLinkDiv').innerHTML = ''; // Clear previous content
                        document.getElementById('addressLinkDiv').appendChild(linkDiv);
                        /*6-12-24*/


                        // Optionally, you can also log the latitude and longitude to the console
                        console.log(`Latitude: ${latitude}, Longitude: ${longitude}`);
                    }
                    else {
                        /*alert("Address not found.");*/
                        //07-12-24
                        // If no results found, show a fallback message
                        //alert("Address not found in OpenStreetMap. You can try viewing it on Google Maps.");

                        //Create a Google Maps search URL as a fallback
                        var googleMapsLink = `https://www.google.com/maps?q=${encodeURIComponent(address)}`;
                        var linkDiv = document.createElement('div');
                        linkDiv.innerHTML = `<a href="${googleMapsLink}" target="_blank" style="text-decoration: none; color: blue;">Click here to view the location on Google Maps</a>`;

                        // Append the fallback link to the page
                        document.getElementById('addressLinkDiv').innerHTML = ''; // Clear previous content
                        document.getElementById('addressLinkDiv').appendChild(linkDiv);
                        //07-12-24

                        //07-12-24
                        // If no results found, set default coordinates in the Location Address Textbox
                        <%--var defaultlatitude = "0.0000";  // default latitude if no result
                        var defaultlongitude = "0.0000"; // default longitude if no result
                        var latdirection = defaultlatitude > 0 ? "n" : "s";
                        var londirection = defaultlongitude > 0 ? "e" : "w";

                        // format the default coordinates
                        var defaultcoordinates = `${math.abs(defaultlatitude)}° ${latdirection}, ${math.abs(defaultlongitude)}° ${londirection}`;

                        // set the default coordinates in the location address textbox
                        document.getelementbyid('<%= textaddress.clientid %>').value = defaultcoordinates;

                        var googlemapslink = `https://www.google.com/maps?q=${encodeuricomponent(address)}`;
                        var linkdiv = document.createelement('div');
                        linkdiv.innerhtml = `<a href="${googlemapslink}" target="_blank" style="text-decoration: none; color: blue;">click here to view the location on google maps</a>`;

                        // append the fallback link to the page
                        document.getelementbyid('addresslinkdiv').innerhtml = ''; // clear previous content
                        document.getelementbyid('addresslinkdiv').appendchild(linkdiv);

                        // optionally, log the fallback coordinates to the console
                        //console.log(`Fallback Coordinates: Latitude: ${defaultLatitude}, Longitude: ${defaultLongitude}`);--%>
                        //07-12-24

                        //07-12-24
                        
                        //07-12-24

                    }
                })
                .catch(error => {
                    console.error('Error fetching data:', error);
                    alert("Error fetching address information.");
                });
        }
    }

    // Function that will be called when the user leaves the TextBox (onblur event)
    function onTextBoxBlur() {
        var examCenterName = document.getElementById('<%= tblecn.ClientID %>').value;
        var examCenterAddress = document.getElementById('<%= txtadrdess.ClientID %>').value;

        // Combine both values into a single address string
        var fullAddress = examCenterName + " " + examCenterAddress;

        // Call the function to get the address with latitude and longitude from OpenStreetMap Nominatim API
        getAddressFromText(fullAddress);
    }
</script>



    <div class="container-fluid ms-4">
        <div class="row">
            <div class="col-lg-12 col-md-12 justify-content-left ms-5">
                <asp:Label Text="Section 1: Basic Details" runat="server" CssClass="fw-bold" ForeColor="Blue"></asp:Label>
                <br />
                <asp:Label Text="District Name" runat="server" CssClass="fw-bold ms-3"></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span>
                <asp:DropDownList ID="ddldistrict" runat="server" Width="280px" Height="40px" CssClass="ms-5 mt-5 rounded-2" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select District" ValidationGroup="validations" InitialValue="Select District" ControlToValidate="ddldistrict"></asp:RequiredFieldValidator>

                <asp:Label Text="Exam Ceneter Name" runat="server" CssClass="fw-bold ms-5"></asp:Label>
                <span class="require fw-bold" style="color: red;">*</span>

                <asp:TextBox ID="tblecn" runat="server" TextMode="MultiLine" CssClass="rounded-2 ms-5 align-bottom" Width="500px" Height="50px" oninput="this.value = this.value.toUpperCase();" onkeyup="clearLocationTextbox()" onblur="onTextBoxBlur()"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Center name" ValidationGroup="validations" ControlToValidate="tblecn"></asp:RequiredFieldValidator>


            </div>
            <div class="row">
                <div class="col-lg-12  justify-content-left mt-1 ms-3">
                    <asp:Label Text="Divison Name" runat="server" CssClass="fw-bold ms-5"></asp:Label>
                    <span class="require fw-bold" style="color: red;">*</span>
                    <asp:DropDownList ID="ddldivison" runat="server" Width="280px" Height="40px" CssClass="ms-5 rounded-2"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Division" ValidationGroup="validations" ControlToValidate="ddldivison"></asp:RequiredFieldValidator>

                    <asp:Label Text="Exam Ceneter Name Address" runat="server" CssClass="fw-bold ms-4 "></asp:Label>
                    <span class="require fw-bold" style="color: red;">*</span>
                    <asp:TextBox ID="txtadrdess" runat="server" TextMode="MultiLine" Width="500px" Height="50px" CssClass="rounded-2 ms-1 align-bottom mt-4" oninput="this.value = this.value.toUpperCase();" onkeyup="clearLocationTextbox()" onblur="onTextBoxBlur()"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Center Address" ValidationGroup="validations" ControlToValidate="txtadrdess"></asp:RequiredFieldValidator>

                </div>
            </div>

        </div>
        <div class="row align-items-left ms-3 mt-5">
            <!-- Labels in one column -->
            <div class="col-auto d-flex flex-column">
                <asp:Label runat="server" CssClass="fw-bold ms-5">Gps Location<span class="require fw-bold" style="color: red;">*</span></asp:Label>

                <asp:Label runat="server" CssClass="fw-bold">(Latitude & Longitude)</asp:Label>

            </div>
            <!-- Icon and TextBox in the same row -->
            <div class="col d-flex align-items-center">
                <i class="fas fa-map-marker-alt" style="font-size: 20px; color: red; margin-left: -7px;"></i>
                <asp:TextBox TextMode="MultiLine" ID="textaddress" CssClass="rounded-2"
                    runat="server"
                    Style="width: 280px; margin-left: 1px;"
                    placeholder="Enter latitude and longitude here...">
                </asp:TextBox>
                <div id="addressLinkDiv"></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="form-validator fw-bold" runat="server" ForeColor="Red" ErrorMessage="Select Location" ValidationGroup="validations" ControlToValidate="textaddress" ></asp:RequiredFieldValidator>

            </div>
        </div>
    </div>
    <hr />

    <div class="container-fluid">
        <div class="row ms-5 d-flex justify-content-center">
            <div class="col-12 col-lg-12 d-flex justify-content-center">
                <button type="submit" runat="server" style="height: 80px; width: 100px;" validationgroup="validations" id="btnSave" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white" onserverclick="btnSave_ServerClick">
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
               <%-- <button type="submit" runat="server" data-bs-toggle="modal" data-bs-target="#myModal" id="Button4" style="height: 80px; width: 100px;" class="rounded-2 fw-bold ms-4 btn fs-5 btn btn-outline bg-white" >
                    <i class="fa-solid fa-eraser fa-2x" style="color: forestgreen"></i>Preview
                </button>--%>

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



