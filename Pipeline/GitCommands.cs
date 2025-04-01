using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    public class GitCommands
    {
        public void Pull()
        {
            Console.WriteLine("Pulling from Git");
        }

        public void Push()
        {
            Console.WriteLine("Pushing to Git");
        }

        public void Commit()
        {
            Console.WriteLine("Committing to Git");
        }

        public void Merge()
        {
            Console.WriteLine("Merging to Git");
        }


    }
}
