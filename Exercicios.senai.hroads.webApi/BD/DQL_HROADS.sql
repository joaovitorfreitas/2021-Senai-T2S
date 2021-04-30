USE HROADS

/* Seleciona a tabela de usuario com a do tipo usuario*/
SELECT Usuario.Email, Usuario.Senha,TipoUsuario.NomeTipoUsuario 
FROM Usuario INNER JOIN TipoUsuario 
ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario;

/* Seleciona as classes e habilidade contidas em cada*/
SELECT
	Classe.NomeDaClasse,
	Habilidade.NomeHabilidade,
	TipoHabilidade.NomeTipoHabilidade,
	ClasseHabilidade.IdClasseHabilidade
FROM ClasseHabilidade 
INNER JOIN Classe ON Classe.IdClasse = ClasseHabilidade.IdClasse 
INNER JOIN Habilidade ON ClasseHabilidade.IdHabilidade = Habilidade.IdHabilidade 
INNER JOIN TipoHabilidade ON Habilidade.IdTipoHabilidade = TipoHabilidade.IdTipoHabilidade

/* Seleciona o personagem Com NomeDaClasse*/
SELECT
	Personagem.IdPersonagem,
	Personagem.Nome,
	Personagem.CapacidadeMaximaVida,
	Personagem.CapacidadeMaximaMana,
	Personagem.DataDeCriacao,
	Personagem.DataDeAtualizacao,
	Classe.NomeDaClasse
FROM Personagem 
INNER JOIN Classe ON Personagem.IdClasse = Classe.IdClasse

