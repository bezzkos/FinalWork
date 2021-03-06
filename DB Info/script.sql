USE [master]
GO
/****** Object:  Database [KnowledgeCheckingSystemDB]    Script Date: 20.03.2017 15:55:52 ******/
CREATE DATABASE [KnowledgeCheckingSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KnowledgeCheckingSystemDB', FILENAME = N'C:\Users\Nadin\KnowledgeCheckingSystemDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KnowledgeCheckingSystemDB_log', FILENAME = N'C:\Users\Nadin\KnowledgeCheckingSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KnowledgeCheckingSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [KnowledgeCheckingSystemDB]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [uniqueidentifier] NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[IsCorrect] [bit] NOT NULL,
	[QuestionFk] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RelatedEntitiesNames] [nvarchar](50) NOT NULL,
	[FK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [uniqueidentifier] NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[IsMultiple] [bit] NOT NULL,
	[TestFk] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolesUsers]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesUsers](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RolesUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tests]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CategoryFk] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersTests]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTests](
	[UserId] [uniqueidentifier] NOT NULL,
	[TestId] [uniqueidentifier] NOT NULL,
	[Mark] [float] NOT NULL,
	[IsPassed] [bit] NOT NULL,
	[AttemptDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UsersTests] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TestId] ASC,
	[AttemptDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionFk])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Tests] FOREIGN KEY([TestFk])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Tests]
