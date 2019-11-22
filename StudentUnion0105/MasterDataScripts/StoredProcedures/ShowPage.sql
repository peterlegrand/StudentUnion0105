CREATE PROCEDURE  
[dbo].[ShowPage]  
@Id int 
, @LanguageId int 
AS 
SELECT dbPage.Id 
, dbPageLanguage.TitleName 
, dbPageLanguage.TitleDescription 
FROM dbpage  
JOIN dbPageLanguage 
ON dbPage.Id = dbPageLanguage.PageId 
 
WHERE dbPage.Id = @Id 
AND dbPageLanguage.LanguageId = @LanguageId 
