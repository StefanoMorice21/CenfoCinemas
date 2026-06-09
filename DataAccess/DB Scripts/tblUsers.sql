USE [cenfocinemas-db]
GO

/****** Objeto: Table [dbo].[tblUser] Fecha de script: 6/9/2026 12:48:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[UserCode] [nvarchar](25) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[Status] [nvarchar](2) NOT NULL,
	[Phone] [int] NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


