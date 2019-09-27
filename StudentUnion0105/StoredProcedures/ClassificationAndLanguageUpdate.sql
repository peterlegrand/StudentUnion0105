CREATE PROCEDURE  
[dbo].[ClassificationAndLanguageUpdate]  
 @Id int 
, @ClassificationStatusId int 
, @DefaultClassificationPageId int 
, @HasDropDown bit 
, @DropDownSequence  int 
, @ClassificationLanguageId  int 
, @LanguageId  int 
, @ClassificationName nvarchar(max) 
, @ClassificationDescription nvarchar(max) 
, @ClassificationMenuName nvarchar(max) 
, @ClassificationMouseOver nvarchar(max) 
, @ModifiedDate datetime2(7) 
AS 
BEGIN TRANSACTION 
UPDATE  
dbClassification 
SET  
dbClassification.ClassificationStatusId = @ClassificationStatusId 
, dbClassification.DefaultClassificationPageId = iif(@DefaultClassificationPageId=0,null,@DefaultClassificationPageId) 
, dbClassification.HasDropDown = @HasDropDown 
, dbClassification.DropDownSequence = @DropDownSequence 
, dbClassification.ModifiedDate = @ModifiedDate 
WHERE  
dbClassification.Id = @Id 
 
UPDATE  
dbClassificationLanguage 
SET 
 dbClassificationLanguage.ClassificationName  = @ClassificationName 
, dbClassificationLanguage.ClassificationDescription = @ClassificationDescription 
, dbClassificationLanguage.ClassificationMenuName = @ClassificationMenuName  
, dbClassificationLanguage.ClassificationMouseOver = @ClassificationMouseOver 
, dbClassificationLanguage.ModifiedDate = @ModifiedDate 
WHERE  
 Id = @ClassificationLanguageId 
 
COMMIT TRANSACTION 