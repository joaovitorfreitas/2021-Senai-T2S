--DML

USE T_Peoples;

INSERT INTO Funcionarios(Nome, Sobrenome) VALUES ('Catarina', 'Strada');

INSERT INTO Funcionarios(Nome, Sobrenome) VALUES ('Tadeu', 'Vitelli');

SELECT idFuncionarios, Nome, Sobrenome FROM Funcionarios WHERE Nome = 'Catarina'
