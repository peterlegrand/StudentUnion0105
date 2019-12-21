CREATE PROCEDURE [dbo].[PageCreatePost]
	(@PageStatusId int
	, @PageTypeId int
	, @ShowTitle bit
	, @ShowDesciption bit
	, @UserId varchar(450)
	, @LanguageId int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
	, @MenuName nvarchar (max)
	, @Title nvarchar (max)
	, @TitleDescription nvarchar (max)
	)
AS
BEGIN TRANSACTION 
 
	INSERT 
		dbPage (PageStatusId, PageTypeId, ShowTitleName, ShowTitleDescription, CreatorId, CreatedDate, ModifierId, ModifiedDate)
	VALUES (@PageStatusId, @PageTypeId, @ShowTitle, @ShowDesciption ,@UserId, getdate(), @UserId, GETDATE());

	DECLARE @NewPageId int	= scope_identity();
	
	INSERT dbPageLanguage (
		PageId 
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
		@NewPageId
		, @LanguageId
		, @Name
		, @Description
		, @MouseOver
		, @MenuName
		, @Title
		, @TitleDescription
		, @UserId
		, getdate()
		, @UserId
		, getdate()
	) 


COMMIT TRANSACTION 



