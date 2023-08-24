using jovemProgramadorWeb1.Data.Repositorio.Interfaces;
using jovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace jovemProgramadorWeb1.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAluno();
            return View(aluno);
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();
            try
            {
                cep = cep.Replace("-", "");



                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");



                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });



                }
                else
                {
                    TempData["MsgErro"] = "Erro na busca do endereço,tente novamente";
                    return View("Endereco");
                }


            }
            catch (Exception)
            {



                throw;
            }

            TempData["MsgSucess"] = "Sucesso!";
            return View("Endereco", endereco);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
                TempData["MsgSucesso"] = "Aluno adicionado com sucesso";
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";

            }

            
            return RedirectToAction("Index");


        }

        public IActionResult Excluir()
        {
            return View();
        }
        public IActionResult ExcluirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.ExcluirAluno(aluno);
                TempData["MsgSucesso"] = "Aluno excluido com sucesso";
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao excluir aluno";

            }

            
            return RedirectToAction("Index");


        }
        public IActionResult EditarAluno(int id)
        {
            return RedirectToAction();
        }
        public IActionResult EditarAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.EditarAluno(aluno);

            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao editar cadastro do aluno";

            }

            TempData["MsgSucesso"] = "Cadastro do aluno alterado com sucesso com sucesso";
            return RedirectToAction("Index");

        }

    }
}
