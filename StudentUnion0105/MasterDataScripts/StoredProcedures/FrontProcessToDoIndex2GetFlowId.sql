CREATE PROCEDURE FrontProcessToDoIndex2GetFlowId AS 
SELECT Id IntValue FROM DbProcessTemplateFlow
WHERE ProcessTemplateFromStepId <> 0  ORDER BY Id

