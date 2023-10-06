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
using Библиотека.Model;
using Библиотека.ViewModel;
using static System.Reflection.Metadata.BlobBuilder;


namespace Библиотека
{
    public partial class MainWindow : Window
    {
        public List<Book> AllBooks = new List<Book>()
        {
            new Book("Дэниел Киз", "Таинственная история Билли Миллигана", 1, 1981, 1),
            new Book("Михаил Шолохов", "Судьба человека. Рассказы", 2, 1956, 2),
            new Book("Рик Риордан", "Перси Джексон и последнее пророчество", 3, 2009, 5),
            new Book("Эрих Ремарк", "Возлюби ближнего своего", 4, 1941, 6),
            new Book("Артур Хейли", "Аэропорт", 5, 1968, 8),
            new Book("Айн Рэнд", "Источник", 6, 1957, 9),
            new Book("Тихон Архимандрит", "Несвятые святые", 7, 2020, 11),
            new Book("Решад Гюнтекин", "Королек-птичка певчая", 8, 1922, 12),
            new Book("Кир Булычев", "Посёлок", 9, 1984, 14),
            new Book("Федор Достоевский", "Идиот", 10, 1869, 15),
            new Book("Ирвин Шоу", "Богач, бедняк", 11, 1969, 17),
            new Book("Арчибальд Кронин", "Цитадель", 12, 1939, 18),
            new Book("Генрик Сенкевич", "Камо грядеши", 13, 1896, 20),
            new Book("Джон Стейнбек", "К востоку от Эдема",  14, 1952, 21),
            new Book("Стивен Кинг", "Мизери",  15, 1987, 22)
        };

        public List<User> AllUsers = new List<User>()
        {
            new User(0, "Евгений", "Катышков", new List<Book>()
            {
                new Book("Эрих Ремарк", "Возлюби ближнего своего", 4, 1941, 1),
                new Book("Артур Хейли", "Аэропорт", 5, 1968, 1),
                new Book("Айн Рэнд", "Источник", 6, 1957, 1),
                new Book("Тихон Архимандрит", "Несвятые святые", 7, 2020, 1),
                new Book("Решад Гюнтекин", "Королек-птичка певчая", 8, 1922, 1),
            }),
           
            new User(1, "Андрей", "Филатов", new List<Book>()
            {
                new Book("Стивен Кинг", "Мизери",  15, 1987, 1)
            }),
            
            new User(2, "Артемий", "Исаев", new List<Book>()),
            
            new User(3, "Ярослав", "Шилов", new List<Book>()),
            
            new User(4, "Ева", "Фомичева", new List<Book>()
            {
                new Book("Ирвин Шоу", "Богач, бедняк", 11, 1969, 1),
                new Book("Арчибальд Кронин", "Цитадель", 12, 1939, 1),
                new Book("Генрик Сенкевич", "Камо грядеши", 13, 1896, 1),
            }),
            
            new User(5, "Кирилл", "Егоров", new List<Book>()),
            
            new User(6, "Агата", "Беляева", new List<Book>()
            {
                new Book("Решад Гюнтекин", "Королек-птичка певчая", 8, 1922, 1),
                new Book("Кир Булычев", "Посёлок", 9, 1984, 1),
                new Book("Федор Достоевский", "Идиот", 10, 1869, 1),
            }),
            
            new User(7, "Максим", "Николаев", new List<Book>()
            {
                new Book("Кир Булычев", "Посёлок", 9, 1984, 1),
                new Book("Федор Достоевский", "Идиот", 10, 1869, 1),
                new Book("Ирвин Шоу", "Богач, бедняк", 11, 1969, 1),
            }),

            new User(8, "Дарья", "Жарова", new List<Book>()),

            new User(9, "Евгения", "Макарова", new List<Book>()
            {
                new Book("Генрик Сенкевич", "Камо грядеши", 13, 1896, 1),
                new Book("Джон Стейнбек", "К востоку от Эдема",  14, 1952, 1),
                new Book("Стивен Кинг", "Мизери",  15, 1987, 1)
            }),

            new User(10, "Виталий", "Петров", new List<Book>()),
        };

        public List<Book> temp_books = new List<Book>();
        public bool flag = false;

        public MainWindow()
        {
            InitializeComponent();
            BooksListView.ItemsSource = AllBooks;
            UsersListView.ItemsSource = AllUsers;
        }

        private void UsersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User CurUser = UsersListView.SelectedItem as User;
            if (CurUser!=null) { UserBooksListView.ItemsSource = CurUser.BookList; }
        }

