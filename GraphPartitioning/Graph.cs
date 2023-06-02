using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPartitioning
{
    public class Graph
    {

        public List<string> Vertexs { get; set; }
        public List<Tuple<string>> Edges { get; set; }

        public Graph()
        {
            Vertexs = new List<string>();
            Edges = new List<Tuple<string>>();
        }
    }
}
