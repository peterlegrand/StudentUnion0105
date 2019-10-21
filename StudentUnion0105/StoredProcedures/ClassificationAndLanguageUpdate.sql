CREATE PROCEDURE  
[dbo].[ClassificationAndLanguageUpdate]  
 @Id int 
, @ClassificationStatusId int 
, @DefaultClassificationPageId int 
, @HasDropDown bit 
, @DropDownSequence  int 
, @ClassificationLanguageId  int 
, @LanguageId  int 
, @Name nvarchar(max) 
, @Description nvarchar(max) 
, @MenuName nvarchar(max) 
, @MouseOver nvarchar(max) 
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
 dbClassificationLanguage.Name  = @Name 
, dbClassificationLanguage.Description = @Description 
, dbClassificationLanguage.MenuName = @MenuName  
, dbClassificationLanguage.MouseOver = @MouseOver 
, dbClassificationLanguage.ModifiedDate = @ModifiedDate 
WHERE  
 Id = @ClassificationLanguageId 
 
COMMIT TRANSACTION 