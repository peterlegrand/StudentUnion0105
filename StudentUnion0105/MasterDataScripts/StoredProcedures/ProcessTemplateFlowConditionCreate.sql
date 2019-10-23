CREATE PROCEDURE [dbo].[ProcessTemplateFlowConditionCreate] (
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
	, @ComparisonOperator  nvarchar(max))	--10
	AS 
	DECLARE @NullConditionInt int, @LatestChar char(1) , @NoOfConditions int
	
	
SELECT @NoOfConditions = COUNT(*) FROM dbProcessTemplateFlowCondition WHERE dbProcessTemplateFlowCondition.ProcessTemplateFlowId = @Id 
IF @NoOfConditions = 0 
SET @LatestChar = 'A'
ELSE
	SELECT @LatestChar = CHAR(ASCII(MAX(ConditionCharacter)) + 1) FROM dbProcessTemplateFlowCondition WHERE dbProcessTemplateFlowCondition.ProcessTemplateFlowId = @Id

	IF @ConditionInt = 0 
	 SET @NullConditionInt = NULL ;
	ELSE 
	SET @NullConditionInt = @ConditionInt

	BEGIN TRANSACTION

	INSERT INTO  dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateFieldId
	, ProcessTemplateConditionTypeId
	, ProcessTemplateFlowConditionString
	, ProcessTemplateFlowConditionInt
	, ProcessTemplateFlowConditionDate
	, ComparisonOperator
	, ConditionCharacter)
	VALUES (
	@Id
	, @FieldId
	, @ConditionTypeId
	, @ConditionString
	, @ConditionInt
	, @ConditionDate
	, @ComparisonOperator
	, @LatestChar)
	DECLARE @Id2 int	= scope_identity();
	INSERT INTO dbProcessTemplateFlowConditionLanguage (
	FlowConditionId
	, LanguageId
	, Name
	, Description
	, MouseOver
	, ModifiedDate
	, CreatedDate
	)
	VALUES
	(@Id2
	, @LanguageId
	, @Name
	, @Description
	, @MouseOver
	, getdate()
	, getdate()
	)
	
	COMMIT TRANSACTION
GO


