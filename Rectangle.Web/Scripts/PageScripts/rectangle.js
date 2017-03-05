function draw() {
    var canvas = document.getElementById("uploaded-rectangles");
    if (canvas.getContext) {
        var ctx = canvas.getContext("2d");
        ctx.translate(0, 200);

        ctx.fillRect(0, 0, 100, -100);
    }
}

$(document).ready(function () {
    draw();
});