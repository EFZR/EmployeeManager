CREATE PROCEDURE UpdateEmployees(
	@emp_id AS INT,
	@emp_nombre AS VARCHAR(60),
	@emp_puesto AS VARCHAR(60),
	@emp_salario AS DECIMAL(10,2),
	@emp_fechaContratacion AS DATETIME
)
AS
BEGIN
UPDATE [dbo].[Empleado]
   SET [emp_nombre] = @emp_nombre
      ,[emp_puesto] = @emp_puesto
      ,[emp_salario] = @emp_salario
      ,[emp_fechaContratacion] = @emp_fechaContratacion
 WHERE [emp_id] = @emp_id;
END;