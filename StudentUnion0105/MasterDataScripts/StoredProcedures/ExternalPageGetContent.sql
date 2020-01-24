CREATE PROCEDURE ExternalPageGetContent (
	 @PageSectionId int
	, @PagingId int)
AS
Declare @MaxPerPage int;
SELECT @MaxPerPage = dbPageSection.MaxContent FROM dbPageSection WHERE Id = @PageSectionId;

SELECT 
	dbContent.Id OId
	, dbContent.Title
	, dbContent.Description
	, dbPageSection.Id PId
FROM dbContent
JOIN dbPageSection
	ON dbPageSection.ContentTypeId = dbContent.ContentTypeId
	OR dbPageSection.ContentTypeId = NULL
WHERE dbContent.ContentStatusId = 4
	AND dbContent.SecurityLevel =1
	AND dbPageSection.Id = @PageSectionId
ORDER BY dbContent.CreatedDate 
	OFFSET @PagingId * @MaxPerPage ROWS
	FETCH NEXT @MaxPerPage ROWS ONLY
