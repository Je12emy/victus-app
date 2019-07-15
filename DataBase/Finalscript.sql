USE [master]
GO
/****** Object:  Database [Victus]    Script Date: 7/14/2019 9:09:32 PM ******/
CREATE DATABASE [Victus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Victus', FILENAME = N'C:\Bases de Datos\Victus\Data\Victus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Victus_log', FILENAME = N'C:\Bases de Datos\Victus\Log\Victus_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Victus] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Victus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Victus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Victus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Victus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Victus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Victus] SET ARITHABORT OFF 
GO
ALTER DATABASE [Victus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Victus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Victus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Victus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Victus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Victus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Victus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Victus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Victus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Victus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Victus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Victus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Victus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Victus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Victus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Victus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Victus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Victus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Victus] SET  MULTI_USER 
GO
ALTER DATABASE [Victus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Victus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Victus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Victus] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Victus] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Victus]
GO
/****** Object:  Table [dbo].[CatalogoAlimentos]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogoAlimentos](
	[CodigoAlimento] [int] IDENTITY(1,1) NOT NULL,
	[NombreAlimento] [nvarchar](50) NOT NULL,
	[CaloriasPromedio] [float] NOT NULL,
 CONSTRAINT [PK_CatalogoAlimentos] PRIMARY KEY CLUSTERED 
(
	[CodigoAlimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodigoDatos] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [nvarchar](30) NOT NULL,
	[Peso] [float] NOT NULL,
	[Altura] [int] NOT NULL,
	[Edad] [int] NOT NULL,
	[IMC] [float] NOT NULL,
	[CantidadAgua] [int] NOT NULL,
	[FechaDatos] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[CodigoDatos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dieta]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dieta](
	[CodigoDieta] [int] IDENTITY(1,1) NOT NULL,
	[CorreoCliente] [nvarchar](30) NOT NULL,
	[FechaDieta] [datetime] NOT NULL,
	[CodigoHarris] [nvarchar](5) NOT NULL,
	[Objetivo] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Dieta] PRIMARY KEY CLUSTERED 
(
	[CodigoDieta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HarrisBen]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HarrisBen](
	[CodigoHarrisBen] [int] IDENTITY(1,1) NOT NULL,
	[FactorActividad] [float] NOT NULL,
	[TMB] [float] NOT NULL,
	[NivelCalorico] [float] NOT NULL,
	[FechaHarris] [datetime] NOT NULL,
	[Correo] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_HarrisBen] PRIMARY KEY CLUSTERED 
(
	[CodigoHarrisBen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medida]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medida](
	[CodigoMedida] [int] IDENTITY(1,1) NOT NULL,
	[FechaMedida] [datetime] NOT NULL,
	[CorreoCliente] [nvarchar](30) NOT NULL,
	[BicepDerecho] [float] NOT NULL,
	[BicepIzquierdo] [float] NOT NULL,
	[Abdomen] [float] NOT NULL,
	[CuadricepIzquierdo] [float] NOT NULL,
	[CuadricepDerecho] [float] NOT NULL,
	[PantorrillaIzquierda] [float] NOT NULL,
	[PantorrillaDerecha] [float] NOT NULL,
 CONSTRAINT [PK_Medida] PRIMARY KEY CLUSTERED 
(
	[CodigoMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Correo] [nvarchar](30) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Nombre] [nvarchar](15) NOT NULL,
	[Apellido1] [nvarchar](15) NOT NULL,
	[Apellido2] [nvarchar](15) NOT NULL,
	[Genero] [bit] NOT NULL,
	[Contraseña] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Persona_1] PRIMARY KEY CLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelacionAlimentos]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelacionAlimentos](
	[CodigoRelacion] [int] IDENTITY(1,1) NOT NULL,
	[CodigoDieta] [int] NOT NULL,
	[CodigoAlimento] [int] NOT NULL,
 CONSTRAINT [PK_RelacionAlimentos] PRIMARY KEY CLUSTERED 
(
	[CodigoRelacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([Correo])
REFERENCES [dbo].[Persona] ([Correo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO
ALTER TABLE [dbo].[Dieta]  WITH CHECK ADD  CONSTRAINT [FK_Dieta_Persona] FOREIGN KEY([CorreoCliente])
REFERENCES [dbo].[Persona] ([Correo])
GO
ALTER TABLE [dbo].[Dieta] CHECK CONSTRAINT [FK_Dieta_Persona]
GO
ALTER TABLE [dbo].[HarrisBen]  WITH CHECK ADD  CONSTRAINT [FK_HarrisBen_Persona] FOREIGN KEY([Correo])
REFERENCES [dbo].[Persona] ([Correo])
GO
ALTER TABLE [dbo].[HarrisBen] CHECK CONSTRAINT [FK_HarrisBen_Persona]
GO
ALTER TABLE [dbo].[Medida]  WITH CHECK ADD  CONSTRAINT [FK_Medida_Persona] FOREIGN KEY([CorreoCliente])
REFERENCES [dbo].[Persona] ([Correo])
GO
ALTER TABLE [dbo].[Medida] CHECK CONSTRAINT [FK_Medida_Persona]
GO
ALTER TABLE [dbo].[RelacionAlimentos]  WITH CHECK ADD  CONSTRAINT [FK_RelacionAlimentos_CatalogoAlimentos] FOREIGN KEY([CodigoAlimento])
REFERENCES [dbo].[CatalogoAlimentos] ([CodigoAlimento])
GO
ALTER TABLE [dbo].[RelacionAlimentos] CHECK CONSTRAINT [FK_RelacionAlimentos_CatalogoAlimentos]
GO
ALTER TABLE [dbo].[RelacionAlimentos]  WITH CHECK ADD  CONSTRAINT [FK_RelacionAlimentos_Dieta] FOREIGN KEY([CodigoDieta])
REFERENCES [dbo].[Dieta] ([CodigoDieta])
GO
ALTER TABLE [dbo].[RelacionAlimentos] CHECK CONSTRAINT [FK_RelacionAlimentos_Dieta]
GO
/****** Object:  StoredProcedure [dbo].[GetDieta]    Script Date: 7/14/2019 9:09:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDieta] @Correo nvarchar(30) = NULL, @CodigoDieta int = NULL
AS
  SELECT
    alimento.NombreAlimento,
    alimento.CaloriasPromedio
  FROM RelacionAlimentos AS relacion
  LEFT JOIN dieta AS dieta
    ON relacion.CodigoDieta LIKE dieta.CodigoDieta
  LEFT JOIN CatalogoAlimentos AS alimento
    ON relacion.CodigoAlimento LIKE alimento.CodigoAlimento
  WHERE dieta.CorreoCliente = @Correo
  AND dieta.CodigoDieta = @CodigoDieta
	


GO
USE [master]
GO
ALTER DATABASE [Victus] SET  READ_WRITE 
GO
