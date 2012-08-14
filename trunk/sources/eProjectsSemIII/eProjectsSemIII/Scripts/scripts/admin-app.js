// JavaScript Document
$(document).ready(function () {
    var a = document.getElementsByName('editor1');
    $('.item_navigation_content').hover(function () {
        $('.item_navigation_son').hide();
        var left = $(this).offset().left;
        var top = $(this).offset().top;
        $(this).next('.item_navigation_son').css('left', left).css('top', top + 31).show();
        $('.item_navigation_son').mouseover(function () {
            $(this).show();
        });
        $('.item_navigation_son').mouseout(function () {
            $(this).hide();
        });
    });
    $('#help_action').click(function () {
        var value = CKEDITOR.instances.editor1.getData();
        CKEDITOR.instances.editor1.setData("Anh yeu em nhieu lam");
        console.log(value);
    });
    $('.item_tab_form_panel').click(function () {
        var id = $(this).attr('id');
        id = id.substring(id.length - 1, id.length);
        $('.item_content_form_panel').hide();
        $('#item_content_form_panel' + id).show();
        $('.item_tab_form_panel').removeClass('item_tab_form_panel_show');
        $(this).addClass('item_tab_form_panel_show');
    });
    ///////////////////////////////////////////////DATE TIME////////////////////////////////////////////////////////
    $("#StartDate").glDatePicker(
    {
        cssName: "android",
        onChange: function (target, newDate) {
            target.val
            (
                newDate.getDate() + "/" +
                (newDate.getMonth() + 1) + "/" +
                newDate.getFullYear()
            );
        }
    });
    $("#DeadlineDate").glDatePicker(
    {
        cssName: "android",
        onChange: function (target, newDate) {
            target.val
            (
                newDate.getDate() + "/" +
                (newDate.getMonth() + 1) + "/" +
                newDate.getFullYear()
            );
        }
    });
    $("#EndDate").glDatePicker(
    {
        cssName: "android",
        onChange: function (target, newDate) {
            target.val
            (
                newDate.getDate() + "/" +
                (newDate.getMonth() + 1) + "/" +
                newDate.getFullYear()
            );
        }
    });
});
//
