text = input('Въведете текст: ')
key = input('Въведете търсената дума: ')

searchedIndex = text.find(key)
tempStr = text[(searchedIndex + len(key)):len(text)]
outputString = tempStr.strip()
print(outputString)
