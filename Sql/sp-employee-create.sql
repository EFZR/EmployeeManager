CREATE PROCEDURE CreateEmployee(
	@emp_nombre AS VARCHAR(60),
	@emp_puesto AS VARCHAR(60),
	@emp_salario AS DECIMAL(10,2),
	@emp_fechaContratacion AS DATETIME
)
AS
BEGIN
INSERT INTO [dbo].[Empleado]
           ([emp_nombre]
           ,[emp_puesto]
           ,[emp_salario]
           ,[emp_fechaContratacion])
     VALUES
           (@emp_nombre
           ,@emp_puesto
           ,@emp_salario
           ,@emp_fechaContratacion);
END;