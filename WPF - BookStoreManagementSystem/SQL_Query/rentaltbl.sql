USE [bookrentalshop]
GO

/****** Object:  Table [dbo].[rentaltbl]    Script Date: 2021-07-20 오후 12:35:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[rentaltbl](
	[Idx] [int] IDENTITY(1,1) NOT NULL,
	[memberIdx] [int] NULL,
	[bookIdx] [int] NULL,
	[rentalDate] [date] NULL,
	[returnDate] [date] NULL,
	[rentalState] [char](1) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[rentaltbl]  WITH CHECK ADD  CONSTRAINT [FK__rentaltbl__bookI__2C3393D0] FOREIGN KEY([bookIdx])
REFERENCES [dbo].[bookstbl] ([Idx])
GO

ALTER TABLE [dbo].[rentaltbl] CHECK CONSTRAINT [FK__rentaltbl__bookI__2C3393D0]
GO

ALTER TABLE [dbo].[rentaltbl]  WITH CHECK ADD  CONSTRAINT [FK__rentaltbl__membe__2B3F6F97] FOREIGN KEY([memberIdx])
REFERENCES [dbo].[membertbl] ([Idx])
GO

ALTER TABLE [dbo].[rentaltbl] CHECK CONSTRAINT [FK__rentaltbl__membe__2B3F6F97]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'R(''대여중''), T(''반납'')' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'rentaltbl', @level2type=N'COLUMN',@level2name=N'rentalState'
GO


