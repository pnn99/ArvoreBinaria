using System;

namespace ArvoreBinaria
{
    class Tree
    {
        public Node raiz;

        public Tree(int ano, string nome, string banda)
        {
            raiz = new Node(ano, nome, banda);
            raiz.Right = null;
            raiz.Left = null;
        }
        public void Add(int d, string nome, string banda)
        {
            Add(raiz, d, nome, banda);
        }

        public void AddAVL(int valor, string nome, string banda)
        {
            Node newItem = new Node(valor, nome, banda);
            if (raiz == null)
            {
                raiz = newItem;
            }
            else
            {
                raiz = InserirRecursivo(raiz, newItem);
            }
        }
        public void Add(Node raiz, int valor, string nome, string banda)
        {
            if (raiz == null)
            {
                raiz = new Node(valor, nome, banda);
            }
            if (valor > raiz.GetDado())
            {
                if (raiz.Right == null)
                {
                    raiz.Right = new Node(valor, nome, banda);
                }
                else
                {
                    Add(raiz.Right, valor, nome, banda);
                }
            }
            else
            {
                if (raiz.Left == null)
                {
                    raiz.Left = new Node(valor, nome, banda);
                }
                else
                {
                    Add(raiz.Left, valor, nome, banda);
                }
            }
        }

        public void EmOrdem(Node raiz)
        {
            if (raiz != null)
            {
                EmOrdem(raiz.Left);
                Console.WriteLine(raiz.Dado);
                EmOrdem(raiz.Right);
            }
        }

        public void PosOrdem(Node raiz)
        {
            if (raiz != null)
            {
                PosOrdem(raiz.Left);
                PosOrdem(raiz.Right);
                Console.WriteLine(raiz.Dado);
            }
        }
        public void Print()
        {
            Print(raiz, "", raiz.Banda, raiz.Nome);
        }
        public void Print(Node raiz, string prefix, string nome, string banda)
        {
            if (raiz == null)
            {
                Console.WriteLine(prefix + "+- <null>");
                return;
            }
            Console.WriteLine(prefix + "+- " + raiz.Dado);
            Print(raiz.Left, prefix + " | ", nome, banda);
            Print(raiz.Right, prefix + " | ", nome, banda);
        }

        public Node Buscar(int d)
        {
            return Buscar(raiz, d);
        }

        public Node Buscar(Node raiz, int d)
        {
            if (raiz == null) return null;
            if (raiz.Dado == d) return raiz;
            if (d > raiz.Dado)
            {
                return Buscar(raiz.Right, d);
            }
            else
            {
                return Buscar(raiz.Left, d);
            }
        }

        public int AlturaDaArvore()
        {
            return Altura(raiz);
        }

        public int Altura(Node atual)
        {
            int altura = -1;
            if (atual != null)
            {
                int esq = Altura(atual.Left);
                int dir = Altura(atual.Right);
                int m = max(esq, dir);
                altura = m + 1;
            }
            return altura;
        }

        private int max(int esq, int dir)
        {
            return esq > dir ? esq : dir;
        }

        public int FatorBalanceamento(Node atual)
        {
            int l = Altura(atual.Left);
            int r = Altura(atual.Right);
            int b_fator = l - r;
            return b_fator;
        }

        private Node RotacaoDD(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }

        private Node RotacaoEE(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }

        private Node RotacaoED(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotacaoDD(pivot);
            return RotacaoEE(parent);
        }

        private Node RotacaoDE(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotacaoEE(pivot);
            return RotacaoDD(parent);
        }

        private Node BalancearArvore(Node atual)
        {
            int b_fator = FatorBalanceamento(atual);
            if (b_fator > 1)
            {
                if (FatorBalanceamento(atual.Left) > 0)
                {
                    atual = RotacaoEE(atual);
                }
                else
                {
                    atual = RotacaoED(atual);
                }

            }
            else if (b_fator < -1)
            {
                if (FatorBalanceamento(atual.Right) > 0)
                {
                    atual = RotacaoDE(atual);
                }
                else
                {
                    atual = RotacaoDD(atual);
                }

            }
            return atual;
        }

        private Node InserirRecursivo(Node atual, Node n)
        {
            if (atual == null)
            {
                atual = n;
                return atual;
            }
            else if (n.Dado < atual.Dado)
            {
                atual.Left = InserirRecursivo(atual.Left, n);
                atual = BalancearArvore(atual);
            }
            else if (n.Dado > atual.Dado)
            {
                atual.Right = InserirRecursivo(atual.Right, n);
                atual = BalancearArvore(atual);
            }
            return atual;
        }
    }

}