show dbs

use chatDb
db

db.messages.insert({
    id: 1,
    text: 'First message',
    date: new Date('17-02-2015'),
    isRead: true,
    user: { username: 'emz', fullName: 'emz emzov', website: 'www.site.com' }
});

db.messages.insert({
    id: 2,
    text: 'Second message',
    date: new Date('18-02-2015'),
    isRead: true,
    user: { username: 'boncho', fullName: 'Boncho Genchev', website: 'www.site2.com' }
});


db.messages.insert({
    id: 3,
    text: 'Third message',
    date: new Date('Feb 19, 2015'),
    isRead: true,
    user: { username: 'boncho', fullName: 'Boncho Genchev', website: 'www.site2.com' }
});

db.messages.insert({
    id: 5,
    text: 'Fifth message',
    date: new Date('Feb 21, 2015'),
    isRead: false,
    user: { username: 'sladuran', fullName: 'Sladun Sladunov', website: 'www.site5.com' }
});

db.messages.insert({
    id: 6,
    text: 'Sixth message',
    date: new Date('Feb 22, 2015'),
    isRead: false,
    user: { username: 'hacker', fullName: 'No name', website: 'www.site6.com' }
});

db.messages.find();  // check the result
