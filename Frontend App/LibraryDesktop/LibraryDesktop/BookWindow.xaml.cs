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
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public User user;
        public string token;
        List<Book> books;

        public BookWindow()
        {
            InitializeComponent();
            Loaded += BookWindow_Loaded;
        }

        private async void BookWindow_Loaded(object sender, RoutedEventArgs e)
        {
            user = State.user;
            token = State.token;
            UserNameLabel.Content = user.UserName;
            await GetData();
        }

        public async Task GetData()
        {
            var content = await _httpClient.GetStringAsync("https://localhost:7062/api/Book");
            books = JsonConvert.DeserializeObject<List<Book>>(content);
            bookList.ItemsSource = books;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow(this);
            addBookWindow.Title = "Add A New Book";
            addBookWindow.Show();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var bookId = button.Tag.ToString();

            ViewDetails viewDetails = new ViewDetails();
            viewDetails.bookId = Int32.Parse(bookId);
            viewDetails.Show();
        }
    }
}
