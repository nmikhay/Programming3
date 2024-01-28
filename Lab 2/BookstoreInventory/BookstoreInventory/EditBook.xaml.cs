using System;
using System.Windows;
using System.Windows.Controls;

namespace BookstoreInventory
{

    public partial class EditBook : Window
    {
        private readonly Book book;

        public EditBook(Book book)
        {
            InitializeComponent();
            this.book = book;
            InitializeComponents();
            LoadBookData();
        }

        private void InitializeComponents()
        {
            Label titleLabel = new Label
            {
                Content = "Edit Book",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            TextBox titleTextBox = new TextBox
            {
                Text = book.Title,
                Width = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            TextBox authorTextBox = new TextBox
            {
                Text = book.Author,
                Width = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            TextBox publicationYearTextBox = new TextBox
            {
                Text = book.PublicationYear.ToString(),
                Width = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            TextBox genreTextBox = new TextBox
            {
                Text = book.Genre,
                Width = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            TextBox quantityInStockTextBox = new TextBox
            {
                Text = book.QuantityInStock.ToString(),
                Width = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            Button saveButton = new Button
            {
                Content = "Save",
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };
            saveButton.Click += SaveButton_Click;

            Grid grid = new Grid();
            grid.Children.Add(titleLabel);
            grid.Children.Add(titleTextBox);
            grid.Children.Add(authorTextBox);
            grid.Children.Add(publicationYearTextBox);
            grid.Children.Add(genreTextBox);
            grid.Children.Add(quantityInStockTextBox);
            grid.Children.Add(saveButton);

            Content = grid;
        }

        private void LoadBookData()
        {
            // Load book data into the textboxes
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the updated book details
            // Update the book object with the new values from the textboxes

            // Close the window
            Close();
        }
    }
}


