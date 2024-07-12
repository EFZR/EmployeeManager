CREATE PROCEDURE GetEmployees
AS
BEGIN
	SELECT
		[emp_id]
		,[emp_nombre]
		,[emp_puesto]
		,[emp_salario]
		,[emp_fechaContratacion]
	FROM
		[dbo].[Empleado];
END;