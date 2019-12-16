CREATE PROCEDURE ClassificationPageSectionCreatePost (
	@PId int
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

INSERT INTO dbClassificationPageSection (
	ClassificationPageId 
	, Sequence
	, SectionTypeId
	, ShowSectionTitleName
	, ShowSectionTitleDescription 
	, ShowContentTypeTitleName
	, ShowContentTypeTitleDescription 
	, OneTwoColumns
	, ContentTypeId
	, SortById
	, MaxContent
	, HasPaging
	)
VALUES (
	@PId
	, @Sequence
	, @SectionTypeId
	, @ShowSectionTitleName
	, @ShowSectionTitleDescription 
	, @ShowContentTypeTitleName
	, @ShowContentTypeTitleDescription 
	, @OneTwoColumns
	, @ContentTypeId
	, @SortById
	, @MaxContent
	, @HasPaging
	);

DECLARE @NewClassificationPageSectionId int	= scope_identity();

INSERT INTO dbClassificationPageSectionLanguage (
	PageSectionId
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, TitleName
	, TitleDescription
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewClassificationPageSectionId
	, @LanguageId
	, @Name
	, @Description
	, @MouseOver
	, @MenuName
	, @TitleName
	, @TitleDescription
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


