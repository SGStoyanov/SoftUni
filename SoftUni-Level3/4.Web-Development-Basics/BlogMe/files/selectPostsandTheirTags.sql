use blogmedb;

SELECT p.Title, t.Name AS Tag 
FROM Posts p
JOIN Posts_has_Tags pt ON p.Id = pt.Post_Id
JOIN Tags t ON pt.Tag_Id = t.Id
GROUP BY p.Title, Tag