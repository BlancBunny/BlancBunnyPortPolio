USE [IoTData]
GO

/****** Object:  Table [dbo].[PhotoResisterTbl]    Script Date: 2021-07-20 ¿ÀÈÄ 12:38:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PhotoResisterTbl](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[currTime] [varchar](50) NULL,
	[value] [int] NULL,
	[simFlag] [bit] NULL,
 CONSTRAINT [PK_PhotoResisterTbl] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


