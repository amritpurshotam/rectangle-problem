function draw(canvasId, grid) {
    var canvas = document.getElementById(canvasId);
    if (canvas.getContext) {
        var context = canvas.getContext("2d");
        context.translate(0, 200);

        for (var i = 0; i < grid.RectangleList.length; i++) {
            var bottomLeftCoordinate = grid.RectangleList[i].BottomLeftCoordinate;
            var width = grid.RectangleList[i].Width;
            var height = grid.RectangleList[i].Height;

            var colour = randomColor({ luminosity: 'light', count: 1 });
            context.fillStyle = colour;

            context.fillRect(bottomLeftCoordinate.X, -bottomLeftCoordinate.Y, width, -height);
        }
    }
}