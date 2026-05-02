USE [GestionEmpleadosDB]
GO

/****** Objeto: Table [dbo].[Empleados] Fecha de script: 02/05/2026 01:58:55 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](80) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Departamento] [nvarchar](100) NOT NULL,
	[Salario] [decimal](18, 2) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Empleados] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO

ALTER TABLE [dbo].[Empleados] ADD  DEFAULT ((1)) FOR [Activo]
GO

ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD CHECK  (([Salario]>=(400000) AND [Salario]<=(10000000)))
GO


