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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Json;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibraryDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        User LoggedInUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(username.Text))
            {
                MessageBox.Show("Username required", "Error");
                return;
            }
            if (string.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Email required", "Error");
                return;
            }
            if (string.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Password required", "Error");
                return;
            }

            try
            {
                User user = new User();
                user.UserName = username.Text;
                user.Password = password.Password;
                user.Email = email.Text;
                user.Roles.Add("User");

                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7062/api/Account/register", data);

                var apiResult = response.Content.ReadAsStringAsync().Result;

                JObject result = JsonConvert.DeserializeObject<JObject>(apiResult);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registered Successfully", "Success");
                    username.Clear();
                    email.Clear();
                    password.Clear();
                }
                else
                {
                    MessageBox.Show(result.First.First().First.ToString(), "Error");
                }

                Trace.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An Error Occurred", "Error");
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginEmail.Text))
            {
                MessageBox.Show("Email required", "Error");
                return;
            }
            if (string.IsNullOrEmpty(LoginPassword.Password))
            {
                MessageBox.Show("Password required", "Error");
                return;
            }

            try
            {
                LoggedInUser = new User();
                LoggedInUser.Email = LoginEmail.Text;
                LoggedInUser.Password = LoginPassword.Password;

                var json = JsonConvert.SerializeObject(LoggedInUser);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7062/api/Account/login", data);

                var apiResult = response.Content.ReadAsStringAsync().Result;

                JObject result = JsonConvert.DeserializeObject<JObject>(apiResult);

                Trace.WriteLine(result);

                if (response.IsSuccessStatusCode)
                {
                    LoggedInUser = JsonConvert.DeserializeObject<User>(result["user"].ToString());
                    State.user = LoggedInUser;
                    State.token = result["token"].ToString();
                    MessageBoxResult ok = MessageBox.Show("Login Successful", "Success", MessageBoxButton.OK);
                    if (ok == MessageBoxResult.OK)
                    {
                        BookWindow bookWindow = new BookWindow();
                        bookWindow.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(result.First.ToString(), "Error");
                }
                Trace.WriteLine(apiResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("An Error Occurred", "Error");
            }
        }
    }
}
