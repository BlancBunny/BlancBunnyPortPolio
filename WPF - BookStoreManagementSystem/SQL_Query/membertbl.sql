USE [bookrentalshop]
GO

/****** Object:  Table [dbo].[membertbl]    Script Date: 2021-07-20 ¿ÀÈÄ 12:34:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[membertbl](
	[Idx] [int] IDENTITY(1,1) NOT NULL,
	[Names] [nvarchar](50) NOT NULL,
	[Levels] [char](1) NULL,
	[Addr] [nvarchar](100) NULL,
	[Mobile] [varchar](13) NULL,
	[Email] [varchar](50) NULL,
	[userID] [varchar](20) NOT NULL,
	[passwords] [varchar](max) NOT NULL,
	[lastLoginDt] [datetime] NULL,
	[loginIpAddr] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


