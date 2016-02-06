import turtle

turtle.speed('fast')
colors = ['red', 'green', 'blue', 'purple']
length = int(input())
angle = int(input())


for a in range(4):
    turtle.color(colors[a])
    x = 1
    for b in range(1, length):
        turtle.forward(10)
        turtle.right(angle - x)
        x += 1
