CREATE PROCEDURE [dbo].[CountrySelectAll] 
AS  
SELECT  
dBCountry.Id 
, dBCountry.CountryName 
FROM dbCountry 
ORDER BY dbCountry.CountryName
