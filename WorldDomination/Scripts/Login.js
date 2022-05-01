function Login() {
    //var formData = new FormData(document.forms.Login);
    $.ajax({
        type: "POST",
        url: "Login/login?login=" + $("#input1").val() + "&password=" + $("#input2").val(),
        success: function (data) {
            if (data.Status == "0") {
                $(".exeption-textarea").append("Incorrect data!");
            } else {
                window.location.replace("Game/Index");
            }
        }
    });
}

$(".submit").click(function () {
    Login();
});
