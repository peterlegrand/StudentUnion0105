CREATE PROCEDURE ProcessTemplateFlowConditionUpdate (
	@Id int                             --0
	, @LanguageId int					--1
	, @Name nvarchar(max)				--2
	, @Description nvarchar(max)		--3
	, @MouseOver nvarchar(max)			--4
	, @ConditionTypeId int				--5
	, @FieldId int						--6
	, @ConditionString  nvarchar(max)	--7
	, @ConditionInt int					--8
	, @ConditionDate datetime2(7)		--9
	, @ComparisonOperatorId Int			--10
	, @DataTypeId int)
	AS 
	DECLARE @NullConditionInt int, @LatestChar char(1)
	

	IF @ConditionInt = 0 
	 SET @NullConditionInt = NULL ;
	ELSE 
	SET @NullConditionInt = @ConditionInt

	BEGIN TRANSACTION

	UPDATE dbProcessTemplateFlowCondition SET
		ProcessTemplateFieldId =@FieldId
		, ProcessTemplateConditionTypeId = @ConditionTypeId
		, ProcessTemplateFlowConditionString = @ConditionString
		, ProcessTemplateFlowConditionInt = @NullConditionInt
		, ProcessTemplateFlowConditionDate = @ConditionDate
		, ComparisonOperatorId = @ComparisonOperatorId
		, DataTypeId = @DataTypeId
	WHERE Id = @Id

	UPDATE dbProcessTemplateFlowConditionLanguage SET
		dbProcessTemplateFlowConditionLanguage.Name = @Name
		, dbProcessTemplateFlowConditionLanguage.Description = @Description
		, dbProcessTemplateFlowConditionLanguage.MouseOver = @MouseOver
		, dbProcessTemplateFlowConditionLanguage.ModifiedDate = getdate()
	WHERE 
		dbProcessTemplateFlowConditionLanguage.FlowConditionId = @Id
		AND dbProcessTemplateFlowConditionLanguage.LanguageId = @LanguageId
	COMMIT TRANSACTION