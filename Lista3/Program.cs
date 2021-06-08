using System;
using System.Collections.Generic;

namespace Lista3
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto1 = "...Uma atividade livre, conscientemente tomada como “não-séria” e exterior à vida habitual, mas ao mesmo tempo capaz de absorver o jogador de maneira intensa e total. É uma atividade desligada de todo e qualquer interesse material, com a qual não se pode obter qualquer lucro, praticada dentro de limites espaciais e temporais próprios, segundo uma certa ordem e certas regras. Promove a formação de grupos sociais com tendência a rodearem-se de segredo e a sublinharem sua diferença em relação ao resto do mundo por meio de disfarces ou outros meios semelhantes.";
            //Questão 1
            Console.WriteLine("Questão 1");
            Console.WriteLine(" ");
            Console.WriteLine($"O texto possui {QtdPalavrasDiferentesTexto(texto1)} palavras diferentes.");
            Console.WriteLine("                                     ");

            //Questão 2
            Console.WriteLine("Questão 2");
            Console.WriteLine(" ");
            Dictionary<string, int> resultado = VerificarQtdAparicaoPalavras(texto1);
            foreach (var item in resultado)
            {
                Console.WriteLine($"A palavra {item.Key} se repete {item.Value} vezes");
            }
            Console.WriteLine("                                     ");
            //Questão 3
            Console.WriteLine("Questão 3");
            Console.WriteLine(" ");
            string texto2 = "1 + (5 + 3 - (8 - 5) * 4 - ((3 + 7) * (3 - 1)))";
            VerificarExpressaoNumerica(texto2);

            Console.ReadLine();
        }

        static int QtdPalavrasDiferentesTexto(string texto)
        {
            HashSet<string> palavrasTexto = new HashSet<string>();
            string[] palavras = texto.Split(' ', ',', ';', '.');


            foreach (var item in palavras)
            {
                if (item.Length != 0)
                {
                    palavrasTexto.Add(item);
                }
            }

            return palavrasTexto.Count;
        }

        static Dictionary<string, int> VerificarQtdAparicaoPalavras(string texto)
        {
            Dictionary<string, int> palavrasColetadas = new Dictionary<string, int>();
            string[] palavras = texto.Split(' ', ',', ';', '.');

            foreach (var item in palavras)
            {
                if (item.Length != 0)
                {
                    int contador;
                    if (!palavrasColetadas.TryGetValue(item.ToLower(), out contador))
                    {
                        contador = 0;
                    }
                    palavrasColetadas[item.ToLower()] = contador + 1;
                }
            }

            return palavrasColetadas;
        }

        static void VerificarExpressaoNumerica(string texto)
        {
            Stack<string> aux = new Stack<string>();
            foreach (var item in texto){
                if (item == '(' )
                {
                    aux.Push("(");
                }else if(item == ')'){
                    if(aux.Count > 0)
                    {
                        aux.Pop();
                    }
                    else
                    {
                        aux.Push(")");
                    }
                }
            }

            if(aux.Count == 0)
            {
                Console.WriteLine("A expressão está válida");
            }
            else
                Console.WriteLine("A expressão não está válida");
        }
    }
}
