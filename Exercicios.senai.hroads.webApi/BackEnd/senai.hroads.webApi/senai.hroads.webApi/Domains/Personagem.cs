using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        [Required(ErrorMessage = "Nome não cadastrada")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CapacidadeMaximaVida não cadastrada")]
        public int CapacidadeMaximaVida { get; set; }
        [Required(ErrorMessage = "CapacidadeMaximaMana não cadastrada")]
        public int CapacidadeMaximaMana { get; set; }
        [Required(ErrorMessage = "DataDeAtualizacao não cadastrada")]
        public DateTime DataDeAtualizacao { get; set; }
        [Required(ErrorMessage = "DataDeCriacao não cadastrada")]
        public DateTime DataDeCriacao { get; set; }
        [Required(ErrorMessage = "IdClasse não cadastrada")]
        public int? IdClasse { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
