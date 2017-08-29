--Создаём базу
--CREATE DATABASE Employees;

GO

USE Employees;

GO

--Создаём таблицу фамилий
CREATE TABLE Surnames (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Surmanes PRIMARY KEY (id),
  name varchar(50) NOT NULL
  CONSTRAINT UniSurnames UNIQUE (name)
);

GO

--Создаём таблицу имен
CREATE TABLE Names (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Names PRIMARY KEY (id),
  name varchar(50) NOT NULL
  CONSTRAINT UniNames UNIQUE (name)
);

GO

--Создаём таблицу отчеств
CREATE TABLE Patronymics (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Patronymic PRIMARY KEY (id),
  name varchar(50) NOT NULL
  CONSTRAINT UniPatronymic UNIQUE (name)
);
GO

--Создаём таблицу должностей
CREATE TABLE Positions (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Position PRIMARY KEY (id),
  name varchar(255) NOT NULL
  CONSTRAINT UniPosition UNIQUE (name)
);
GO

--Создаём таблицу работников
CREATE TABLE Employees (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Empliyee PRIMARY KEY (id),
  idSurname int
  CONSTRAINT FK_Surname FOREIGN KEY (idSurname)
  REFERENCES Surnames (id),
  idName int
  CONSTRAINT FK_Name FOREIGN KEY (idName)
  REFERENCES Names (id),
  idPatronymic int
  CONSTRAINT FK_Patronymic FOREIGN KEY (idPatronymic)
  REFERENCES Patronymics (id),
  idPosition int
  CONSTRAINT FK_Position FOREIGN KEY (idPosition)
  REFERENCES Positions (id),
  admission varchar(30),
  dismissal varchar(30),
  photo varchar(255)
);

GO

--Процедура добавляет фамилию и возвращает её id
CREATE PROCEDURE getIdSurname @surname varchar(50),
@idSurname int OUTPUT
AS
BEGIN
  --Если фамилия заполнена
  IF (@surname IS NOT NULL)
  BEGIN
    SELECT
      @idSurname = id
    FROM Surnames
    WHERE name = @surname;
    --Если это новая фамилия добавляем
    IF (@idSurname IS NULL)
    BEGIN
      INSERT INTO Surnames
        VALUES (@surname);
      SELECT
        @idSurname = id
      FROM Surnames
      WHERE name = @surname;
    END
  END
  RETURN;
END

GO

--Процедура добавляет имя и возвращает его id
CREATE PROCEDURE getIdName @name varchar(50),
@idName int OUTPUT
AS
BEGIN
  --Если имя заполнено
  IF (@name IS NOT NULL)
  BEGIN
    SELECT
      @idName = id
    FROM Names
    WHERE name = @name;
    --Если это новое имя добавляем
    IF (@idName IS NULL)
    BEGIN
      INSERT INTO Names
        VALUES (@name);
      SELECT
        @idName = id
      FROM Names
      WHERE name = @name;
    END
  END
  RETURN;
END

GO

--Процедура добавляет отчество и возвращает его id
CREATE PROCEDURE getIdPatronymic @patronymic varchar(50),
@idPatronymic int OUTPUT
AS
BEGIN
  --Если отчество заполнено
  IF (@patronymic IS NOT NULL)
  BEGIN
    SELECT
      @idPatronymic = id
    FROM Patronymics
    WHERE name = @patronymic;
    --Если это новое отчество добавляем
    IF (@idPatronymic IS NULL)
    BEGIN
      INSERT INTO Patronymics
        VALUES (@patronymic);
      SELECT
        @idPatronymic = id
      FROM Patronymics
      WHERE name = @patronymic;
    END
  END
  RETURN;
END

GO

--Процедура добавляет должность и возвращает её id
CREATE PROCEDURE getIdPosition @position varchar(50),
@idPosition int OUTPUT
AS
BEGIN
  --Если должность заполнена
  IF (@position IS NOT NULL)
  BEGIN
    SELECT
      @idPosition = id
    FROM Positions
    WHERE name = @position;
    --Если это новая должность добавляем
    IF (@idPosition IS NULL)
    BEGIN
      INSERT INTO Positions
        VALUES (@position);
      SELECT
        @idPosition = id
      FROM Positions
      WHERE name = @position;
    END
  END
  RETURN;
END

GO

