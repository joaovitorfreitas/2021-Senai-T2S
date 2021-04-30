CREATE DATABASE HROADS;

use HROADS

GO

/* Criando tabela TipoHabilidade*/
CREATE TABLE TipoHabilidade(
	IdTipoHabilidade int NOT NULL IDENTITY PRIMARY KEY,
	NomeTipoHabilidade VARCHAR (255) NOT NULL UNIQUE
);

GO

/* Criando tabela Habilidade*/
CREATE TABLE Habilidade(
	IdHabilidade int NOT NULL IDENTITY PRIMARY KEY,
	NomeHabilidade VARCHAR (255) NOT NULL UNIQUE,
	IdTipoHabilidade int FOREIGN KEY REFERENCES TipoHabilidade(IdTipoHabilidade)
);

GO

/* Criando tabela Classe*/
CREATE TABLE Classe(
	IdClasse int NOT NULL IDENTITY PRIMARY KEY,
	NomeDaClasse VARCHAR(255) NOT NULL UNIQUE,
);

GO

/* Criando tabela ClasseHabilidade*/
CREATE TABLE ClasseHabilidade(
	IdClasseHabilidade int NOT NULL IDENTITY PRIMARY KEY,
	IdClasse int FOREIGN KEY REFERENCES Classe(IdClasse),
	IdHabilidade int FOREIGN KEY REFERENCES Habilidade(IdHabilidade)
);


GO

/* Criando tabela Personagem*/
CREATE TABLE Personagem (
	IdPersonagem int NOT NULL IDENTITY PRIMARY KEY,
	Nome VARCHAR (255) NOT NULL UNIQUE,
	CapacidadeMaximaVida int NOT NULL,
	CapacidadeMaximaMana int NOT NULL,
	DataDeAtualizacao DATE NOT NULL,
	DataDeCriacao DATE NOT NULL,
	IdClasse int FOREIGN KEY REFERENCES Classe(IdClasse)
);

GO

/* Criando tabela TipoUsuario*/
CREATE TABLE TipoUsuario(
	IdTipoUsuario int NOT NULL IDENTITY PRIMARY KEY,
	NomeTipoUsuario VARCHAR (255) UNIQUE NOT NULL
);

GO

/* Criando tabela TipoUsuario*/
CREATE TABLE Usuario(
	IdUsuario int NOT NULL IDENTITY PRIMARY KEY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Senha VARCHAR (255) NOT NULL,
	IdTipoUsuario int FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);

