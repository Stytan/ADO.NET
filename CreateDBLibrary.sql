--Создаём базу
CREATE DATABASE Library;

GO

USE Library;

GO

--Создаём таблицу фамилий
CREATE TABLE Authors (
  id int IDENTITY (1, 1) NOT NULL
  CONSTRAINT PK_Authors PRIMARY KEY (id),
  firstname nvarchar(50),
  lastname nvarchar(50)
);

GO
--Добавляем авторов
INSERT INTO Authors(firstname,lastname) VALUES('Александр', 'Бабушкин');
INSERT INTO Authors(firstname,lastname) VALUES('Азер', 'Абдулла');
INSERT INTO Authors(firstname,lastname) VALUES('Генрих', 'Багиян');
INSERT INTO Authors(firstname,lastname) VALUES('Сергей', 'Бельков');
INSERT INTO Authors(firstname,lastname) VALUES('Лидия', 'Бельская');
INSERT INTO Authors(firstname,lastname) VALUES('Нина', 'Бойко');
INSERT INTO Authors(firstname,lastname) VALUES('Мария', 'Табак');
