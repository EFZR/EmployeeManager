IF OBJECT_ID('dbo.Empleado', 'U') IS NOT NULL
    DROP TABLE dbo.Empleado;

IF OBJECT_ID('dbo.Usuario', 'U') IS NOT NULL
    DROP TABLE dbo.Usuario;

CREATE TABLE Empleado (
  Emp_Id INT PRIMARY KEY IDENTITY,
	Emp_Nombre VARCHAR(60),
	Emp_Puesto VARCHAR(60),
	Emp_Salario DECIMAL(10,2),
	Emp_FechaContratacion DATETIME
);

CREATE TABLE Usuario (
	Usu_Id INT PRIMARY KEY IDENTITY,
	Usu_NombreUsuario VARCHAR(60),
	Usu_Email VARCHAR(80),
	Usu_Password VARCHAR(255),
);