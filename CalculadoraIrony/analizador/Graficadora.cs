using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace CalculadoraIrony.analizador
{

    class Graficadora
    {
        private String desktop;
        private StringBuilder graphivz;
        private int contador;
        public Graficadora()
        {
            desktop = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.generarRutas();
        }
        private void generarRutas()
        {
            String desktop = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            List<String> rutas = new List<String>();
            rutas.Add(desktop + "\\Files");
            rutas.Add(desktop + "\\Files\\Arbol");
            foreach (String item in rutas)
            {
                if (!System.IO.Directory.Exists(item))
                {
                    System.IO.DirectoryInfo dir = System.IO.Directory.CreateDirectory(item);
                }
            }
        }
        private void generarDOT_PNG(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, graphivz.ToString());
            String comandodot = "dot -Tpng " + rdot + " -o " + rpng + " ";
            Console.WriteLine("dot command " + comandodot);
            
            var command = string.Format(comandodot);
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + command);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
        }
        public void graficar(ParseTree arbol)
        {
            graphivz = new StringBuilder();
            contador = 0;
            String rdot = desktop + "\\Files\\Arbol\\arbolsuma.dot";
            String rpng = desktop + "\\Files\\Arbol\\arbolsuma.png";
            graphivz.Append("digraph G {\r\n node[shape=doublecircle, style=filled, color=khaki1, fontcolor=black]; \r\n");
            Arbol_listar_enlazar(arbol.Root, contador);
            graphivz.Append("}");
            this.generarDOT_PNG(rdot, rpng);
        }
        private void Arbol_listar_enlazar(ParseTreeNode nodo, int num)
        {
            if (nodo != null)
            {
                graphivz.Append("node" + num + " [ label = \"" + nodo.Term.ToString() + "\"];\r\n");
                int tam = nodo.ChildNodes.Count;
                int actual;
                for (int i = 0; i < tam; i++)
                {
                    contador = contador + 1;
                    actual = contador;
                    Arbol_listar_enlazar(nodo.ChildNodes[i], contador);
                    graphivz.Append("\"node" + num + "\"->\"node" + actual + "\";\r\n");
                }
            }
        }




    }
}
