using System.Collections.Generic;

namespace EplayersMVC.Models
{
    public interface IEquipe
    {
         void CadastrarNovaEquipe(Equipe e);

         List<Equipe> LerTodasEquipes();

         void Alterar (Equipe e);

         void Deletar (int id);
    }
}