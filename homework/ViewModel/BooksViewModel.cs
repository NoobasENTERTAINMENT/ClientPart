using ClosedXML.Excel;
using homework.Commands;
using homework.Core;
using homework.Model;
using homework.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace homework.ViewModel
{
    public class BooksViewModel : ViewModelBase
    {
        public BooksViewModel()
        {
            BooksSubmitCommand = new BooksSubmitCommand(this);
        }
        private List<Book> _booksCollection = Database.DB.Books.OrderBy(x => x.Code_book).ToList();
        public List<Book> BooksCollection
        {
            get { return _booksCollection; }
            set
            { 
                _booksCollection = value;
                OnPropertyChanged();
            }
        }

        private string _value = string.Empty;
        public string Value
        {
            get { return _value; }
            set { _value = value;
                OnPropertyChanged();
            }
        }

        public ICommand BooksSubmitCommand { get; }
        public ICommand CellEditEndingCommand => new RelayCommand<Book>(OnCellEditEnding);
        private void OnCellEditEnding(Book e)
        {
            if (e is Book item)
            {
                Book bookModel = Database.DB.Books.FirstOrDefault(x => x.Code_book == e.Code_book);
                if(bookModel != null)
                {
                    bookModel = e;
                    Database.DB.SaveChangesAsync();
                }
                
            }
        }
        public ICommand ExportCommand => new RelayCommand<DataGrid>(ExportToExcel);
        private void ExportToExcel(DataGrid e)
        {
            System.Data.DataTable dataTable = ConvertToDataTable<Book>(BooksCollection);

           SaveExcelData(BooksCollection, "Report");

            
        }
        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public void SaveExcelData(List<Book> Data, string FileName)
        {
            XLWorkbook excelworkBook = new XLWorkbook();
            var worksheet = excelworkBook.Worksheets.Add("Лист1");

            worksheet.Cell("A" + 1).Value = "Код книги";
            worksheet.Cell("B" + 1).Value = "Название";
            worksheet.Cell("C" + 1).Value = "Количество страниц";
            worksheet.Cell("D" + 1).Value = "Автор";
            worksheet.Cell("E" + 1).Value = "Издатель";
            int row = 2;

            foreach (Book data in Data)
            {
                worksheet.Cell("A" + row).Value = data.Code_book;
                worksheet.Cell("B" + row).Value = data.Title_book;
                worksheet.Cell("C" + row).Value = data.Pages;
                worksheet.Cell("D" + row).Value = (data.Author as Author).Name_author;
                worksheet.Cell("E" + row).Value = (data.Publishing_house as Publishing_house).Publish;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            sfd.ShowDialog();
            excelworkBook.SaveAs(sfd.FileName);
        }
    }
}
