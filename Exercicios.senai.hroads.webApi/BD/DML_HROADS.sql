USE HROADS


INSERT INTO TipoUsuario (NomeTipoUsuario) VALUES ('adm'), ('jogador');

INSERT INTO Usuario (Email, Senha, IdTipoUsuario) VALUES ('adm@adm.com', '123', 1), ('jogador@jogador.com', '123', 3);

INSERT INTO TipoHabilidade (NomeTipoHabilidade) VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia');

INSERT INTO Habilidade (NomeHabilidade, IdTipoHabilidade) VALUES ('Lança Mortal', 1), ('Escudo Supremo', 2), ('Recuperar Vida', 3);

INSERT INTO Classe (NomeDaClasse) VALUES ('Bárbaro'), ('Cruzado'), ('Caçadora de Demônios'), ('Monge'), ('Necromante'), ('Feiticeiro'), ('Arcanista');

INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (1,1);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (1,2);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (2,2);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (3,1);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (4,3);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (4,2);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (5,NULL);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (6,3);
INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade) VALUES (7,NULL);

INSERT INTO Personagem (Nome,CapacidadeMaximaVida,CapacidadeMaximaMana,DataDeAtualizacao,DataDeCriacao,IdClasse) VALUES ('DeuBug', 100, 80,'2021-04-26','2021-04-26',1), ('BitBug', 70,100,'2021-04-26','2021-04-26', 4), ('Fer8', 75,60,'2021-04-26','2021-04-26',7)
