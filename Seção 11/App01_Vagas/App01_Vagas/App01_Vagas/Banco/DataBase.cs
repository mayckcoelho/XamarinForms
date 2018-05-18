using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App01_Vagas.Modelos;
using Xamarin.Forms;
using System.Linq;

namespace App01_Vagas.Banco
{
    public class DataBase
    {
        private SQLiteConnection _conexao;

        public DataBase()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);

            _conexao.CreateTable<Vaga>();
        }

        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(p => p.NomeVaga.Contains(palavra)).ToList();
        }

        public Vaga Obter(int id)
        {
            return _conexao.Table<Vaga>().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
