using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class ClasseHabilidade
    {
        public int IdClasseHabilidade { get; set; }
        [Required(ErrorMessage = "IdClasse não cadastrada")]
        public int? IdClasse { get; set; }
        [Required(ErrorMessage = "IdHabilidade não cadastrada")]
        public int? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
