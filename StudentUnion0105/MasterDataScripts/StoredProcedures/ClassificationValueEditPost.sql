CREATE PROCEDURE ClassificationValueEditPost (
	@OId int
	, @LanguageId int
	, @FromDate DateTimeOffset
	, @ToDate DateTimeOffset
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @DropDownName nvarchar(50)
	, @PageName nvarchar(50)
	, @PageDescription nvarchar(max)
	, @HeaderName nvarchar(50)
	, @HeaderDescription nvarchar(max)
	, @TopicName nvarchar(50)
	)
AS
BEGIN TRANSACTION
UPDATE dbClassificationValue 
SET
	DateFrom = @FromDate
	, DateTo = @ToDate
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @OId;

UPDATE dbClassificationValueLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, DropDownName = @DropDownName
	, PageName = @PageName
	, PageDescription = @PageDescription
	, HeaderName = @HeaderName
	, HeaderDescription = @HeaderDescription
	, TopicName = @TopicName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ClassificationValueId = @OId
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


