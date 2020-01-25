CREATE PROCEDURE HomeIndexAdminGetTables 
AS
SELECT Id, TableDescription FROM dbTableName ORDER BY TableDescription
