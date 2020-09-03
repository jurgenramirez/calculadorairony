using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;


namespace CalculadoraIrony.analizador
{
    class Gramatica : Grammar //heredear de la clase grammar
    {
        public Gramatica() : base(caseSensitive: false)// inidcamos si nuestro lenguaje es  case sentive
        {
            #region expresionesER
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");

            #endregion

            #region TERMINALES
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            #endregion
            #region NOTERMINAL
            NonTerminal S = new NonTerminal("S"),
            E = new NonTerminal("E"),
            F = new NonTerminal("F"),
            T = new NonTerminal("T");
            #endregion
            #region GRAMATICA
            S.Rule = E;
            E.Rule = E + mas + T
                    | E + menos + T
                    | T;
            T.Rule = T + por + F
                    | T + div + F
                    | F;
            F.Rule = numero;

            this.Root = S;
                
            #endregion
        }
    }
}
