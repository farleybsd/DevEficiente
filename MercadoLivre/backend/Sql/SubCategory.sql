/****** Object:  Table [GrupoEmails]    Script Date: 31/01/2023 15:46:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SubCategory]') AND type in (N'U'))
BEGIN
	CREATE TABLE [SubCategory](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[CategoryId] [int] NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		
				PRIMARY KEY (Id),
			CONSTRAINT FK_CategoryId_Category FOREIGN KEY (CategoryId)
			REFERENCES Category(Id) ON UPDATE CASCADE
	)
END