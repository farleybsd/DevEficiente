
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Verificar se a tabela Categoria existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Category]') AND type in (N'U'))
BEGIN
    CREATE TABLE Category (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL
    );
END
GO

-- Verificar se o índice único já existe e, se não, criar
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Category]') AND name = 'UX_Category_Name')
BEGIN
    CREATE UNIQUE INDEX UX_Categoria_Name ON Category (Name);
END
GO