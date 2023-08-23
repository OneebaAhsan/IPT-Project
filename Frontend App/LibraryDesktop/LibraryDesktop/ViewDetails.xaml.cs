using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace LibraryDesktop
{
    /// <summary>
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public int bookId;

        public ViewDetails()
        {
            InitializeComponent();
            Loaded += ViewDetails_Loaded;
        }

        private async void ViewDetails_Loaded(object sender, RoutedEventArgs e)
        {
            Book book;
            var content = await _httpClient.GetStringAsync($"https://localhost:7062/api/Book/{bookId}");
            book = JsonConvert.DeserializeObject<Book>(content);
            
            titleBar.Content = book.Title;
            descBar.Content = book.Description;
            categoryBar.Content = book.Category;
            priceBar.Content = book.Price;
            authorBar.Content = book.Author;
            complexityBar.Content = book.Complexity;
        }
    }
}
