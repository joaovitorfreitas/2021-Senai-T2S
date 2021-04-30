using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        [Required(ErrorMessage = "Classe não cadastrada")]
        public string NomeDaClasse { get; set; }

        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