        private void GiveBookButton_Click(object sender, RoutedEventArgs e)
        {
            User CurUser = UsersListView.SelectedItem as User;
            Book CurBook = BooksListView.SelectedItem as Book;
            if ((CurUser != null))
            {
                if (CurBook != null) 
                {
                    if (CurBook.Count > 0)
                    {
                        CurUser.BookList.Add(CurBook);
                        CurBook.Count -= 1;
                        UserBooksListView.Items.Refresh();
                        BooksListView.Items.Refresh();
                    }
                    else
                    {
                        ErrorBox.BookCountError();
                    }
                }
                else
                {
                    ErrorBox.BookSelectError();
                }
            }
            else
            {
                ErrorBox.UserSelectError();
            }
        }

        private void TakeBookButton_Click(object sender, RoutedEventArgs e)
        {
            User CurUser = UsersListView.SelectedItem as User;
            Book CurBook = UserBooksListView.SelectedItem as Book;
            if (CurUser != null)
            {
                if (CurBook != null) 
                {
                    if (flag == false)
                    {
                        for (int i = 0; i < AllBooks.Count; i++)
                        {
                            if (CurBook.Arc == AllBooks[i].Arc) { AllBooks[i].Count += 1; }
                        }
                        CurUser.BookList.Remove(CurBook);
                    }
                    else
                    {
                        for (int i = 0; i < AllBooks.Count; i++)
                        {
                            if (CurBook.Arc == AllBooks[i].Arc) { AllBooks[i].Count += 1; }
                        }
                        for (int i = 0; i < CurUser.BookList.Count; i++)
                        {
                            if (CurBook.Arc == CurUser.BookList[i].Arc)
                            {
                                CurUser.BookList.Remove(CurUser.BookList[i]);
                                break;
                            }
                        }
                    }
                    UserBooksSearchTextBox.Text = "";
                    UserBooksListView.ItemsSource = CurUser.BookList;
                    UserBooksListView.Items.Refresh();
                    BooksListView.Items.Refresh(); 
                }
                else
                {
                    ErrorBox.UserBookSelectError();
                }
            }
            else
            {
                ErrorBox.UserSelectError();
            }
        }

        private void UsersSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<User> SearchUsers = new List<User>();
            for (int i = 0; i < AllUsers.Count; i++)
            {

                if ((Convert.ToString(AllUsers[i].Id).ToLower() + AllUsers[i].Name.ToLower() + AllUsers[i].Surname.ToLower()).Contains(Convert.ToString(UsersSearchTextBox.Text).ToLower()))
                {
                    SearchUsers.Add(AllUsers[i]);
                }
            }
            UsersListView.ItemsSource = SearchUsers;
            UserBooksListView.ItemsSource = "";
            UserBooksListView.Items.Refresh();
            UsersListView.Items.Refresh();
        }

        private void BooksSearchTextBoxes_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Book> SearchBooks = new List<Book>();
            for (int i = 0; i < AllBooks.Count; i++)
            {

                if ((Convert.ToString(AllBooks[i].Arc).ToLower() + AllBooks[i].Author.ToLower() + AllBooks[i].Name.ToLower() + Convert.ToString(AllBooks[i].Age).ToLower()).Contains(Convert.ToString(BooksSearchTextBox1.Text).ToLower()) && (Convert.ToString(AllBooks[i].Count).ToLower().Contains(BooksSearchTextBox2.Text)))
                {
                    SearchBooks.Add(AllBooks[i]);
                }
            }
            BooksListView.ItemsSource = SearchBooks;
            BooksListView.Items.Refresh();
        }

        private void UserBooksSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Book> SearchBooks = new List<Book>();
            User CurUser = UsersListView.SelectedItem as User;
            if (CurUser!=null)
            {
                for (int i = 0; i < CurUser.BookList.Count; i++)
                {
                    if ((Convert.ToString(CurUser.BookList[i].Arc).ToLower() + CurUser.BookList[i].Author.ToLower() + CurUser.BookList[i].Name.ToLower() + Convert.ToString(CurUser.BookList[i].Age).ToLower()).Contains(Convert.ToString(UserBooksSearchTextBox.Text).ToLower()))
                    {
                        SearchBooks.Add(CurUser.BookList[i]);
                    }
                }
                flag = true;
            }
            temp_books = SearchBooks;
            UserBooksListView.ItemsSource = SearchBooks;
            UserBooksListView.Items.Refresh();
        }
    }

}
