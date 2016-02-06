from statistics import mean

linesList = []
with open('catalog_sample.csv') as file:
    linesList = file.readlines()

priceList = []
for line in linesList:
    lineArray = line.split(',')
    price = (lineArray[len(lineArray) - 1]).replace("\n", "")
    priceList.append(float(price))

print(mean(priceList))
