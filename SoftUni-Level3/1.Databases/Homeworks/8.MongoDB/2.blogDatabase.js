mongo
use blogDb
db
show dbs

var bulk = db.posts.initializeUnorderedBulkOp();
bulk.insert({ title: "First Title", content: "First content", dateOfCreation: new Date('Dec 01, 2014'), 
    category: "General", tags: ["someTag", "secondTag"], author: {displayName: "emz", tweeterAccount: "emzotic", linkedInAccount: "http://linkedIn.com/emzotic"} });
bulk.insert({ title: "Second Title", content: "Second content", dateOfCreation: new Date('Dec 01, 2015'), 
    category: "General", tags: ["someTag", "secondTag"], author: {displayName: "Didi", tweeterAccount: "didik", linkedInAccount: "http://linkedIn.com/didik"} });
bulk.insert({ title: "Third Title", content: "Third content", dateOfCreation: new Date('Dec 04, 2015'), 
    category: "General", tags: ["otherTag", "questions"], author: {displayName: "Vladi", tweeterAccount: "vladi4", linkedInAccount: "http://linkedIn.com/vladi4"} });
bulk.insert({ title: "Fourth Title", content: "Fourth content", dateOfCreation: new Date('Jan 22, 2014'), 
    category: "General", tags: ["moreThanTag", "answers", "Internet"], author: {displayName: "emz", tweeterAccount: "emzotic", linkedInAccount: "http://linkedIn.com/emzotic"} });
bulk.insert({ title: "Fivth Title", content: "Fivth content", dateOfCreation: new Date('May 22, 2015'), 
    category: "General", tags: ["servers", "answers"], author: {displayName: "superUser", tweeterAccount: "superUser", linkedInAccount: "http://linkedIn.com/superUser"} });
bulk.insert({ title: "Sixth Title", content: "Sixth content", dateOfCreation: new Date('Jul 14, 2015'), 
    category: "General", tags: ["PHP", "frameworks"], author: {displayName: "Doncho", tweeterAccount: "donchoDonchev", linkedInAccount: "http://linkedIn.com/donchoDonchev"} });
bulk.insert({ title: "Seventh Title", content: "Seventh content", dateOfCreation: new Date('Aug 28, 2015'), 
    category: "General", tags: ["JavaScript", "jQuery", "AngularJS"], author: {displayName: "Zina", tweeterAccount: "zinaZina", linkedInAccount: "http://linkedIn.com/zina"} });
bulk.execute();

db.posts.find();