--Процедура вставки нового работника
CREATE PROCEDURE addEmployee @surname varchar(50),
@name varchar(50),
@patronymic varchar(50),
@position varchar(255),
@admission varchar(30),
@dismissal varchar(30),
@photo varchar(255)
AS
BEGIN
  DECLARE @idSurname int;
  DECLARE @idName int;
  DECLARE @idPatronymic int;
  DECLARE @idPosition int;
  EXECUTE getIdSurname @surname,
                       @idSurname OUTPUT;
  EXECUTE getIdName @name,
                    @idName OUTPUT;
  EXECUTE getIdPatronymic @patronymic,
                          @idPatronymic OUTPUT;
  EXECUTE getIdPosition @position,
                        @idPosition OUTPUT;
  INSERT INTO Employees
    VALUES (@idSurname, @idName, @idPatronymic, @idPosition, @admission, @dismissal, @photo);
END

GO

--Процедура изменения работника по id
CREATE PROCEDURE updateEmployeeById @id int,
@surname varchar(50),
@name varchar(50),
@patronymic varchar(50),
@position varchar(255),
@admission varchar(30),
@dismissal varchar(30),
@photo varchar(255)
AS
BEGIN
  IF (@id IS NOT NULL)
  BEGIN
    DECLARE @idSurname int;
    DECLARE @idName int;
    DECLARE @idPatronymic int;
    DECLARE @idPosition int;
    EXECUTE getIdSurname @surname,
                         @idSurname OUTPUT;
    EXECUTE getIdName @name,
                      @idName OUTPUT;
    EXECUTE getIdPatronymic @patronymic,
                            @idPatronymic OUTPUT;
    EXECUTE getIdPosition @position,
                          @idPosition OUTPUT;
    UPDATE Employees
    SET idSurname = @idSurname,
        idName = @idName,
        idPatronymic = @idPatronymic,
        idPosition = @idPosition,
        admission = @admission,
        dismissal = @dismissal,
        photo = @photo
    WHERE id = @id;
  END
  RETURN;
END
GO

--Процедура удаления работника по id
CREATE PROCEDURE deleteEmployeeById @id int
AS
BEGIN
  DELETE FROM Employees
  WHERE id = @id;
  RETURN;
END
GO

--Показать работников
CREATE PROCEDURE getEmployees
AS
BEGIN
  SELECT
    Employees.id,
    Surnames.name AS 'Surname',
    Names.name AS 'Name',
    Patronymics.name AS 'Patronymic',
    Positions.name AS 'Position',
    admission AS 'Admission',
    dismissal AS 'Dismissal',
    photo AS 'Photo'
  FROM (((Employees
  INNER JOIN Surnames
    ON idSurname = Surnames.id)
  INNER JOIN Names
    ON idName = Names.id)
  INNER JOIN Patronymics
    ON idPatronymic = Patronymics.id)
  INNER JOIN Positions
    ON idPosition = Positions.id
  RETURN;
END

GO

--Добавляем работников
EXECUTE addEmployee 'Аношкин',
                    'Василий',
                    'Иванович',
                    'Директор',
                    '№1 от 01.01.2017',
                    NULL,
                    '.\photos\anoshkinVA.jpg';

EXECUTE addEmployee 'Каренина',
                    'Анна',
                    'Петровна',
                    'Бухгалтер',
                    '№2 от 01.01.2017',
                    NULL,
                    '.\photos\kareninaAP.jpg';

EXECUTE addEmployee 'Прекрасная',
                    'Василиса',
                    'Васильевна',
                    'Менеджер по продажам',
                    '№3 от 02.01.2017',
                    NULL,
                    '.\photos\prekrasnajaVV.jpg';

EXECUTE addEmployee 'Рыжий',
                    'Петр',
                    'Игнатьевич',
                    'Грузчик',
                    '№6 от 06.01.2017',
                    '№12 от 19.02.2017',
                    '.\photos\ruzhiyPI.jpg';

EXECUTE addEmployee 'Беспалый',
                    'Игорь',
                    'Сергеевич',
                    'Экспедитор - грузчик',
                    '№18 от 24.02.2017',
                    NULL,
                    '.\photos\bespaliyIS.jpg';


--Добавляем пользователей в SQL Server.
EXECUTE sp_addlogin @loginame = 'director',
                    @passwd = 'director';
EXECUTE sp_addlogin @loginame = 'buhgalter',
                    @passwd = 'buhgalter';
EXECUTE sp_addlogin @loginame = 'allusers',
                    @passwd = 'allusers';
--Добавляем пользователей в базу данных.
USE Employees;
EXECUTE sp_grantdbaccess @loginame = 'director';
EXECUTE sp_grantdbaccess @loginame = 'buhgalter';
EXECUTE sp_grantdbaccess @loginame = 'allusers';

--Выдаём права на выполнение процедур
GRANT EXECUTE ON getEmployees TO director, buhgalter, allusers;
GRANT EXECUTE ON updateEmployeeById TO director, buhgalter;
GRANT EXECUTE ON addEmployee TO director, buhgalter;
GRANT EXECUTE ON deleteEmployeeById TO director;
