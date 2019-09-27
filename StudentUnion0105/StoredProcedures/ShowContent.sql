CREATE PROCEDURE 
[dbo].[ShowContent] 
  @ContentTypeId int
AS
IF @ContentTypeId IS NULL 
BEGIN
SELECT dbContent.Id
	, dbContent.Title
	, dbContent.Description
	, dbContent.ContentStatusId
	, dbContent.ContentTypeId
	, dbContent.CreatedDate
	, dbContent.CreatorId
	, dbContent.LanguageId
	, dbContent.ModifiedDate
	, dbContent.ModifierId
	, dbContent.OrganizationId
	, dbContent.ProjectId
	, dbContent.SecurityLevel
FROM dbContent
END
ELSE
BEGIN
SELECT dbContent.Id
	, dbContent.Title
	, dbContent.Description
	, dbContent.ContentStatusId
	, dbContent.ContentTypeId
	, dbContent.CreatedDate
	, dbContent.CreatorId
	, dbContent.LanguageId
	, dbContent.ModifiedDate
	, dbContent.ModifierId
	, dbContent.OrganizationId
	, dbContent.ProjectId
	, dbContent.SecurityLevel
FROM dbContent
WHERE dbContent.ContentTypeId = @ContentTypeId
END
