using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TesteBenner
{
    public class ElementHandler
    {
        private Dictionary<int, List<int>> Elements = new Dictionary<int, List<int>>();
        public ElementHandler(int range)
        {
            if (range < 2)
            {
                throw new Exception($"The count of elements set should be 2 or higher.");
            }

            for (int i = 1; i <= range; i++)
            {
                Elements[i] = new List<int>();
            }
        }

        public void Connect(int element1, int element2)
        {
            ValidateElements(element1, element2);

            if (Elements[element1].Contains(element2) || Elements[element2].Contains(element1)) 
                throw new Exception($"The elements {element1} and {element2} are already connected.");

            Elements[element1].Add(element2);
            Elements[element2].Add(element1);
        }

        public void Disconnect(int element1, int element2)
        {
            ValidateElements(element1, element2);
            Elements[element1].Remove(element2);
            Elements[element2].Remove(element1);
        }

        public bool Query(int element1, int element2)
        {
            ValidateElements(element1, element2);

            if (Elements[element1].Contains(element2)) return true;

            if (BreadthFirstSearch(element1, element2) > 0) return true;

            return false;
        }

        public int LevelConnection(int element1, int element2) {
            ValidateElements(element1, element2);
            return BreadthFirstSearch (element1, element2);
        }

        private int BreadthFirstSearch(int element1, int element2)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            List<int> visited = new List<int>();
            queue.Enqueue((element1, 0));
            visited.Add(element1);

            while (queue.Count > 0)
            {
                var (current, level) = queue.Dequeue();

                foreach (var neighbor in Elements[current])
                {
                    if (neighbor == element2) return level + 1;
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue((neighbor, level + 1));
                        visited.Add(neighbor);
                    }
                }
            }
            return 0; 
        }

        private void ValidateElements(int element1, int element2)
        {
            if (!Elements.ContainsKey(element1))
                throw new Exception($"The element {element1} is not valid in the set.");

            if (!Elements.ContainsKey(element2))
                throw new Exception($"The element {element2} is not valid in the set.");
        }
    }
}
