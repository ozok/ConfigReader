USE [master]
GO
/****** Object:  Database [Configurations]    Script Date: 8.01.2023 16:53:28 ******/
CREATE DATABASE [Configurations]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Configurations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Configurations] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Configurations] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Configurations] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Configurations] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Configurations] SET ARITHABORT OFF 
GO
ALTER DATABASE [Configurations] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Configurations] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Configurations] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Configurations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Configurations] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Configurations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Configurations] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Configurations] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Configurations] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Configurations] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Configurations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Configurations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Configurations] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Configurations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Configurations] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Configurations] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Configurations] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Configurations] SET RECOVERY FULL 
GO
ALTER DATABASE [Configurations] SET  MULTI_USER 
GO
ALTER DATABASE [Configurations] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Configurations] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Configurations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Configurations] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Configurations] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Configurations] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Configurations', N'ON'
GO
ALTER DATABASE [Configurations] SET QUERY_STORE = ON
GO
ALTER DATABASE [Configurations] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Configurations]
GO
/****** Object:  User [config]    Script Date: 8.01.2023 16:53:29 ******/
CREATE USER [config] FOR LOGIN [config] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [config]
GO
ALTER ROLE [db_datareader] ADD MEMBER [config]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [config]
GO
/****** Object:  Table [dbo].[Configurations]    Script Date: 8.01.2023 16:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](128) NOT NULL,
	[ApplicationName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Configurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Configurations] ON 
GO
INSERT [dbo].[Configurations] ([Id], [IsActive], [Name], [Value], [ApplicationName]) VALUES (1, 1, N'SiteName', N'boyner.com.tr3', N'SERVICE-A')
GO
INSERT [dbo].[Configurations] ([Id], [IsActive], [Name], [Value], [ApplicationName]) VALUES (2, 1, N'IsBasketEnabled', N'1', N'SERVICE-B')
GO
INSERT [dbo].[Configurations] ([Id], [IsActive], [Name], [Value], [ApplicationName]) VALUES (3, 1, N'MaxItemCount', N'50', N'SERVICE-A')
GO
INSERT [dbo].[Configurations] ([Id], [IsActive], [Name], [Value], [ApplicationName]) VALUES (4, 1, N'Test1', N'Value1', N'SERVICE-A')
GO
INSERT [dbo].[Configurations] ([Id], [IsActive], [Name], [Value], [ApplicationName]) VALUES (5, 1, N'test2', N'value2', N'SERVICE-B')
GO
SET IDENTITY_INSERT [dbo].[Configurations] OFF
GO
USE [master]
GO
ALTER DATABASE [Configurations] SET  READ_WRITE 
GO
