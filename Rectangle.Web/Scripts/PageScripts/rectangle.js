function fitWidthToParent(canvas) {
    canvas.style.width = "100%";
    canvas.width = canvas.offsetWidth;
}

function scaleRectanglesToFillCanvas(canvas, context, grid, isSolutionGrid) {
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
}

function generateRandomColour(context) {
    var colour = randomColor({ luminosity: "light", count: 1 });
    context.fillStyle = colour;
}

function drawRectangle(rectangle, context) {
    var bottomLeftCoordinate = rectangle.BottomLeftCoordinate;
    var width = rectangle.Width;
    var height = rectangle.Height;

    generateRandomColour(context);
    context.fillRect(bottomLeftCoordinate.X, -bottomLeftCoordinate.Y, width, -height);
}

function drawAllRectangles(grid, context) {
    for (var i = 0; i < grid.RectangleList.length; i++) {
        drawRectangle(grid.RectangleList[i], context);
    }
}
function draw(canvasId, grid, isSolutionGrid) {
    var canvas = document.getElementById(canvasId);
    fitWidthToParent(canvas);

    if (canvas.getContext) {
        var context = canvas.getContext("2d");
        context.translate(0, canvas.height);
        scaleRectanglesToFillCanvas(canvas, context, grid, isSolutionGrid);
        drawAllRectangles(grid, context);
    }
}