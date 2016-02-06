import statistics

numbersList = []

while True:
    inputText = input('Въведете цена: ')
    if len(inputText.strip()) <= 0 or (inputText != 'stop' and (inputText.isdigit() == False or int(inputText) <= 0)):
        print('Въведете коректни данни и поне 4 цени')

    if inputText != 'stop':
        number = int(inputText)
        numbersList.append(number)

    if inputText.strip() == 'stop':
        if len(numbersList) < 4:
            print('Въведете поне 4 цени!')
            break

        listWithoutDuplicates = list(set(numbersList))

        if len(listWithoutDuplicates) == 1:
            print('Average Price: ' + str(listWithoutDuplicates[0]))
            break

        sortedList = sorted(numbersList)
        minPrice = sortedList[0]
        maxPrice = sortedList[len(sortedList) - 1]

        for num in range(len(sortedList) - 1, -1, -1):
            if sortedList[num] == minPrice:
                sortedList.remove(minPrice)
            if sortedList[num] == maxPrice:
                sortedList.remove(maxPrice)

        if len(sortedList) > 0:
            averagePrice = statistics.mean(sortedList)
            print("Min Price: {0}\nMax Price: {1}\nAverage Price: {2}".format(minPrice, maxPrice, averagePrice))
        else:
            print('Something went wrong')

        break
