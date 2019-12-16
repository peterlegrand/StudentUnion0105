CREATE PROCEDURE ClassificationPageSectionEditPost (
	@OId int
	, @LanguageId int
	, @Sequence int
	, @SectionTypeId int
	, @ShowSectionTitleName bit
	, @ShowSectionTitleDescription bit
	, @ShowContentTypeTitleName bit
	, @ShowContentTypeTitleDescription bit
	, @OneTwoColumns int
	, @ContentTypeId int
	, @SortById int
	, @MaxContent int
	, @HasPaging bit
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
	)
AS
BEGIN TRANSACTION
UPDATE dbClassificationPageSection 
SET
	Sequence = @Sequence
	, SectionTypeId = @SectionTypeId
	, ShowSectionTitleName = @ShowSectionTitleName
	, ShowSectionTitleDescription = @ShowSectionTitleDescription
	, ShowContentTypeTitleName = @ShowContentTypeTitleName
	, ShowContentTypeTitleDescription = @ShowContentTypeTitleDescription
	, OneTwoColumns = @OneTwoColumns
	, ContentTypeId = @ContentTypeId
	, SortById = @SortById
	, MaxContent = @MaxContent
	, HasPaging = @HasPaging
WHERE Id = @OId;

UPDATE dbClassificationPageSectionLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, TitleName = @TitleName
	, TitleDescription = @TitleDescription
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE PageSectionId = @OId
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


