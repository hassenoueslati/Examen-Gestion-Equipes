using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServiceEquipe : Service<Equipe> , IServiceEquipe
    {
        public ServiceEquipe(IUnitOfWork uow) : base(uow)
        {

        }
        public DateTime DatePremierChampionat(Equipe e)
        {
            return e.Trophees.Where(t => t.TypeTrophee == TypeTrophee.Championnat)
                .OrderBy(t => t.DateTrophee).First().DateTrophee;
        }

        public List<Entraineur> ListeEntraineurParEquipe(Equipe e)
        {

            return e.Contrats.Select(c => c.Membre).OfType<Entraineur>().ToList();
        }

        public List<Joueur> ListeJoueurTrophee(Trophee t)
        {
            return t.Equipe.Contrats
                .Where(c => (t.DateTrophee - c.DateContrat).
            TotalDays < c.DureeMois * 30).Select(c => c.Membre).OfType<Joueur>().ToList();
        }

        public double SommeRecompense(Equipe e)
        {
            double somme = 0;
            foreach (var t in e.Trophees)
            {
                somme = somme + t.Recompense;
            }
            return somme;
        }
    }
}
