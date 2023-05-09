using System.Collections;
using System.Collections.Generic;

namespace Lab2.TehnologiiWeb
{
    public class Biblioteca : IEnumerable<Carte>
    {
        private List<Carte> carti;
        private int enumerareMetoda = 0; // Proprietate/Variabilă pentru a controla metoda de enumerare

        public Biblioteca()
        {
            carti = new List<Carte>();
        }

        public void AdaugaCarte(Carte carte)
        {
            carti.Add(carte);
        }

        public void StergeCarte(Carte carte)
        {
            carti.Remove(carte);
        }

        // Metoda 1: Enumerare normală
        private IEnumerator<Carte> EnumerareNormala()
        {
            foreach (Carte carte in carti)
            {
                yield return carte;
            }
        }

        // Metoda 2: Enumerare inversă
        private IEnumerator<Carte> EnumerareInversa()
        {
            for (int i = carti.Count - 1; i >= 0; i--)
            {
                yield return carti[i];
            }
        }

        // Metoda 3: Enumerare a cărților pare
        private IEnumerator<Carte> EnumerarePare()
        {
            for (int i = 0; i < carti.Count; i += 2)
            {
                yield return carti[i];
            }
        }

        // Metoda 4: Enumerare a cărților impare
        private IEnumerator<Carte> EnumerareImpare()
        {
            for (int i = 1; i < carti.Count; i += 2)
            {
                yield return carti[i];
            }
        }

        // Implementarea interfeței IEnumerable<Carte>
        public IEnumerator<Carte> GetEnumerator()
        {
            switch (enumerareMetoda)
            {
                case 0:
                    return EnumerareNormala();
                case 1:
                    return EnumerareInversa();
                case 2:
                    return EnumerarePare();
                case 3:
                    return EnumerareImpare();
                default:
                    return EnumerareNormala();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Metodă pentru a seta metoda de enumerare
        public void SeteazaEnumerareMetoda(int metoda)
        {
            enumerareMetoda = metoda;
        }
    }


}
