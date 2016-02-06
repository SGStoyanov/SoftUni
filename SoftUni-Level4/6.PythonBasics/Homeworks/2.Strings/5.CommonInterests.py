ivan = ['пушене', 'пиене', 'тия три неща', 'коли', 'facebook', 'игри', 'разходки по плажа', 'скандинавска поезия']
maria = ['пиене', 'мода', 'facebook', 'игри', 'лов със соколи', 'шопинг', 'кино']

blabla = '''
commonInterests = []

for interest in ivan:
    for interest2 in maria:
        if interest == interest2:
            commonInterests.append(interest)

if len(commonInterests) > 0:
    print(', '.join(commonInterests))
'''

print(set(ivan) & set(maria))
