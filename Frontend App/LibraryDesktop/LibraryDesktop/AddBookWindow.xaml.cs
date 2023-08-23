using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace LibraryDesktop
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly BookWindow bookWindow1;
        Book book = new Book();
        string imagePath;
        string imageName;

        public AddBookWindow(BookWindow bookWindow)
        {
            bookWindow1 = bookWindow;
            InitializeComponent();
        }

        private void FileName_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if(openFileDialog.ShowDialog() == true)
            {
                selectedPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                imagePath = openFileDialog.FileName;
                imageName = openFileDialog.SafeFileName;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                book.Title = title.Text;
                book.Description = desc.Text;
                book.Author = author.Text;
                book.Category = category.Text;
                book.Price = float.Parse(price.Text);
                book.Complexity = complex.Text;
                
                var json = JsonConvert.SerializeObject(book);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", State.token);

                var response = await _httpClient.PostAsync("https://localhost:7062/api/Book", data);

                var apiResult = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBoxResult result = MessageBox.Show("Book Added Succesfully", "Success", MessageBoxButton.OK);
                    if(MessageBoxResult.OK == result)
                    {
                        bookWindow1.GetData();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("An error occured. Please review submitted data", "Error");
                }
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex);
                MessageBox.Show("An Error Occurred", "Error");
            }
        }
    }
}
