/****** Object:  Table [Cliente]    Script Date: 31/01/2023 14:12:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Login]') AND type in (N'U'))
BEGIN
	CREATE TABLE Login (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Instant NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

-- Adicione a restrição de unicidade na coluna Email
CREATE UNIQUE INDEX UX_Login_Email ON Login (Email);
END