INTERVIEW -Question SQL
------------------------------
SELECT city, COUNT(*) AS count
FROM city_table
GROUP BY city
ORDER BY count DESC
LIMIT 1;
