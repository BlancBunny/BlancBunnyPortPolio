USE [bookrentalshop]
GO

/****** Object:  Table [dbo].[bookstbl]    Script Date: 2021-07-20 ¿ÀÈÄ 12:34:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bookstbl](
	[Idx] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](50) NULL,
	[Division] [varchar](8) NOT NULL,
	[Names] [nvarchar](100) NULL,
	[ReleaseDate] [date] NULL,
	[ISBN] [varchar](200) NULL,
	[Price] [decimal](10, 0) NULL,
	[Descriptions] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[bookstbl]  WITH CHECK ADD FOREIGN KEY([Division])
REFERENCES [dbo].[divtbl] ([Division])
GO


