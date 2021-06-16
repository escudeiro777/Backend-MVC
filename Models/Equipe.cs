using System;
using System.Collections.Generic;
using System.IO;

namespace EplayersMVC.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string NomeEquipe { get; set; }
        public string Imagem { get; set; }

        private const string CAMINHO = "Database/equipe.csv";

        public Equipe()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Equipe e)
        {
            return $"{e.IdEquipe};{e.NomeEquipe};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void CadastrarNovaEquipe(Equipe e)
        {
            string[] linha = { Preparar(e) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodasEquipes()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.NomeEquipe = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}