using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ImageToExcelWorksheet.Entities;
using ImageToExcelWorksheet.Utils;
using ImageToExcelWorksheet.View;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ImageToExcelWorksheet.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Parameters and Commands

        private Application _application => Globals.ThisAddIn.Application;
        private Worksheet _worksheet;

        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        private ICommand _canExecuteCommand;

        public ICommand CanExecuteCommand => _canExecuteCommand ?? (_canExecuteCommand = new RelayCommand(ConvertImage, () => CanExecute));

        private ICommand _openSearchFile;

        public ICommand OpenSearchFile => _openSearchFile ?? (_openSearchFile = new RelayCommand(SearchPath, () => true));

        #endregion

        #region Methods

        public event EventHandler OnRequestClose;

        public static System.Action CloseAction { get; set; }

        #region Validation
        public bool CanExecute => Uri.TryCreate(_path, UriKind.Absolute, out Uri result);

        public void SearchPath()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Path = openFileDialog.FileName;
            }
        }
        #endregion

        private void ConvertImage()
        {
            _worksheet = (Worksheet)_application.ActiveWorkbook.ActiveSheet;
            var pixelMatrix = ImageHandler.ConvertImageToMatrixColor(Path);

            Parallel.For(0, pixelMatrix.GetLength(0), x =>
            {
                Parallel.For(0, pixelMatrix.GetLength(1), y =>
                {
                    Range range = (Range)_worksheet.Cells[x + 1, y + 1];
                    range.Interior.Color = ColorTranslator.ToOle(pixelMatrix[x, y]);
                });
            });

            CloseAction();

            //OnRequestClose(this, new EventArgs());
        }
        #endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
