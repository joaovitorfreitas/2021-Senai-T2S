using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
        }

        public int IdHabilidade { get; set; }
        [Required(ErrorMessage = "NomeHabilidade não cadastrada")]
        public string NomeHabilidade { get; set; }
        [Required(ErrorMessage = "IdTipoHabilidade não cadastrada")]
        public int? IdTipoHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
    }
}
