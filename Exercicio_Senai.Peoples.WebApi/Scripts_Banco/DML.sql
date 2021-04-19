--DML

USE T_Peoples;

INSERT INTO Funcionarios(Nome, Sobrenome) VALUES ('Catarina', 'Strada');

INSERT INTO Funcionarios(Nome, Sobrenome) VALUES ('Tadeu', 'Vitelli');

INSERT INTO Funcionarios(Nome, Sobrenome,Datanascimento) VALUES ('Marceli', 'Costa', '2021/11/22');

SELECT IdFuncionarios, CONCAT (Nome, ' ', Sobrenome) AS [Nome completo], Datanascimento FROM Funcionarios;

SELECT Nome,Sobrenome,Datanascimento FROM Funcionarios ORDER BY Nome DESC

SELECT idFuncionarios, Nome, Sobrenome, Datanascimento FROM Funcionarios