GO
ALTER TABLE [dbo].[RolesUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsers_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolesUsers] CHECK CONSTRAINT [FK_RolesUsers_Roles]
GO
ALTER TABLE [dbo].[RolesUsers]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[RolesUsers] CHECK CONSTRAINT [FK_RolesUsers_Users]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_Categories] FOREIGN KEY([CategoryFk])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_Categories]
GO
ALTER TABLE [dbo].[UsersTests]  WITH CHECK ADD  CONSTRAINT [FK_UsersTests_Tests] FOREIGN KEY([TestId])
REFERENCES [dbo].[Tests] ([Id])
GO
ALTER TABLE [dbo].[UsersTests] CHECK CONSTRAINT [FK_UsersTests_Tests]
GO
ALTER TABLE [dbo].[UsersTests]  WITH CHECK ADD  CONSTRAINT [FK_UsersTests_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersTests] CHECK CONSTRAINT [FK_UsersTests_Users]
GO
/****** Object:  StoredProcedure [dbo].[Answers.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answers.Create]
	@Id uniqueidentifier,
	@Answer nvarchar(MAX),
	@IsCorrect bit,
	@QuestionFk uniqueidentifier
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Answers]
           ([Id]
           ,[Answer]
           ,[IsCorrect]
           ,[QuestionFk])
     VALUES
           (@Id
           ,@Answer
           ,@IsCorrect
           ,@QuestionFk)
END

GO
/****** Object:  StoredProcedure [dbo].[Answers.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answers.Delete]
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Answers]
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Answers.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answers.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Answer]
      ,[IsCorrect]
      ,[QuestionFk]
  FROM [dbo].[Answers]
END

GO
/****** Object:  StoredProcedure [dbo].[Answers.GetAllByFk]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answers.GetAllByFk]
	@Fk uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Answer]
      ,[IsCorrect]
      ,[QuestionFk]
  FROM [dbo].[Answers]
  WHERE [QuestionFk] = @Fk
END

GO
/****** Object:  StoredProcedure [dbo].[Answers.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Answers.GetById]
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Answer]
      ,[IsCorrect]
      ,[QuestionFk]
  FROM [dbo].[Answers]
  WHERE [Id] = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Answers.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answers.Update]
	@Id uniqueidentifier,
	@Answer nvarchar(MAX),
	@IsCorrect bit,
	@QuestionFk uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Answers]
   SET [Id] = @Id
      ,[Answer] = @Answer
      ,[IsCorrect] = @IsCorrect 
      ,[QuestionFk]= @QuestionFk
	  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Categories.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Categories.Create]
	@Id uniqueidentifier,
	@Title nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Categories]
           ([Id]
           ,[Title])
     VALUES
           (@Id
           ,@Title)
END

GO
/****** Object:  StoredProcedure [dbo].[Categories.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Categories.Delete]
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Categories]
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Categories.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Categories.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Title]
  FROM [dbo].[Categories]
END

GO
/****** Object:  StoredProcedure [dbo].[Categories.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Categories.GetById]
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Title]
  FROM [dbo].[Categories]
  WHERE [Id] = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Categories.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Categories.Update]
	@Id uniqueidentifier,
	@Title nvarchar(50),
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Categories]
   SET [Id] = @Id
      ,[Title] = @Title
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[Images.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Images.Create] 
@Id uniqueidentifier,
@Type nvarchar(50),
@Name nvarchar(50),
@RelatedEntitiesNames nvarchar(50),
@FK uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Images]
           ([Id]
           ,[Type]
           ,[Name]
           ,[RelatedEntitiesNames]
           ,[FK])
     VALUES
           (@Id
           ,@Type
           ,@Name
           ,@RelatedEntitiesNames
           ,@FK)
END


GO
/****** Object:  StoredProcedure [dbo].[Images.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Images.Delete] 
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Images]
	WHERE [Id] = @Id
	SET @Count = @@ROWCOUNT
END


GO
/****** Object:  StoredProcedure [dbo].[Images.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Images.GetAll] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Type]
      ,[Name]
      ,[RelatedEntitiesNames]
      ,[FK]
  FROM [dbo].[Images]
END


GO
/****** Object:  StoredProcedure [dbo].[Images.GetByFk]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Images.GetByFk]
	@FK uniqueidentifier,
	@RelatedEntitiesNames nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Type]
      ,[Name]
      ,[RelatedEntitiesNames]
      ,[FK]
  FROM [dbo].[Images]
  WHERE [FK] = @FK AND [RelatedEntitiesNames] = @RelatedEntitiesNames
END


GO
/****** Object:  StoredProcedure [dbo].[Images.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Images.GetById]
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Type]
      ,[Name]
      ,[RelatedEntitiesNames]
      ,[FK]
  FROM [dbo].[Images]
  WHERE [Id] = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[Images.GetByName]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Images.GetByName]
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Type]
      ,[Name]
      ,[RelatedEntitiesNames]
      ,[FK]
  FROM [dbo].[Images]
  WHERE [Name] = @Name
END


GO
/****** Object:  StoredProcedure [dbo].[Images.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Images.Update] 
	@Id uniqueidentifier,
	@Type nvarchar(50),
	@Name nvarchar(50),
	@RelatedEntitiesNames nvarchar(50),
	@FK uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Images]
   SET [Id] = @Id
      ,[Type] = @Type
      ,[Name] = @Name
      ,[RelatedEntitiesNames] = @RelatedEntitiesNames
      ,[FK] = @FK
	  WHERE [Id] = @Id
	  SET @Count = @@ROWCOUNT
END


GO
/****** Object:  StoredProcedure [dbo].[Questions.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Questions.Create]
	@Id uniqueidentifier,
	@Question nvarchar(MAX),
	@IsActive bit,
	@IsRequired bit,
	@IsMultiple bit,
	@TestFk uniqueidentifier
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Questions]
           ([Id]
           ,[Question]
           ,[IsActive]
           ,[IsRequired]
           ,[IsMultiple]
           ,[TestFk])
     VALUES
           (@Id
           ,@Question
           ,@IsActive
           ,@IsRequired
		   ,@IsMultiple
		   ,@TestFk)
END

GO
/****** Object:  StoredProcedure [dbo].[Questions.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Questions.Delete]
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Questions]
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Questions.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Questions.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Question]
      ,[IsActive]
      ,[IsRequired]
      ,[IsMultiple]
      ,[TestFk]
  FROM [dbo].[Questions]
END

GO
/****** Object:  StoredProcedure [dbo].[Questions.GetAllByFk]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Questions.GetAllByFk]
	@Fk uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Question]
      ,[IsActive]
      ,[IsRequired]
      ,[IsMultiple]
      ,[TestFk]
  FROM [dbo].[Questions]
  WHERE [TestFk] = @Fk
END

GO
/****** Object:  StoredProcedure [dbo].[Questions.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Questions.GetById]
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Question]
      ,[IsActive]
      ,[IsRequired]
      ,[IsMultiple]
      ,[TestFk]
  FROM [dbo].[Questions]
  WHERE [Id] = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Questions.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Questions.Update]
	@Id uniqueidentifier,
	@Question nvarchar(MAX),
	@IsActive bit,
	@IsRequired bit,
	@IsMultiple bit,
	@TestFk uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Questions]
   SET [Id] = @Id
      ,[Question] = @Question
      ,[IsActive] = @IsActive
      ,[IsRequired] = @IsRequired
      ,[IsMultiple] = @IsMultiple
      ,[TestFk] = @TestFk
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Roles.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Roles.Create] 
@Id uniqueidentifier,
@Name nvarchar(50)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Roles]
           ([Id]
           ,[Name])
     VALUES
           (@Id
           ,@Name)
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles.Delete] 
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Roles]
	WHERE [Id] = @Id
	  SET @Count = @@ROWCOUNT
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles.GetAll] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Name]
  FROM [dbo].[Roles]
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Roles.GetById] 
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT [Id]
      ,[Name]
  FROM [dbo].[Roles]
  WHERE [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.GetByName]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Roles.GetByName]
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 [Id]
      ,[Name]
  FROM [dbo].[Roles]
  WHERE [Name] = @Name
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.IsExist]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Roles.IsExist] 
	@Name nvarchar(50)
AS
BEGIN
	SELECT CASE WHEN EXISTS (
    SELECT *
    FROM [dbo].[Roles]
    WHERE [Name] = @Name)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT)
	END
END


GO
/****** Object:  StoredProcedure [dbo].[Roles.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Roles.Update] 
	@Id uniqueidentifier,
	@Name nvarchar(50),
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Roles]
	SET [Id] = @Id
      ,[Name] = @Name
	  WHERE [Id] = @Id
	  SET @Count = @@ROWCOUNT
END


GO
/****** Object:  StoredProcedure [dbo].[RolesUsers.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RolesUsers.Create]
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[RolesUsers]
           ([UserId]
		   ,[RoleId])
     VALUES
           (@UserId
           ,@RoleId)
END

GO
/****** Object:  StoredProcedure [dbo].[RolesUsers.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RolesUsers.Delete]
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[RolesUsers]
  WHERE [UserId] = @UserId AND [RoleId] = @RoleId
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[RolesUsers.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RolesUsers.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [UserId]
      ,[RoleId]
  FROM [dbo].[RolesUsers]
END

GO
/****** Object:  StoredProcedure [dbo].[RolesUsers.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[RolesUsers.GetById]
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [UserId]
      ,[RoleId]
  FROM [dbo].[RolesUsers]
  WHERE [UserId] = @UserId AND [RoleId] = @RoleId
END

GO
/****** Object:  StoredProcedure [dbo].[RolesUsers.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RolesUsers.Update]
	@UserId uniqueidentifier,
	@RoleId uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[RolesUsers]
   SET [UserId] = @UserId
      ,[RoleId] = @RoleId
  WHERE [UserId] = @UserId AND [RoleId] = @RoleId
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tests.Create]
	@Id uniqueidentifier,
	@Title nvarchar(50),
	@Description nvarchar(MAX),
	@IsActive bit,
	@CategoryFk uniqueidentifier
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Tests]
           ([Id]
           ,[Title]
           ,[Description]
           ,[IsActive]
           ,[CategoryFk])
     VALUES
           (@Id
           ,@Title
           ,@Description
           ,@IsActive
		   ,@CategoryFk)
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tests.Delete]
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[Tests]
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tests.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Title]
      ,[Description]
      ,[IsActive]
      ,[CategoryFk]
  FROM [dbo].[Tests]
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.GetAllByFk]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tests.GetAllByFk]
	@Fk uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Title]
      ,[Description]
      ,[IsActive]
      ,[CategoryFk]
  FROM [dbo].[Tests]
  WHERE [CategoryFk] = @Fk
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Tests.GetById]
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[Title]
      ,[Description]
      ,[IsActive]
      ,[CategoryFk]
  FROM [dbo].[Tests]
  WHERE [Id] = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Tests.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tests.Update]
	@Id uniqueidentifier,
	@Title nvarchar(50),
	@Description nvarchar(MAX),
	@IsActive bit,
	@CategoryFk uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[Tests]
   SET [Id] = @Id
      ,[Title] = @Title
      ,[Description] = @Description
      ,[IsActive] = @IsActive
      ,[CategoryFk] = @CategoryFk 
  WHERE [Id] = @Id
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Users.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Users.Create] 
@Id uniqueidentifier,
@UserName nvarchar(50),
@Password nvarchar(Max),
@Salt nvarchar(Max)
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Users]
           ([Id]
           ,[UserName]
           ,[Password]
           ,[Salt])
     VALUES
           (@Id
           ,@UserName
           ,@Password
           ,@Salt)
END

GO
/****** Object:  StoredProcedure [dbo].[Users.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Users.Delete] 
	@Id uniqueidentifier,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Users]
	WHERE [Id] = @Id
	  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[Users.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Users.GetAll] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id]
      ,[UserName]
      ,[Password]
      ,[Salt]
  FROM [dbo].[Users]
END

GO
/****** Object:  StoredProcedure [dbo].[Users.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Users.GetById] 
	@Id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT [Id]
      ,[UserName]
      ,[Password]
      ,[Salt]
  FROM [dbo].[Users]
  WHERE [Id]=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[Users.GetByName]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Users.GetByName]
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 [Id]
      ,[UserName]
      ,[Password]
      ,[Salt]
  FROM [dbo].[Users]
  WHERE [UserName] = @UserName
END
GO
/****** Object:  StoredProcedure [dbo].[Users.IsExist]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Users.IsExist]
	@UserName nvarchar(50)
AS
BEGIN
	SELECT CASE WHEN EXISTS (
    SELECT TOP 1 *
    FROM [dbo].[Users]
    WHERE [UserName] = @UserName)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Users.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Users.Update] 
	@Id uniqueidentifier,
	@UserName nvarchar(50),
	@Password nvarchar(Max),
	@Salt nvarchar(Max),
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[Users]
	SET [Id] = @Id
      ,[UserName] = @UserName
      ,[Password] = @Password
      ,[Salt] = @Salt
	  WHERE [Id] = @Id
	  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[UserTest.Create]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserTest.Create]
	@UserId uniqueidentifier,
	@TestId uniqueidentifier,
	@Mark float,
	@IsPassed bit,
	@AttemptDateTime datetime
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[UsersTests]
           ([UserId]
           ,[TestId]
           ,[Mark]
		   ,[IsPassed]
           ,[AttemptDateTime])
     VALUES
           (@UserId
           ,@TestId
           ,@Mark
		   ,@IsPassed
           ,@AttemptDateTime)
END
GO
/****** Object:  StoredProcedure [dbo].[UserTest.Delete]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserTest.Delete]
	@UserId uniqueidentifier,
	@TestId uniqueidentifier,
	@AttemptDateTime datetime,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [dbo].[UsersTests]
  WHERE [UserId] = @UserId AND [TestId] = @TestId AND [AttemptDateTime] = @AttemptDateTime
  SET @Count = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[UserTest.GetAll]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserTest.GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [UserId]
      ,[TestId]
      ,[Mark]
      ,[IsPassed]
      ,[AttemptDateTime]
  FROM [dbo].[UsersTests]
END
GO
/****** Object:  StoredProcedure [dbo].[UserTest.GetById]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserTest.GetById]
	@UserId uniqueidentifier,
	@TestId uniqueidentifier,
	@AttemptDateTime datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [UserId]
      ,[TestId]
      ,[Mark]
      ,[IsPassed]
      ,[AttemptDateTime]
  FROM [dbo].[UsersTests]
  WHERE [UserId] = @UserId AND [TestId] = @TestId AND [AttemptDateTime] = @AttemptDateTime
END
GO
/****** Object:  StoredProcedure [dbo].[UserTest.Update]    Script Date: 20.03.2017 15:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserTest.Update]
	@UserId uniqueidentifier,
	@TestId uniqueidentifier,
	@Mark float,
	@IsPassed bit,
	@AttemptDateTime datetime,
	@Count int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[UsersTests]
   SET [UserId] = @UserId
      ,[TestId] = @TestId
      ,[Mark] = @Mark
      ,[IsPassed] = @IsPassed
      ,[AttemptDateTime] = @AttemptDateTime
  WHERE [UserId] = @UserId AND [TestId] = @TestId AND [AttemptDateTime] = @AttemptDateTime
  SET @Count = @@ROWCOUNT
END
GO
USE [master]
GO
ALTER DATABASE [KnowledgeCheckingSystemDB] SET  READ_WRITE 
GO
