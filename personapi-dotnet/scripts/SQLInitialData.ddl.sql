IF NOT EXISTS (SELECT [name] FROM [sys].[databases] WHERE [name] = 'persona_db')
BEGIN
	PRINT 'La base de datos persona_db no existe.'
END
ELSE
BEGIN
	USE [persona_db]
	
	IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'persona')
	BEGIN
		PRINT 'La tabla persona no existe en persona_db.'
	END
	ELSE
	BEGIN
		INSERT INTO persona (cc, nombre, apellido, genero, edad) VALUES
		(789456123, 'Tom Cruise', 'Smith', 'M', 50),
		(987654321, 'Angelina Jolie', 'Garcia', 'F', 35),
		(456321789, 'Albert Einstein', 'Lopez', 'M', 42),
		(951753852, 'Marie Curie', 'Gonzalez', 'F', 27),
		(369258147, 'Steve Jobs', 'Martinez', 'M', 63),
		(111111111, 'Oprah Winfrey', 'Ramirez', 'F', 45),
		(222222222, 'Keanu Reeves', 'Perez', 'M', 56),
		(333333333, 'Emma Watson', 'Rodriguez', 'F', 30),
		(444444444, 'Bill Gates', 'Hernandez', 'M', 61),
		(555555555, 'Madonna', 'Sanchez', 'F', 55);
		PRINT 'Se han insertado 10 datos en persona.'
	END

	IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'profesion')
	BEGIN 
	  PRINT 'La tabla profesion no existe en persona_db.'
	END
	ELSE
	BEGIN
		INSERT INTO profesion (id, nom, des) VALUES
		(1, 'Desarrollador de videojuegos', 'Crea y diseña videojuegos'),
		(2, 'Ingeniero mecánico', 'Diseña y desarrolla sistemas mecánicos'),
		(3, 'Arquitecto de software', 'Diseña y desarrolla sistemas de software'),
		(4, 'Doctor en ciencias', 'Investiga y estudia diversas ciencias'),
		(5, 'Psicólogo clínico', 'Diagnostica y trata trastornos mentales y emocionales'),
		(6, 'Ingeniero ambiental', 'Diseña y supervisa proyectos ambientales'),
		(7, 'Contador público', 'Lleva la contabilidad de empresas y organizaciones'),
		(8, 'Diseñador de moda', 'Crea diseños de moda para diversas ocasiones'),
		(9, 'Chef ejecutivo', 'Cocina y diseña menús para restaurantes de lujo'),
		(10, 'Periodista de investigación', 'Investiga y reporta noticias importantes');
		PRINT 'Se han insertado 10 datos en profesion.'
	END

	IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'estudios')
BEGIN
  PRINT 'La tabla estudios no existe.'
END
ELSE
BEGIN
	INSERT INTO estudios (id_prof, cc_per, fecha, univer) VALUES 
	(1, 6543634, '2005-02-12', 'Universidad de Harvard'),
	(2, 5634634, '2005-12-16', 'Universidad de Cambridge'),
	(3, 8678656, '2008-02-22', 'Universidad de Oxford'),
	(4, 6548455, '2000-02-26', 'Universidad de Stanford'),
	(2, 6565666, '2000-01-07', 'Universidad de Cambridge'),
	(1, 8886666, '2004-01-17', 'Universidad de Harvard'),
	(3, 4536443, '2005-03-17', 'Universidad de Oxford'),
	(4, 2233344, '2004-05-27', 'Universidad de Stanford'),
	(2, 7575744, '2005-03-03', 'Universidad de Cambridge'),
	(1, 8768568, '2006-02-24', 'Universidad de Harvard');
	PRINT 'Se han insertado 10 datos en estudios.'
END

IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'telefono')
BEGIN
  PRINT 'La tabla telefono no existe en persona_db.'
END
ELSE
BEGIN
	INSERT INTO telefono (num, oper, duenio) VALUES 
	('3453466', 'Claro', 346346),
	('7676666', 'Telmex', 7654746),
	('4445555', 'Virgin', 8767664),
	('3466666', 'Claro', 9977696),
	('4544443', 'Telmex', 3379797),
	('3222445', 'Virgin', 9977665),
	('5555555', 'Claro', 5656857),
	('3333444', 'Telmex', 8785686),
	('5666662', 'Virgin', 8588868),
	('8868686', 'Claro', 9939396);
	PRINT 'Se han insertado 10 datos en telefono.'
END
