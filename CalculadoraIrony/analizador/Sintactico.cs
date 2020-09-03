using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;
namespace CalculadoraIrony.analizador
{
    class Sintactico:Grammar
    {
       public ParseTreeNode analizar(String entrada)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData language = new LanguageData(gramatica);
            Parser parser = new Parser(language);
            ParseTree arbol = parser.Parse(entrada);
           
            ParseTreeNode raiz = arbol.Root;

            if (raiz == null)
            {
                return null;
            }
            else
            {
                Graficadora graficar = new Graficadora();
                graficar.graficar(arbol);
                return raiz;
            }
        }

    }
}
