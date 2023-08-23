using jovemProgramadorWeb1.Data.Repositorio.Interfaces;
using jovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace jovemProgramadorWeb1.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {



        private readonly BancoContexto _bancoContexto;



        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }



        public List<Aluno> BuscarAluno()
        {
            return _bancoContexto.Aluno.ToList();

        }
        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        public void ExcluirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
        public void EditarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }

    }
}

