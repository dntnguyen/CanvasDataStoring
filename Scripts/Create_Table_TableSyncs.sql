/****** Object:  Table [dbo].[TableSync]    Script Date: 7/29/2022 1:37:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS 
(
	SELECT * 
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' 
    AND  TABLE_NAME = 'TableSync'
)
BEGIN
	CREATE TABLE [dbo].[TableSync](
		[TableName] [varchar](50) NOT NULL,
		[LatestSequence] [int] NULL,
		[CreationTime] [datetime] NULL,
		[LastModificationTime] [datetime] NULL,
	 CONSTRAINT [PK_TableSyncs] PRIMARY KEY CLUSTERED 
	(
		[TableName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END 
ELSE
BEGIN
	PRINT('--------Table Existed--------')
END

GO


