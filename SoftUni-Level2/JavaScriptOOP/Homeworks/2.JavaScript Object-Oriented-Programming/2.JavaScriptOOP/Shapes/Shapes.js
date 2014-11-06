// Compatibility fix
Object.prototype.inherits = function (parent) {
    
    if (!Object.create) {
        Object.prototype.create = function(proto) {
            function F() {};

            F.prototype = proto;
            return new F;
        };
    }    ;

    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Shape = (function() {

    var shape = function(x, y, color) {
        this._x = x;
        this._y = y;
        this._color = color;
    };

    shape.prototype = {
        toString: function() {
            var shapeInfo = "X: " + this._x + ", Y: " + this._y + ", Color in hexadecimal format: " + this._color;
            return shapeInfo;
        },

        canvas: function() {
            var canvas = {
                element: document.getElementById("shapesContainer").getContext("2d")
            };

            return canvas;
        }

    };

    return shape;

}());

var Circle = (function() {

    var circle = function(x, y, color, radius) {
        Shape.call(this, x, y, color);
        this._radius = radius;
    };

    circle.inherits(Shape);

    circle.prototype.draw = function() {
        this.canvas().element.beginPath();
        this.canvas().element.arc(this._x, this._y, this._radius, 0, (2 * Math.PI));
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fill();
        this.canvas().element.stroke();
    }

    circle.prototype.toString = function() {
        return Shape.prototype.toString.call(this) + ", Radius: " + this._radius;
    };

    return circle;

}());

var Rectangle = (function() {

    var rectangle = function(x, y, color, width, height) {
        Shape.call(this, x, y, color);
        this._width = width;
        this._height = height;
    };

    rectangle.inherits(Shape);

    rectangle.prototype.draw = function() {
        this.canvas().element.beginPath();
        this.canvas().element.rect(this._x, this._y, this._width, this._height);
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fill();
        this.canvas().element.stroke();
    }

    rectangle.prototype.toString = function() {
        return Shape.prototype.toString.call(this) + ", Width: " + this._width + ", Height: " + this._height;
    }

    return rectangle;

}());

var Triangle = (function() {

    var triangle = function(x1, y1, color, x2, y2, x3, y3) {
        Shape.call(this, x1, y1, color);
        this._x2 = x2;
        this._y2 = y2;
        this._x3 = x3;
        this._y3 = y3;
    };

    triangle.inherits(Shape);

    triangle.prototype.draw = function() {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.moveTo(this._x1, this._y1);
        this.canvas().element.lineTo(this._x2 + this._x1, this._y2 + this._y1);
        this.canvas().element.lineTo(this._x3 + this._x1, this._y3 + this._y1);
        this.canvas().element.fill();
    };

    triangle.prototype.toString = function() {
        return Shape.prototype.toString.call(this) + ", x2: " + this._x2 + ", y2:" + this._y2 + ", x3: " + this._x3 + ", y3: " + this._y3;
    };

    return triangle;

}());

var Segment = (function() {

    var segment = function(x1, y1, color, x2, y2) {
        Shape.call(this, x1, y1, color);
        this._x2 = x2;
        this._y2 = y2;
    }

    segment.inherits(Shape);
    
    segment.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.moveTo(this._x1, this._y1);
        this.canvas().element.lineTo(this._x2 + this._x1, this._x2 + this._y1);
        this.canvas().element.strokeStyle = this._color;
        this.canvas().element.stroke();
    };

    segment.prototype.toString = function () {
        return Shape.prototype.toString.call(this) + " x2: " + this._x2 + " y2: " + this._y2;
    }

    return segment;

}());

var Point = (function () {

    var point = function (x, y, color) {
        Shape.call(this, x, y, color);
    };

    point.inherits(Shape);

    point.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._x, this._y, 3, 3);
    };

    point.prototype.toString = function () {
        return Shape.prototype.toString.call(this);
    };

    return point;

}());

var littleCircle = new Circle(50, 50, "#FF11DD", 30);
littleCircle.draw();
console.log(littleCircle);

var bigRectangle = new Rectangle(100, 100, "#AAFF1E", 200, 200);
bigRectangle.draw();
console.log(bigRectangle);

//var someTriangle = new Triangle(150, 200, "#EF21FA", 20, 20, 40, 40);
//someTriangle.draw();
//console.log(someTriangle);

//var mySegment = new Segment(300, 50, "#FFFFAA", 350, 100);
//mySegment.draw();
//console.log(mySegment);

var somePoint = new Point(260, 200, "#AA23EA");
somePoint.draw();
console.log(somePoint);