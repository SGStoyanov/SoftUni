import turtle

turtle.speed('slowest')
side = int(input('Enter side length: '))
#side = 50
angle = 90
currentSide = 0

for n in range(8):
    for i in range(8):
        if i % 2 == 0 and n % 2 == 0:
            turtle.begin_fill()
        if i % 2 != 0 and n % 2 != 0:
            turtle.begin_fill()
        turtle.forward(side)
        turtle.left(angle)
        turtle.forward(side)
        turtle.left(angle)
        turtle.forward(side)
        turtle.left(angle)
        turtle.forward(side)
        turtle.left(angle)
        turtle.end_fill()
        turtle.forward(side)
    turtle.penup()
    currentSide += int(round(side))
    turtle.goto(0, currentSide)
    turtle.pendown()

turtle.exitonclick()
