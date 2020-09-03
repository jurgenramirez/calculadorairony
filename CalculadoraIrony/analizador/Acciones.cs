using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
namespace CalculadoraIrony.analizador
{
    class Acciones
    {
        public double realizarAccion(ParseTreeNode raiz)
        {
            return accion(raiz);
        }
        public double accion(ParseTreeNode node)
        {
            double result = 0.0;

            switch (node.Term.Name.ToString())
            {
                case "S":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = accion(node.ChildNodes[0]);
                        }
                        break;
    
                    }
                case "E":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = accion(node.ChildNodes[0]);
                        }
                        else if (node.ChildNodes.Count == 3)
                        {
                            double num1 = Convert.ToDouble(accion(node.ChildNodes[0]).ToString());
                            double num2 = Convert.ToDouble(accion(node.ChildNodes[2]).ToString());
                            if (node.ChildNodes[1].Token.Value.ToString() == "+")
                            {
                                result = num1 + num2;
                            }
                            else
                            {
                                result = num1 - num2;
                            }
                        }
                    }
                    break;
                case "T":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = accion(node.ChildNodes[0]);
                        }
                        else if (node.ChildNodes.Count == 3)
                        {
                            double num1 = Convert.ToDouble(accion(node.ChildNodes[0]).ToString());
                            double num2 = Convert.ToDouble(accion(node.ChildNodes[2]).ToString());
                            if (node.ChildNodes[1].Token.Value.ToString() == "*")
                            {
                                result = num1 * num2;
                            }
                            else
                            {
                                result = num1 / num2;
                            }
                        }
                    }
                    break;

                case "F":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            result = accion(node.ChildNodes[0]);
                        }
                    }
                    break;
                case "numero":
                    {
                        result = Convert.ToDouble(node.Token.Value.ToString());              
                    }
                    break;
            }

            return result;
        }
    }
}
