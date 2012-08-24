$(document).ready(function () {
    popup('input[name=name]', "Your fullname. Example: Bill Gates,Bae Jong Jun,...");
    popup('input[name=username]', "Username to login. Example: harangna,...");
    popup('input[name=email]', "Your Email. Example: example@email.com,...");
    popup('input[name=verifyemail]', "Type your email again.");
    popup('input[name=password]', "Password to login.");
    popup('input[name=verifypassword]', "Verify password.");
    popup('.birthday', "Your birthday.");
    popup('input[name=address]', "Your address.");
    popup('input[name=phone]', "Your phone number.");
    popup('input[name=Images]', "Your avatar. W:H ~ 200:240");
    popup('select[name=gender]', "Your gender.");
    popup('input[name=submit-register]', "Send info to server.");


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
function popup(element,text){
    $(element).hover(function () {
        var position = $(this).position();
        $('.popup').html(text);
        var width = $('.popup').width();
        $('.popup').css('left', position.left - width -37).css('top', position.top).show();
    }, function () {
        $('.popup').hide();
    });
}

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