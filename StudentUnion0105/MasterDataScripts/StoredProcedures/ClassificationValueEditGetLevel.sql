CREATE PROCEDURE ClassificationValueEditGetLevel ( @Id Int )
                                        AS 
                                        WITH StructureClassValue (ClassificationId
												, ParentId, Id,  Level)
                                        AS
                                        (
                                    	    SELECT 
												v.ClassificationId
												, v.ParentValueId
                                        		, v.Id
                                        		, 0 AS level
                                        	FROM dbClassificationValue AS v
                                        	WHERE v.Id = @Id 
                                        	UNION ALL
                                        	SELECT v.ClassificationId
												, v.ParentValueId
                                        		, v.Id
                                        		, level + 1
                                        	FROM dbClassificationValue AS v
                                        	JOIN StructureClassValue s
                                        		ON s.ParentId = v.Id
                                        	)

SELECT DateLevel "DateLevel", InDropDown "InDropDown" FROM dbClassificationLevel WHERE Sequence IN (
	SELECT 
    max(Level) + 1
    FROM StructureClassValue  
	WHERE StructureClassValue.ClassificationId IN  (SELECT ClassificationId FROM dbClassificationValue WHERE Id = @Id) )
	AND ClassificationId IN (SELECT ClassificationId FROM dbClassificationValue WHERE Id = @Id) 
