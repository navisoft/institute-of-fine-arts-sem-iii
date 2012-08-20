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