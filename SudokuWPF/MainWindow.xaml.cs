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
using System.Threading;

namespace SudokuWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> ItemList = new List<Button>(); //List of all Items in the sudoku
        List<Button> ItemEmptyList = new List<Button>(); //List of all empty Items in the sudoku
        List<string> ItemAvaibleList = new List<string>(); //List of ItemEmtpyList's Items avaible chars
        Brush ColorDefault = Brushes.Black;
        Brush ColorUser = Brushes.Blue;
        List<char> Chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        List<int> HorizontalA = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        List<int> HorizontalB = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        List<int> HorizontalC = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        List<int> HorizontalD = new List<int> { 27, 28, 29, 30, 31, 32, 33, 34, 35 };
        List<int> HorizontalE = new List<int> { 36, 37, 38, 39, 40, 41, 42, 43, 44 };
        List<int> HorizontalF = new List<int> { 45, 46, 47, 48, 49, 50, 51, 52, 53 };
        List<int> HorizontalG = new List<int> { 54, 55, 56, 57, 58, 59, 60, 61, 62 };
        List<int> HorizontalH = new List<int> { 63, 64, 65, 66, 67, 68, 69, 70, 71 };
        List<int> HorizontalI = new List<int> { 72, 73, 74, 75, 76, 77, 78, 79, 80 };
        List<int> VerticalA = new List<int> { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
        List<int> VerticalB = new List<int> { 1, 10, 19, 28, 37, 46, 55, 64, 73 };
        List<int> VerticalC = new List<int> { 2, 11, 20, 29, 38, 47, 56, 65, 74 };
        List<int> VerticalD = new List<int> { 3, 12, 21, 30, 39, 48, 57, 66, 75 };
        List<int> VerticalE = new List<int> { 4, 13, 22, 31, 40, 49, 58, 67 ,76 };
        List<int> VerticalF = new List<int> { 5, 14, 23, 32, 41, 50, 59, 68, 77 };
        List<int> VerticalG = new List<int> { 6, 15, 24, 33, 42, 51, 60, 69, 78 };
        List<int> VerticalH = new List<int> { 7, 16, 25, 34, 43, 52, 61, 70, 79 };
        List<int> VerticalI = new List<int> { 8, 17, 26, 35, 44, 53, 62, 71, 80 };
        List<int> BoxA = new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 };
        List<int> BoxB = new List<int> { 3, 4, 5, 12, 13, 14, 21, 22, 23 };
        List<int> BoxC = new List<int> { 6, 7, 8, 15, 16, 17, 24, 25, 26 };
        List<int> BoxD = new List<int> { 27, 28, 29, 36, 37, 38, 45, 46, 47 };
        List<int> BoxE = new List<int> { 30, 31, 32, 39, 40, 41, 48, 49, 50 };
        List<int> BoxF = new List<int> { 33, 34, 35, 42, 43, 44, 51, 52, 53 };
        List<int> BoxG = new List<int> { 54, 55, 56, 63, 64, 65, 72, 73, 74 };
        List<int> BoxH = new List<int> { 57, 58, 59, 66, 67, 68, 75, 76, 77 };
        List<int> BoxI = new List<int> { 60, 61, 62, 69, 70, 71, 78, 79, 80 };

        public MainWindow()
        {
            InitializeComponent();
            Load_ItemList();
            foreach(Button button in ItemList)
            {
                Refresh(button, "", false);
            }
        }

        public void Refresh(Button Item, string value, bool color)
        {
            Item.Content = value;
            if (color) { Item.Foreground = ColorUser; } else { Item.Foreground = ColorDefault; }
            //Console.WriteLine(Item);
        }

        void Load_ItemList()
        {
            ItemList.Add(ItemAA);
            ItemList.Add(ItemAB);
            ItemList.Add(ItemAC);
            ItemList.Add(ItemAD);
            ItemList.Add(ItemAE);
            ItemList.Add(ItemAF);
            ItemList.Add(ItemAG);
            ItemList.Add(ItemAH);
            ItemList.Add(ItemAI);

            ItemList.Add(ItemBA);
            ItemList.Add(ItemBB);
            ItemList.Add(ItemBC);
            ItemList.Add(ItemBD);
            ItemList.Add(ItemBE);
            ItemList.Add(ItemBF);
            ItemList.Add(ItemBG);
            ItemList.Add(ItemBH);
            ItemList.Add(ItemBI);

            ItemList.Add(ItemCA);
            ItemList.Add(ItemCB);
            ItemList.Add(ItemCC);
            ItemList.Add(ItemCD);
            ItemList.Add(ItemCE);
            ItemList.Add(ItemCF);
            ItemList.Add(ItemCG);
            ItemList.Add(ItemCH);
            ItemList.Add(ItemCI);

            ItemList.Add(ItemDA);
            ItemList.Add(ItemDB);
            ItemList.Add(ItemDC);
            ItemList.Add(ItemDD);
            ItemList.Add(ItemDE);
            ItemList.Add(ItemDF);
            ItemList.Add(ItemDG);
            ItemList.Add(ItemDH);
            ItemList.Add(ItemDI);

            ItemList.Add(ItemEA);
            ItemList.Add(ItemEB);
            ItemList.Add(ItemEC);
            ItemList.Add(ItemED);
            ItemList.Add(ItemEE);
            ItemList.Add(ItemEF);
            ItemList.Add(ItemEG);
            ItemList.Add(ItemEH);
            ItemList.Add(ItemEI);

            ItemList.Add(ItemFA);
            ItemList.Add(ItemFB);
            ItemList.Add(ItemFC);
            ItemList.Add(ItemFD);
            ItemList.Add(ItemFE);
            ItemList.Add(ItemFF);
            ItemList.Add(ItemFG);
            ItemList.Add(ItemFH);
            ItemList.Add(ItemFI);

            ItemList.Add(ItemGA);
            ItemList.Add(ItemGB);
            ItemList.Add(ItemGC);
            ItemList.Add(ItemGD);
            ItemList.Add(ItemGE);
            ItemList.Add(ItemGF);
            ItemList.Add(ItemGG);
            ItemList.Add(ItemGH);
            ItemList.Add(ItemGI);

            ItemList.Add(ItemHA);
            ItemList.Add(ItemHB);
            ItemList.Add(ItemHC);
            ItemList.Add(ItemHD);
            ItemList.Add(ItemHE);
            ItemList.Add(ItemHF);
            ItemList.Add(ItemHG);
            ItemList.Add(ItemHH);
            ItemList.Add(ItemHI);

            ItemList.Add(ItemIA);
            ItemList.Add(ItemIB);
            ItemList.Add(ItemIC);
            ItemList.Add(ItemID);
            ItemList.Add(ItemIE);
            ItemList.Add(ItemIF);
            ItemList.Add(ItemIG);
            ItemList.Add(ItemIH);
            ItemList.Add(ItemII);
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("CLICKED!");
            Button button = (Button)sender;
            switch (button.Content)
            {
                case "":
                    Refresh(button, "1", false);
                    break;
                case "1":
                    Refresh(button, "2", false);
                    break;
                case "2":
                    Refresh(button, "3", false);
                    break;
                case "3":
                    Refresh(button, "4", false);
                    break;
                case "4":
                    Refresh(button, "5", false);
                    break;
                case "5":
                    Refresh(button, "6", false);
                    break;
                case "6":
                    Refresh(button, "7", false);
                    break;
                case "7":
                    Refresh(button, "8", false);
                    break;
                case "8":
                    Refresh(button, "9", false);
                    break;
                case "9":
                    Refresh(button, "", false);
                    break;
            }
        }

        private void Solve_Clicked(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false; SudokuGrid.IsEnabled = false;

            while(ItemEmptyList.Count() != 0)
            {
                ItemEmptyList.Clear();
                ItemAvaibleList.Clear();

                int listIndex = 0;
                foreach (Button button in ItemList)
                {
                    if (button.Content.ToString() == "")
                    {
                        ItemEmptyList.Add(button);

                        foreach (char Char in Chars)
                        {

                        }
                    }

                    listIndex++;
                }
            }

            this.IsEnabled = true; SudokuGrid.IsEnabled = true;
        }
    }
}
