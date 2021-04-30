using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Email não cadastrada")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha não cadastrada")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O campo senha precisa ter no mínimo 3 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "IdTipoUsuario não cadastrada")]
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
