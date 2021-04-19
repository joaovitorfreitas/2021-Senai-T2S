 --DDL

CREATE DATABASE T_Peoples;

Use T_Peoples;

CREATE TABLE Funcionarios(
	idFuncionarios INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255)  NOT NULL,
	Sobrenome VARCHAR(255)  NOT NULL
);

ALTER TABLE Funcionarios ADD Datanascimento DATE;