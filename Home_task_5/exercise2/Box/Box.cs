using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    internal class Box
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public List<Box> SubBoxes { get; set; }

        public Box(string name, double width, double height, double depth)
        {
            Name = name;
            Width = width;
            Height = height;
            Depth = depth;
            SubBoxes = new List<Box>();
        }

        public void AddSubBox(Box subBox)
        {
            SubBoxes.Add(subBox);
        }

        public void Print(int level = 0)
        {
            Console.WriteLine("{0}{1} ({2} x {3} x {4})", new string('\t', level), Name, Width, Height, Depth);
            foreach (var subBox in SubBoxes)
            {
                subBox.Print(level + 1);
            }
        }

        public void ConsoleReading()
        {
            Console.WriteLine("Please create the store structure by entering the department names separated by slashes (/), one per line.");
            Console.WriteLine("Enter an empty line to finish.");
            while (true)
            {
                var departmentPath = Console.ReadLine().Trim();
                if (departmentPath == "")
                {
                    break;
                }
                var departmentNames = departmentPath.Split('/');
                var currentBox = this;
                foreach (var departmentName in departmentNames)
                {
                    var subBox = currentBox.SubBoxes.Find(box => box.Name == departmentName);
                    if (subBox == null)
                    {
                        subBox = new Box(departmentName, 0, 0, 0);
                        currentBox.AddSubBox(subBox);
                    }
                    currentBox = subBox;
                }
            }
        }

        public void BoxPacking(List<Product> products)
        {
            foreach (var product in products)
            {
                var departmentNames = product.DepartmentPath.Split('/');
                var currentBox = this;
                foreach (var departmentName in departmentNames)
                {
                    var subBox = currentBox.SubBoxes.Find(box => box.Name == departmentName);
                    if (subBox == null)
                    {
                        subBox = new Box(departmentName, 0, 0, 0);
                        currentBox.AddSubBox(subBox);
                    }
                    currentBox = subBox;
                }
                var productBox = new Box(product.Name, product.Width, product.Height, product.Depth);
                currentBox.AddSubBox(productBox);
            }
        }
    }
}
