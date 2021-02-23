namespace ArvoreBinaria
{
    public class Node 
    {
        public struct Record
        {
            string nome;
            string banda;
            int ano;
        }

        public int Dado {get; }
        public string Banda {get; }
        public string Nome {get; }
        public Node Left;
        public Node Right;

        public Node(int ano, string nome, string banda)
        {
            Banda = banda;
            Nome = nome;
            Dado = ano;
        }

        public int GetDado()
        {
            return Dado;
        }
    }

}