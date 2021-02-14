using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageToExcelWorksheet.View;
using ImageToExcelWorksheet.ViewModel;

namespace ImageToExcelWorksheet
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnOpenMainWindow_Click(object sender, RibbonControlEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            var vm = new MainWindowViewModel();
            var mainWindow = new MainWindow()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, x) => mainWindow.Close();

            mainWindow.ShowDialog();
        }
    }
}
