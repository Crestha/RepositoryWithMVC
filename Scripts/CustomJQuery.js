$(document).ready(function () {
    //datepicker for dateofbirth
    $('#DateOfBirth').datepicker(
        {
            dateFormat: "mm/dd/yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-60:+0"
        });
 });

