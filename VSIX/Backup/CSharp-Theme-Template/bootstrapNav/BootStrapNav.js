$(document).ready(function (e) {
});

$(document).ready(function () {

    $('ul.nav li.dropdown > a').click(function (e) {
        var $target = $(e.target);
        var activeNav = $(this).siblings();
        if ($target.is('b') || $(this).attr('href') == '#') {
            // The anchor tag only has one sibling - the submenu it controls
            $(this).siblings().toggle("fast");

            // Now walk up the parent chain:
            // - look for other li's (menu items at the same level)
            // - hide any lower down ul's (submenus) they may have.  Use find else you leave traces of children's child menus.
            $(this).parentsUntil('ul.nav', 'li').siblings().find('ul').hide();
            return false;
        }
    });
});

