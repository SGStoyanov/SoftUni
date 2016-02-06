from statistics import mean

linesList = []
with open('catalog_full.csv') as file:
    linesList = file.readlines()

columnsList = ['catNum', 'productName', 'productColors', 'activityType', 'productGroup',
               'ageCategory', 'price']
productsDict = [{}]

for line in linesList:
    lineArray = line.replace('\n', '').split(',')
    lineArray[len(lineArray) - 1] = float(lineArray[len(lineArray) - 1])
    productsDict.append(dict(zip(columnsList, lineArray)))


def get_avg_price_per_age_categ(age_category: str, input_list: list):
    total_price = 0
    iterations_counter = 0

    for currentDict in input_list:
        if 'ageCategory' in currentDict and currentDict['ageCategory'] == age_category:
            total_price += float(currentDict['price'])
            iterations_counter += 1
        elif currentDict == {}:
            continue

    if total_price > 0 and iterations_counter > 0:
        avg_price = round(total_price/iterations_counter, 2)
        return_str = 'Category: ' + age_category + ' - Average Price = ' + str(avg_price)
        return return_str
    else:
        return 'Category: ' + age_category + ' - Average Price = 0'


welcomeMessage = 'Enter an Age Category: '
category = (input(welcomeMessage)).strip()

print(get_avg_price_per_age_categ(category, productsDict))
