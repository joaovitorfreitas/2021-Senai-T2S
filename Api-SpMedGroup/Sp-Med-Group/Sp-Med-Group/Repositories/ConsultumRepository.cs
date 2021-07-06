using Microsoft.EntityFrameworkCore;
using Sp_Med_Group.Contexts;
using Sp_Med_Group.Domains;
using Sp_Med_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp_Med_Group.Repositories
{
    public class ConsultumRepository : IConsultum
    {
        SpMedGroup ctx = new SpMedGroup();

        public Consultum BuscarConsultaMedicos(int idConsulta, int idMedico)
        {
            return ctx.Consulta.Where(d => d.IdMedicoNavigation.IdUsuario == idMedico)
                .Include(d => d.IdMedicoNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdSituacaoNavigation)
                .FirstOrDefault(d => d.IdConsulta == idConsulta);
        }

        public Consultum BuscarConsultaPacientes(int idConsulta, int idPacientes)
        {
            return ctx.Consulta.Where(d => d.IdPacienteNavigation.IdUsuario == idPacientes)
                .Include(d => d.IdMedicoNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdSituacaoNavigation)
                .FirstOrDefault(d => d.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public List<Consultum> ListarConsultaMedicos(int id)
        {
            return ctx.Consulta.Where(m => m.IdMedicoNavigation.IdUsuario == id).Include(m => m.IdMedicoNavigation).Include(p => p.IdPacienteNavigation).Include(s => s.IdSituacaoNavigation)
                   .Select(c => new Consultum()
                   {
                       IdConsulta = c.IdConsulta,
                       Descricao = c.Descricao,
                       DataConsulta = c.DataConsulta,

                       IdMedicoNavigation = new Medico()
                       {
                           IdMedico = c.IdMedicoNavigation.IdMedico,
                           NomeMedico = c.IdMedicoNavigation.NomeMedico,
                           IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                           IdClinica = c.IdMedicoNavigation.IdClinica,


                           IdEspecialidadeNavigation = new Especialidade()
                           {
                               IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                               NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                           }

                       },

                       IdPacienteNavigation = new Paciente()
                       {
                           IdPaciente = c.IdPacienteNavigation.IdPaciente,
                           NomePaciente = c.IdPacienteNavigation.NomePaciente,
                           DataNascimento = c.IdPacienteNavigation.DataNascimento,
                           Rg = c.IdPacienteNavigation.Rg,
                           Cpf = c.IdPacienteNavigation.Cpf,
                           Endereco = c.IdPacienteNavigation.Endereco
                       },

                       IdSituacaoNavigation = new Situacao()
                       {
                           IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                           Situacao1 = c.IdSituacaoNavigation.Situacao1
                       }

                   }).ToList();
        }

        public List<Consultum> ListarConsultaPacientes(int id)
        {
            return ctx.Consulta.Where(c => c.IdPacienteNavigation.IdUsuario == id).Include(m => m.IdMedicoNavigation).Include(p => p.IdPacienteNavigation).Include(s => s.IdSituacaoNavigation)
                 .Select(c => new Consultum()
                 {
                     IdConsulta = c.IdConsulta,
                     Descricao = c.Descricao,
                     DataConsulta = c.DataConsulta,

                     IdMedicoNavigation = new Medico()
                     {
                         IdMedico = c.IdMedicoNavigation.IdMedico,
                         NomeMedico = c.IdMedicoNavigation.NomeMedico,
                         IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                         IdClinica = c.IdMedicoNavigation.IdClinica,


                         IdEspecialidadeNavigation = new Especialidade()
                         {
                             IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                             NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                         }

                     },

                     IdPacienteNavigation = new Paciente()
                     {
                         IdPaciente = c.IdPacienteNavigation.IdPaciente,
                         NomePaciente = c.IdPacienteNavigation.NomePaciente,
                         DataNascimento = c.IdPacienteNavigation.DataNascimento,
                         Rg = c.IdPacienteNavigation.Rg,
                         Cpf = c.IdPacienteNavigation.Cpf,
                         Endereco = c.IdPacienteNavigation.Endereco
                     },

                     IdSituacaoNavigation = new Situacao()
                     {
                         IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                         Situacao1 = c.IdSituacaoNavigation.Situacao1
                     }

                 }).ToList();
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta.Include(m => m.IdMedicoNavigation).Include(p => p.IdPacienteNavigation).Include(s => s.IdSituacaoNavigation)
                 .Select(c => new Consultum()
                 {
                     IdConsulta = c.IdConsulta,
                     Descricao = c.Descricao,
                     DataConsulta = c.DataConsulta,

                     IdMedicoNavigation = new Medico()
                     {
                         IdMedico = c.IdMedicoNavigation.IdMedico,
                         NomeMedico = c.IdMedicoNavigation.NomeMedico,
                         IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                         IdClinica = c.IdMedicoNavigation.IdClinica,


                         IdEspecialidadeNavigation = new Especialidade()
                         {
                             IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                             NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                         }

                     },

                     IdPacienteNavigation = new Paciente()
                     {
                         IdPaciente = c.IdPacienteNavigation.IdPaciente,
                         NomePaciente = c.IdPacienteNavigation.NomePaciente,
                         DataNascimento = c.IdPacienteNavigation.DataNascimento,
                         Rg = c.IdPacienteNavigation.Rg,
                         Cpf = c.IdPacienteNavigation.Cpf,
                         Endereco = c.IdPacienteNavigation.Endereco
                     },

                     IdSituacaoNavigation = new Situacao()
                     {
                         IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                         Situacao1 = c.IdSituacaoNavigation.Situacao1
                     }

                 }).ToList();
        }

        public void MudarDescricao(int id, Consultum status)
        {
            Consultum consultaB = ctx.Consulta.Find(id);

            if(status.Descricao != null)
            {
                consultaB.Descricao = status.Descricao;
            }

            ctx.Update(consultaB);

            ctx.SaveChanges();
        }

        public void MudarSituacao(int id, string status)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == id);

            switch(status)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;

                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;

            }
            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
}
