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

namespace prakt_8._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            amountChildren.IsEnabled = false;
        }
        FatherWorker _fatherWorker1;
        FatherWorker _fatherWorker2;
        Workman _workmanFirst;
        Workman _workmanSecond;
        private void ChildrenChecked(object sender, RoutedEventArgs e)
        {
            if (childrenSelected.IsChecked == true)
            {
                amountChildren.IsEnabled = true;
            }
            else amountChildren.IsEnabled = false;
            amountChildren.Clear();
        }

        private void AddInfo(object sender, RoutedEventArgs e)
        {
            if (name.Text != string.Empty && surname.Text != string.Empty && patronymic.Text != string.Empty && position.Text != string.Empty  && int.TryParse(outAge.Text, out int age) == true && age > 0)
            {
                if (childrenSelected.IsChecked == false)
                {
                    if (firstCheck.IsChecked == true)
                    {
                        _workmanFirst = new Workman(name.Text, surname.Text, patronymic.Text, age, position.Text);
                        firstWorker.Text = _workmanFirst.EmployeeInformation();
                        _fatherWorker1 = null;
                    }
                    if (secondCheck.IsChecked == true)
                    {
                        _workmanSecond = new Workman(name.Text, surname.Text, patronymic.Text, age, position.Text);
                        secondWorker.Text = _workmanSecond.EmployeeInformation();
                        _fatherWorker2 = null;
                    }
                }
                else
                {
                    if (childrenSelected.IsChecked == true && int.TryParse(amountChildren.Text, out int children) == true && children > 0)
                    {
                        if (firstCheck.IsChecked == true)
                        {
                            _fatherWorker1 = new FatherWorker(name.Text, surname.Text, patronymic.Text, children, age, position.Text);
                            firstWorker.Text = _fatherWorker1.EmployeeInformation();
                            _workmanFirst = null;
                        }
                        if (secondCheck.IsChecked == true)
                        {
                            _fatherWorker2 = new FatherWorker(name.Text, surname.Text, patronymic.Text, children, age, position.Text);
                            secondWorker.Text = _fatherWorker2.EmployeeInformation();
                            _workmanSecond = null;
                        }
                    }
                    else MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CompareWorker(object sender, RoutedEventArgs e)
        {
            if (_workmanFirst != null && _workmanSecond != null)
            {
                if (_workmanFirst.CompareTo(_workmanSecond) == 1) { MessageBox.Show("Количество букв в фамилии первого работника больше, чем у второго", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_workmanFirst.CompareTo(_workmanSecond) == -1) { MessageBox.Show("Количество букв в фамилии второго работника больше, чем у первого", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_workmanFirst.CompareTo(_workmanSecond) == 0) { MessageBox.Show("Количество букв в фамилиях работников одинаковое", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            if (_workmanFirst != null && _fatherWorker2 != null)
            {
                if (_workmanFirst.CompareTo(_fatherWorker2) == 1) { MessageBox.Show("Количество букв в фамилии первого работника больше, чем у второго", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_workmanFirst.CompareTo(_fatherWorker2) == -1) { MessageBox.Show("Количество букв в фамилии второго работника больше, чем у первого", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_workmanFirst.CompareTo(_fatherWorker2) == 0) { MessageBox.Show("Количество букв в фамилиях работников одинаковое", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            if (_fatherWorker1 != null && _fatherWorker2 != null)
            {
                if (_fatherWorker1.CompareTo(_fatherWorker2) == 1) { MessageBox.Show("Количество букв в фамилии первого работника больше, чем у второго", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_fatherWorker1.CompareTo(_fatherWorker2) == -1) { MessageBox.Show("Количество букв в фамилии второго работника больше, чем у первого", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_fatherWorker1.CompareTo(_fatherWorker2) == 0) { MessageBox.Show("Количество букв в фамилиях работников одинаковое", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            if (_fatherWorker1 != null && _workmanSecond != null)
            {
                if (_fatherWorker1.CompareTo(_workmanSecond) == 1) { MessageBox.Show("Количество букв в фамилии первого работника больше, чем у второго", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_fatherWorker1.CompareTo(_workmanSecond) == -1) { MessageBox.Show("Количество букв в фамилии второго работника больше, чем у первого", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
                if (_fatherWorker1.CompareTo(_workmanSecond) == 0) { MessageBox.Show("Количество букв в фамилиях работников одинаковое", "Результат сравнения", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
        }

        private void CloneWorker(object sender, RoutedEventArgs e)
        {
            if (_workmanFirst != null && firstCheck.IsChecked == true)
            {
                _workmanSecond = (Workman)_workmanFirst.Clone();
                secondWorker.Text = _workmanSecond.EmployeeInformation();
                _fatherWorker2 = null;
            }
            if (_workmanSecond != null && secondCheck.IsChecked == true)
            {
                _workmanFirst = (Workman)_workmanSecond.Clone();
                firstWorker.Text = _workmanFirst.EmployeeInformation();
                _fatherWorker1 = null;
            }
            if (_fatherWorker1 != null && firstCheck.IsChecked == true)
            {
                _fatherWorker2 = (FatherWorker)_fatherWorker1.Clone();
                secondWorker.Text = _fatherWorker2.EmployeeInformation();
                _workmanSecond = null;
            }
            if (_fatherWorker2 != null && secondCheck.IsChecked == true)
            {
                _fatherWorker1 = (FatherWorker)_fatherWorker2.Clone();
                firstWorker.Text = _fatherWorker1.EmployeeInformation();
                _workmanFirst = null;
            }
            if (_workmanFirst == null && _workmanSecond == null && _fatherWorker1 == null && _fatherWorker2 == null)
            {
                MessageBox.Show("Информация ни об одном из работников не заполнена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            name.Clear();
            surname.Clear();
            patronymic.Clear();
            position.Clear();
            amountChildren.Clear();
            outAge.Clear();
            firstWorker.Clear();
            secondWorker.Clear();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №8\nСоздать интерфейс - человек. Создать классы - работник и работник-отец семейства. Классы должны включать конструкторы, функцию для формирования строки информации о работнике. Сравнение производить по фамилии.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClearLines(object sender, RoutedEventArgs e)
        {
            name.Clear();
            surname.Clear();
            patronymic.Clear();
            position.Clear();
            amountChildren.Clear();
            outAge.Clear();
        }
    }
}
