using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace BookstoreInventory
{

    public partial class DeleteBook : Window
    {
        private Book bookToDelete;
        private List<Book> books;

        public DeleteBook(Book bookToDelete, List<Book> books)
        {
            InitializeComponent();
            this.bookToDelete = bookToDelete;
            this.books = books;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Label titleLabel = new Label
            {
                Content = "Delete Book",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            Button deleteButton = new Button
            {
                Content = "Delete",
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };
            deleteButton.Click += DeleteButton_Click;

            Button cancelButton = new Button
            {
                Content = "Cancel",
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };
            cancelButton.Click += CancelButton_Click;

            Grid grid = new Grid();
            grid.Children.Add(titleLabel);
            grid.Children.Add(deleteButton);
            grid.Children.Add(cancelButton);

            Content = grid;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (bookToDelete != null)
            {
                if (books.Contains(bookToDelete))
                {
                    books.Remove(bookToDelete);
                    MessageBox.Show("Book deleted successfully.", "Delete Book", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Book not found in the inventory.", "Delete Book", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("No book selected.", "Delete Book", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}



