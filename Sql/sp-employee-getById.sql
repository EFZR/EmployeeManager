CREATE PROCEDURE GetEmployeeById(@emp_id AS INT)
AS
BEGIN
    SELECT
		[emp_id]
		,[emp_nombre]
		,[emp_puesto]
		,[emp_salario]
		,[emp_fechaContratacion]
  FROM
		[dbo].[Empleado]
  WHERE [emp_id] = @emp_id;
END;