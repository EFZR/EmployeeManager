CREATE PROCEDURE DeleteEmployees(@emp_id AS INT) AS BEGIN
DELETE
FROM [dbo].[Empleado]
WHERE [emp_id] = @emp_id END;