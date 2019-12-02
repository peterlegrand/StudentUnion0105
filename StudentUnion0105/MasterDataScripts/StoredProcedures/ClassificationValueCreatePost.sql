CREATE PROCEDURE ClassificationValueCreatePost (
	 @PId int
	, @ParentId int
	, @FromDate DateTimeOffset
	, @ToDate DateTimeOffset
	, @ModifierId nvarchar(450)
	, @LanguageId int
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
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, DateFrom, DateTo, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (@PId, @ParentId, @FromDate, @ToDate, @ModifierId, @ModifierId, getdate(), getdate())


DECLARE @NewClassificationValueId int	= scope_identity();

INSERT INTO dbClassificationValueLanguage (ClassificationValueId, LanguageId, Name, Description, MenuName, MouseOver, DropDownName, PageName, PageDescription, HeaderName, HeaderDescription, TopicName, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (@NewClassificationValueId , @LanguageId, @Name, @Description, @MenuName, @MouseOver, @DropDownName, @PageName, @PageDescription, @HeaderName, @HeaderDescription, @TopicName, @ModifierId, @ModifierId, getdate(), getdate())
COMMIT TRANSACTION
