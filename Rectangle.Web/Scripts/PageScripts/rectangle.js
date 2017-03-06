function draw(canvasId, grid, isSolutionGrid) {
    var canvas = document.getElementById(canvasId);

    canvas.style.width = "100%";
    canvas.width = canvas.offsetWidth;
    if (canvas.getContext) {
        var context = canvas.getContext("2d");
        context.translate(0, 200);

        var sumWidth = 0;
        if (isSolutionGrid) {
            sumWidth = grid.RectangleList[0].Width;
        } else {
            for (var j = 0; j < grid.RectangleList.length; j++) {
                sumWidth = sumWidth + grid.RectangleList[j].Width;
            }
        }
        
        if (sumWidth > canvas.width) {
            var scalingFactor = 1 / (sumWidth / canvas.width);
            context.scale(scalingFactor, 1);
        }

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