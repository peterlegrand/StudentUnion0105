CREATE PROCEDURE [dbo].[CountrySelectAll] 
AS  
SELECT  
dBCountry.Id 
, dBCountry.Name 
FROM dbCountry 
ORDER BY dbCountry.Name
