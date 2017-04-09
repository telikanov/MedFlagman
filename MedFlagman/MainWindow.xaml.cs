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

namespace MedFlagman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string rawSymbol = "fsdf!@#$%^&*)*YGHDJ(*&^%#$%^&@@!!";
        string[] rawText = { "Черемуха", "душистая", "С", "весною", "расцвела", "И", "ветки", "золотистые", "Что", "кудри", "завила", "Кругом", "роса", "медвяная", "Сползает", "по", "коре", "Под", "нею", "зелень", "пряная", "Сияет", "в", "серебре", "А", "рядом", "у", "проталинки", "В", "траве", "между", "корней", "Бежит", "струится", "маленький", "Серебряный", "ручей", "Черемуха", "душистая", "Развесившись", "стоит", "А", "зелень", "золотистая", "На", "солнышке", "горит", "Ручей", "волной", "гремучею", "Все", "ветки", "обдает", "И", "вкрадчиво", "под", "кручею", "Ей", "песенки", "поет" };

        private void SymbolButton_Click(object sender, RoutedEventArgs e)
        {
            Report newReport = new Report();
            newReport.Show();
            char[] symbol = rawSymbol.ToCharArray();

            newReport.listBox.Items.Add("Длина массива: " + getRandomArray(symbol).Length);
            String temp = "";
            foreach (string randomSymbol in getRandomArray(symbol))
            {
                temp += randomSymbol + " ";
            }
            newReport.listBox.Items.Add("Элементы массива: " + temp);
            newReport.listBox.Items.Add("Частота вхождения:");

            foreach (var element in getDictionaryFrequenceRepetition(getRandomArray(symbol)))
            {
                newReport.listBox.Items.Add($"{element.Key}" + ": " + $"{element.Value}");
            }
        }

        private void WordButton_Click(object sender, RoutedEventArgs e)
        {
            Report newReport = new Report();
            newReport.Show();
            newReport.listBox.Items.Add("Длина массива: " + getRandomArray(rawText).Length);
            String temp = "";
            foreach (string randomSymbol in getRandomArray(rawText))
            {
                temp += randomSymbol + " ";
            }
            newReport.listBox.Items.Add("Элементы массива: " + temp);
            newReport.listBox.Items.Add("Частота вхождения:");

            foreach (var element in getDictionaryFrequenceRepetition(getRandomArray(rawText)))
            {
                newReport.listBox.Items.Add($"{element.Key}" + ": " + $"{element.Value}");
            }
        }

        public string[] getRandomArray(char[] array)
        {
            Random random = new Random();
            string[] randomArraySymbol = new string[random.Next(20, 40)];

            for (int i = 0; i < randomArraySymbol.Length; i++)
            {
                randomArraySymbol[i] = array[random.Next(0, array.Length - 1)].ToString();
            }
            return randomArraySymbol;
        }

        public string[] getRandomArray(string[] array)
        {
            Random random = new Random();
            string[] randomArrayText = new string[random.Next(20, 40)];

            for (int i = 0; i < randomArrayText.Length; i++)
            {
                randomArrayText[i] = array[random.Next(0, array.Length - 1)];
            }
            return randomArrayText;
        }

        public Dictionary<String, int> getDictionaryFrequenceRepetition(string[] symbolArray)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            dictionary = symbolArray.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }
    }
}
