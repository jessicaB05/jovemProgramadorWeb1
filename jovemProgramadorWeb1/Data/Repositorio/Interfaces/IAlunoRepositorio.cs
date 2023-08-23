using jovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace jovemProgramadorWeb1.Data.Repositorio.Interfaces
{


    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAluno();

        void InserirAluno(Aluno aluno);
        void ExcluirAluno(Aluno aluno);
        void EditarAluno(Aluno aluno);
    }
}
