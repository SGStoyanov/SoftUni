inputStr = input('Въведете имената си: ')

names = inputStr.split()

for name in names:
    print(name[0] + '.', end='')
