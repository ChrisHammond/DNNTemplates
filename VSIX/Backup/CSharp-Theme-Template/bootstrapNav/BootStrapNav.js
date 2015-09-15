$(document).ready(function(e) {
});

$(document).ready(function () {

    $('.nav > li.dropdown > a').click(function (e) {
        var $target = $(e.target);
        var activeNav = $(this).siblings();
        if ($target.is('b') || $(this).attr('href')=='#') {
            $(this).siblings().toggle("fast");
            $('.nav > li.dropdown > ul.dropdown-menu:visible').not($(this).siblings()).hide("fast");
            return false;
        }
    });
});
