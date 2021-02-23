using System;

namespace ArvoreBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree(10, "Musica: ", "Banda: ");

            tree.AddAVL(1999, "PainKiller", "Judas Priest");
            tree.AddAVL(2020, "Guardians of Earth", "Sepultura");
            tree.AddAVL(1972, "Tudo o que Você Podia Ser", "Clube da Esquina");
            
            tree.Print();

            tree.AlturaDaArvore();
            tree.AddAVL(1989, "Retrocesso", "Ratos de Porão");
            tree.AddAVL(1993, "Territory", "Sepultura");
            tree.AddAVL(1981, "SpellBound", "Siouxsie and The Banshees");
            tree.AlturaDaArvore();

            tree.Buscar(1989);
            tree.Print();


        }
    }
}
