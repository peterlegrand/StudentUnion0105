CREATE PROCEDURE 
	[dbo].[ProcessTemplateStepFieldUpdate] 
	 @Id int											--0
	, @StatusId int									--1
	, @NewSequence int								--2
	
	
AS
DECLARE @StepId int;
DECLARE @OldSequence int; 
SELECT @StepId = StepId FROM dbProcessTemplateStepField WHERE Id = @Id;
SELECT @OldSequence = Sequence FROM dbProcessTemplateStepField WHERE Id = @Id;
BEGIN TRANSACTION
IF @OldSequence < @NewSequence
UPDATE 
	s 
SET Sequence = Sequence - 1
FROM dbProcessTemplateStepField s 
WHERE Sequence <= @NewSequence
	AND Sequence > @OldSequence
	AND StepId = @StepId;
ELSE
UPDATE s
	
SET Sequence= Sequence + 1
FROM dbProcessTemplateStepField  s WHERE Sequence >= @NewSequence
	AND Sequence < @OldSequence
	AND StepId = @StepId;


UPDATE 
	dbProcessTemplateStepField 
SET 
	 dbProcessTemplateStepField.StatusId = @StatusId
	, dbProcessTemplateStepField.Sequence =@NewSequence
WHERE 
	dbProcessTemplateStepField.Id = @Id


COMMIT TRANSACTION
