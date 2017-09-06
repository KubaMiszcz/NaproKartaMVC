if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".datecontrol").datepicker();

    });
}


function SetProperty(propName,val) {
    document.getElementById(propName).value = val;
    //alert(val);
}

function ChangeSelectedChart(userId,dropdown) {
    //alert(dropdown.options[dropdown.selectedIndex].value);
    var chartID = dropdown.options[dropdown.selectedIndex].value;
    window.location.href = '/User/Chart/' + userId + '?chartId=' + chartID;
    }