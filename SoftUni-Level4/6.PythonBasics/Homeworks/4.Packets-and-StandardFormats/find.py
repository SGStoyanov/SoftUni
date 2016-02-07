import sys
import os
import logging

if len(sys.argv) == 3 and os.path.isdir(sys.argv[1]):
    targetDir = sys.argv[1]
    neededFile = sys.argv[2]
    fileFound = False

    for dirpath, dirnames, filenames in os.walk(targetDir):
        fullPath = os.path.join(dirpath, neededFile)

        if neededFile[0] == '*':
            for file in filenames:
                if file.endswith(neededFile[1:len(neededFile)]):
                    fileFound = True
                    currentPath = dirpath + file
                    print('File found: {} - {} bytes'.format(currentPath, os.path.getsize(currentPath)))
        elif neededFile[-1] == '*':
            for file in filenames:
                if file.startswith(neededFile[0:len(neededFile) - 1]):
                    fileFound = True
                    currentPath = os.path.join(dirpath, file)
                    print('File found: {} - {} bytes'.format(currentPath, os.path.getsize(currentPath)))
        elif os.path.exists(fullPath):
            fileFound = True
            print('File found: {} {} bytes'.format(fullPath, os.path.getsize(fullPath)))

    if not fileFound:
        print('File not found!')
        for args in sys.argv:
            print('Argument: ' + args)
else:
    logging.warning('Wrong input! You have to enter three parameters: 1. The script, 2. The target directory, 3. The needed file')
    for args in sys.argv:
        print('Argument: ' + args)
