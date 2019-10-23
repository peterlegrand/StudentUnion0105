CREATE PROCEDURE PageIndexSelect (@LanguageId int)
AS 
SELECT dbPage.Id
	, dbPageLanguage.LanguageId
	, dbPageLanguage.Name
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbPage.CreatedDate
	, dbPage.ModifiedDate
FROM dbPage
JOIN dbPageLanguage
	ON dbPage.Id = dbPageLanguage.PageId
JOIN AspNetUsers Creator
	ON CAST( dbPage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbPage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbPageLanguage.LanguageId = @LanguageId
ORDER BY 
dbPageLanguage.Name


