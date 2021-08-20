using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using ProjectManager.Models;

namespace ProjectManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new List<MyTask>() {new MyTask() {Description = "qwerty"}};
            Str = "s";
            DataContext = this;
        }

        public string Str { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
}
