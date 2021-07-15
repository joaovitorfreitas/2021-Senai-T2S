using Sp_Med_Group.Contexts;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Repositories
{
    public class SituacaoRepository : ISituacao
    {

        SpMedGroup ctx = new SpMedGroup();

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
