CREATE PROCEDURE [dbo].[PageCreatePost]
	(@PageStatusId int
	, @PageTypeId int
	, @UserId varchar(450)
	, @LanguageId int
	, @Name nvarchar(max)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(max)
	, @MenuName nvarchar (max)
	, @Title nvarchar (max)
	, @PageDescription nvarchar (max)
	)
AS
BEGIN TRANSACTION 
 
	INSERT 
		dbPage (PageStatusId, PageTypeId, CreatorId, CreatedDate, ModifierId, ModifiedDate)
	VALUES (@PageStatusId, @PageTypeId,@UserId, getdate(), @UserId, GETDATE());

	DECLARE @NewPageId int	= scope_identity();
	
	INSERT dbPageLanguage (
		PageId
		, LanguageId
		, Name
		, Description
		, MouseOver
		, MenuName
		, Title
		, PageDescription
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
		, @PageDescription
		, @UserId
		, getdate()
		, @UserId
		, getdate()
	) 


COMMIT TRANSACTION 



