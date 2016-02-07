from datetime import date, datetime, timedelta

linesList = list()
with open('sales.csv') as file:
    linesList = file.readlines()
salesDict = [{}]

columnsList = ['SalesDate', 'SalesTime', 'SaleSum']
for line in linesList:
    lineArray = line.replace(' ', ',').replace('\n', '').split(',')
    lineArray[0] = datetime.date(datetime.strptime(lineArray[0], '%Y-%m-%d'))
    lineArray[1] = datetime.time(datetime.strptime(lineArray[1], '%H:%M:%S'))
    lineArray[2] = float(lineArray[2])
    salesDict.append(dict(zip(columnsList, lineArray)))

summaryDict = {}

for idx, sale in enumerate(salesDict):
    if bool(sale):
        salesSum = float()
        for idx2, anotherSale in enumerate(salesDict):
            if bool(anotherSale):
                if sale.get('SalesDate') is not None \
                        and anotherSale.get('SalesDate') is not None \
                        and sale.get('SaleSum') is not None \
                        and anotherSale.get('SaleSum') is not None \
                        and sale.get('SalesDate') == anotherSale.get('SalesDate'):
                    salesSum += round(anotherSale.get('SaleSum'), 2)
                    summaryDict[sale.get('SalesDate')] = salesSum

for saleDate, saleSum in summaryDict.items():
    curDate = saleDate.strftime('%Y-%m-%d')
    curSum = str(round(saleSum, 2))
    print('Sale Date: {}, Sale Sum: {}'.format(curDate, curSum))
