using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace JsonSerilizationDeserilizationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Text { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private string output;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product
            {
                Name = "Apple",
                ExpiryDate = new DateTime(2008, 12, 28),
                Price = 3.99M,
                Sizes = new string[] { "Small", "Medium", "Large" }
            };

            output = JsonConvert.SerializeObject(product);
            System.Diagnostics.Debug.WriteLine(output);
            textBlock.Text = output;
        }

        private void dButton_Click(object sender, RoutedEventArgs e)
        {
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            System.Diagnostics.Debug.WriteLine(deserializedProduct.ToString());
            textBlock.Text = deserializedProduct.ToString();
        }

        private void cSButton_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<Product>
            {
                new Product{
                    Name = "Apple",
                    ExpiryDate = new DateTime(2008, 12, 28),
                    Price = 3.99M,
                    Sizes = new string[] { "Small", "Medium", "Large" }
                },
                new Product{
                    Name = "Banana",
                    ExpiryDate = new DateTime(2008, 12, 28),
                    Price = 3.99M,
                    Sizes = new string[] { "Small", "Medium", "Large" }
                },
                new Product{
                    Name = "Orange",
                    ExpiryDate = new DateTime(2008, 12, 28),
                    Price = 3.99M,
                    Sizes = new string[] { "Small", "Medium", "Large" }
                },
            };
            

            output = JsonConvert.SerializeObject(list);
            System.Diagnostics.Debug.WriteLine(output);
            textBlock.Text = output;
        }

        private void cDButton_Click(object sender, RoutedEventArgs e)
        {
            var deserializedProduct = JsonConvert.DeserializeObject<List<Product>>(output);
            System.Diagnostics.Debug.WriteLine(deserializedProduct.ToString());
            textBlock.Text = deserializedProduct.ToString();
        }
    }

    public record Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
