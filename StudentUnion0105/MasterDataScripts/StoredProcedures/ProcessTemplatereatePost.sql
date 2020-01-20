CREATE PROCEDURE ProcessTemplateCreatePost (
	 @LanguageId int
	, @ProcessTemplateGroupId int
	, @ShowInPersonalCalendar bit
	, @ShowInEventCalendar bit
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbProcessTemplate (
	ProcessTemplateGroupId 
	, ShowInPersonalCalendar 
	, ShowInEventCalendar
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@ProcessTemplateGroupId
	, @ShowInPersonalCalendar
	, @ShowInEventCalendar
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewProcessTemplateId int	= scope_identity();

INSERT INTO dbProcessTemplateLanguage (
	ProcessTemplateId
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewProcessTemplateId
	, @LanguageId
	, @Name
	, @Description
	, @MouseOver
	, @MenuName
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


