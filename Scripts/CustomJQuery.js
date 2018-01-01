$(document).ready(function () {
    //datepicker for dateofbirth
    $('#DateOfBirth').datepicker(
        {
            dateFormat: "mm/dd/yy",
            changeMonth: true,
            changeYear: true,
            yearRange: "-60:+0"
        });

    //navbar submenus
    $('.dropdown-submenu a.test').on("click", function (e) {
        $(this).next('ul').toggle();
        e.stopPropagation();
        e.preventDefault();
    });

    //jumbotron of index page
    $('.jumbotron').addClass('jumbotronn');

    //PartialUpdateAjax
    $('.hidePartialUpdateAjax').click(function () {
        $('#divPartialUpdateAjax').hide();
        $('#divProgressbar').addClass('active');
    });
});

