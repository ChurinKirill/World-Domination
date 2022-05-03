function Update() {
    $.ajax({
        type: "POST",
        url: "Game/Update"
    });
}

$("#update-button").click(function () {
    Update();
});