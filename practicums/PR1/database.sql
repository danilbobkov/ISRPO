-- Создание базы данных
CREATE DATABASE TestDB;
GO

USE TestDB;
GO

-- Таблица вопросов
CREATE TABLE Questions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    QuestionText NVARCHAR(500) NOT NULL,
    Option1 NVARCHAR(200) NOT NULL,
    Option2 NVARCHAR(200) NOT NULL,
    Option3 NVARCHAR(200) NOT NULL,
    Option4 NVARCHAR(200) NOT NULL,
    CorrectOption INT NOT NULL CHECK (CorrectOption BETWEEN 1 AND 4)
);
GO

-- Таблица пользователей
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NULL,
    Score INT NULL
);
GO

-- Таблица ответов пользователей
CREATE TABLE UserAnswers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
    QuestionId INT NOT NULL FOREIGN KEY REFERENCES Questions(Id),
    SelectedOption INT NOT NULL CHECK (SelectedOption BETWEEN 0 AND 4)  -- 0 = не ответил
);
GO

-- Заполнение 15 вопросами
INSERT INTO Questions (QuestionText, Option1, Option2, Option3, Option4, CorrectOption) VALUES
('Что такое C#?', 'Язык программирования', 'База данных', 'Операционная система', 'Текстовый редактор', 1),
('Какой оператор используется для ветвления в C#?', 'if', 'for', 'while', 'switch', 1),
('Как объявить целочисленную переменную?', 'int x;', 'integer x;', 'var x;', 'x int;', 1),
('Какой тип данных используется для хранения текста?', 'string', 'int', 'bool', 'double', 1),
('Что такое класс?', 'Шаблон для создания объектов', 'Тип переменной', 'Метод', 'Свойство', 1),
('Какой модификатор делает член класса доступным только внутри этого класса?', 'private', 'public', 'protected', 'internal', 1),
('Какой метод является точкой входа в консольное приложение?', 'Main', 'Start', 'Run', 'Begin', 1),
('Что такое наследование?', 'Механизм создания нового класса на основе существующего', 'Способ упаковки данных', 'Способ переопределения методов', 'Способ скрытия данных', 1),
('Какой цикл выполняется хотя бы один раз?', 'do-while', 'while', 'for', 'foreach', 1),
('Что такое массив?', 'Набор элементов одного типа', 'Функция', 'Класс', 'Интерфейс', 1),
('Какой оператор используется для обработки исключений?', 'try-catch', 'if-else', 'switch', 'throw', 1),
('Что такое интерфейс?', 'Контракт, который определяет набор методов', 'Абстрактный класс', 'Структура', 'Делегат', 1),
('Какой ключевое слово используется для создания объекта?', 'new', 'create', 'object', 'this', 1),
('Что такое свойство в C#?', 'Член класса, предоставляющий доступ к полю', 'Переменная', 'Метод', 'Событие', 1),
('Что такое делегат?', 'Тип, который ссылается на метод', 'Класс', 'Структура', 'Интерфейс', 1);
GO