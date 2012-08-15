// JavaScript Document
String.prototype.replaceAll = function (
strTarget, // The substring you want to replace
strSubString // The string you want to replace in.
) {
    var strText = this;
    var intIndexOfMatch = strText.indexOf(strTarget);

    // Keep looping while an instance of the target string
    // still exists in the string.
    while (intIndexOfMatch != -1) {
        // Relace out the current instance.
        strText = strText.replace(strTarget, strSubString)

        // Get the index of any next matching substring.
        intIndexOfMatch = strText.indexOf(strTarget);
    }

    // Return the updated string with ALL the target strings
    // replaced out with the new substring.
    return (strText);
}


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

    $('#Name-Item').blur(function () {
        var name = $(this).val();
        name = name.replace(/-/g, ' ');
        name = $.trim(name);
        var illegalChars = "!@#$%^&*()+=[]\\\';,./{}|\":<>?'_";
        for (var i = 0; i < illegalChars.length; i++) {
            name = name.replaceAll(illegalChars[i], '');
        }
        name = name.replace(/\s/g, '-');
        name = name.replace(/"/g, '');
        name = name.toLowerCase();
        var arrUNICharacter = ['à', 'á', 'ả', 'ã', 'ạ', 'ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ', 'â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ', 'đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ', 'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ', 'ì', 'í', 'ỉ', 'ĩ', 'ị', 'ò', 'ó', 'ỏ', 'õ', 'ọ', 'ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ', 'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ', 'ù', 'ú', 'ủ', 'ũ', 'ụ', 'ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự', 'ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ', '(', ')'];
        var arrReplace = ['a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'd', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'i', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'y', 'y', 'y', 'y', 'y', '', ''];
        $.each(arrUNICharacter, function (key, value) {
            $.each(name, function () {
                name = name.replace(value, arrReplace[key]);
            });
        });
        $('#Alias-Item').val(name);
    });
});
//
