IF EXISTS (SELECT [name] FROM [sys].[databases] WHERE [name] = 'persona_db')
BEGIN
	USE [persona_db]

	IF EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'telefono')
	BEGIN
	  -- Table `arq_per_db`.`telefono`
	  DROP TABLE [telefono];
	  PRINT 'La tabla telefono ha sido borrada de persona_db.'
	END
	ELSE
	BEGIN
		PRINT 'La tabla telefono no existe en persona_db.'
	END

	IF EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'estudios')
	BEGIN
	  -- Table `arq_per_db`.`estudios`
	  DROP TABLE [estudios];
	  PRINT 'La tabla estudios ha sido borrada de persona_db.'
	END
	ELSE
	BEGIN
		PRINT 'La tabla estudios no existe en persona_db.'
	END

	IF EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'profesion')
	BEGIN
	  -- Table `arq_per_db`.`profesion`
	  DROP TABLE [profesion];
	  PRINT 'La tabla profesion ha sido borrada de persona_db.'
	END
	ELSE
	BEGIN
		PRINT 'La tabla profesion no existe en persona_db.'
	END

	IF EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'persona')
	BEGIN
	  -- Table `persona_db`.`persona`
	  DROP TABLE [persona];
	  PRINT 'La tabla persona ha sido borrada de persona_db.'
	END
	ELSE
	BEGIN
		 PRINT 'La tabla persona no existe en persona_db.'
	END

	USE [master]

	DROP DATABASE IF EXISTS [persona_db];
	PRINT 'La base de datos persona_db ha sido borrada.'
END
ELSE
BEGIN
	PRINT 'La base de datos persona_db no existe.'
END
GO
