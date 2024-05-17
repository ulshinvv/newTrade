
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static NewTrade.view.ProductsView;

namespace NewTrade.view
{
    /// <summary>
    /// Логика взаимодействия для ProductsView.xaml
    /// </summary>
    
    public partial class ProductsView : UserControl
    {
        private ObservableCollection<Product> products;
        public ProductsView()
        {
            InitializeComponent();
            // Инициализируем коллекцию товаров
            products = new ObservableCollection<Product>();

            // Заполняем коллекцию товарами
            products.Add(new Product("Товар 1", "Описание товара 1", "Производитель 1", 100.50, 50));
            products.Add(new Product("Товар 2", "Описание товара 2", "Производитель 2", 75.30, 30));
            products.Add(new Product("Товар 3", "Описание товара 3", "Производитель 1", 120.00, 20));

            // Устанавливаем список товаров как источник данных для ListBox
            productListBox.ItemsSource = products;
        }

        private void UpdateProductList(string manufacturer)
        {
            // Создаем отфильтрованную коллекцию товаров
            var filteredProducts = new ObservableCollection<Product>(
                products.Where(p => p.Manufacturer == manufacturer));

            // Устанавливаем отфильтрованную коллекцию в ListBox
            productListBox.ItemsSource = filteredProducts;
        }

        private void ManufacturerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                string selectedManufacturer = (string)comboBox.SelectedItem;
                UpdateProductList(selectedManufacturer);
            }
        }

        private void SortProductsByName()
        {
            // Сортируем товары по имени
            var sortedProducts = new ObservableCollection<Product>(products.OrderBy(p => p.Name));

            // Устанавливаем отсортированную коллекцию в ListBox
            productListBox.ItemsSource = sortedProducts;
        }


        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Manufacturer { get; set; }
            public double Cost { get; set; }
            public int QuantityInStock { get; set; }

            public Product(string name, string description, string manufacturer, double cost, int quantityInStock)
            {
                Name = name;
                Description = description;
                Manufacturer = manufacturer;
                Cost = cost;
                QuantityInStock = quantityInStock;
            }
        }

    }
}
