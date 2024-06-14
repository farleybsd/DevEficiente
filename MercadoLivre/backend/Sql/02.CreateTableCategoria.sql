
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Verificar se a tabela Categoria existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Categoria]') AND type in (N'U'))
BEGIN
    CREATE TABLE Categoria (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(255) NOT NULL
    );
END
GO

-- Verificar se o índice único já existe e, se não, criar
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[Categoria]') AND name = 'UX_Categoria_Nome')
BEGIN
    CREATE UNIQUE INDEX UX_Categoria_Nome ON Categoria (Nome);
END
GO