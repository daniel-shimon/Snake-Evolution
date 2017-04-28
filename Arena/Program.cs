using Evolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SemenGame game = new SemenGame())
            {
                game.Run();
            }
        }
    }
}
