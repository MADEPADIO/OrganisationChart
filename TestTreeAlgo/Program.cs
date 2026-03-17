using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTreeAlgo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<Person> company = new Tree<Person>();
            company.Root = new TreeNode<Person>()
            {
                Data = new Person(100, "Vantyse", "CEO"),
                Parent = null
            };

            company.Root.Children = new List<TreeNode<Person>>();
            {
                new TreeNode<Person>() 
                { Data = new Person(50, "Mary", "Head of Research"), Parent = company.Root };

                new TreeNode<Person>()
                { Data = new Person(150, "Lily", "Head of Sales"), Parent = company.Root };

                new TreeNode<Person>() 
                { Data = new Person(1, "PADIO", "Head of Development") };
            };

            company.Root.Children[2].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person> 
                { Data = new Person(30, "Jeff", "Sales Manager"), Parent = company.Root.Children[2]}
            }; 
        }
    }
}
