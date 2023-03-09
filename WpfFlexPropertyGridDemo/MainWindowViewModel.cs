using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfFlexPropertyGridDemo
{
    public class MainWindowViewModel
    {
        public Data1.SampleObject Data1 { get; set; }

        public MainWindowViewModel()
        {
            Data1 = new Data1.SampleObject();

            Console.WriteLine();


        }
    }
}
