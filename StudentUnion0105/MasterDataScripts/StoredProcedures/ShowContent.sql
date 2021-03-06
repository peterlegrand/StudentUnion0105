CREATE PROCEDURE 
[dbo].[ShowContent] 
  @Id int
AS
IF @Id IS NULL 
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
WHERE dbContent.ContentTypeId = @Id
END
