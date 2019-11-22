CREATE PROCEDURE HomePageGetContent (@LanguageId int, @PageSectionId int, @SecurityLevel int, @PagingId int)
AS
Declare @MaxPerPage int;
SELECT @MaxPerPage = dbPageSection.MaxContent FROM dbPageSection WHERE Id = @PageSectionId;

SELECT 
	dbContent.Id OId
	, dbContent.Title
	, dbContent.Description
FROM dbContent
JOIN dbPageSection
	ON dbPageSection.ContentTypeId = dbContent.ContentTypeId
	OR dbPageSection.ContentTypeId = NULL
WHERE dbContent.ContentStatusId = 1
	AND dbContent.SecurityLevel <= @SecurityLevel
	AND dbPageSection.Id = @PageSectionId
ORDER BY dbContent.CreatedDate 
	OFFSET @PagingId * @MaxPerPage ROWS
	FETCH NEXT @MaxPerPage ROWS ONLY
