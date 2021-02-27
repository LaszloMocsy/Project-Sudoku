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
        List<Button> ItemList = new List<Button>();
        List<Button> ItemSolverList = new List<Button>();
        Brush ColorDefault = Brushes.Black;
        Brush ColorUser = Brushes.Blue;
        List<char> Chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        List<char> BoxAAChars = new List<char>();
        List<char> BoxABChars = new List<char>();
        List<char> BoxACChars = new List<char>();
        List<char> BoxBAChars = new List<char>();
        List<char> BoxBBChars = new List<char>();
        List<char> BoxBCChars = new List<char>();
        List<char> BoxCAChars = new List<char>();
        List<char> BoxCBChars = new List<char>();
        List<char> BoxCCChars = new List<char>();

        public MainWindow()
        {
            InitializeComponent();
            Load_ItemList();
            foreach (Button button in ItemList)
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
            ItemList.Add(ItemBA);
            ItemList.Add(ItemBB);
            ItemList.Add(ItemBC);
            ItemList.Add(ItemCA);
            ItemList.Add(ItemCB);
            ItemList.Add(ItemCC);

            ItemList.Add(ItemAD);
            ItemList.Add(ItemAE);
            ItemList.Add(ItemAF);
            ItemList.Add(ItemBD);
            ItemList.Add(ItemBE);
            ItemList.Add(ItemBF);
            ItemList.Add(ItemCD);
            ItemList.Add(ItemCE);
            ItemList.Add(ItemCF);

            ItemList.Add(ItemAG);
            ItemList.Add(ItemAH);
            ItemList.Add(ItemAI);
            ItemList.Add(ItemBG);
            ItemList.Add(ItemBH);
            ItemList.Add(ItemBI);
            ItemList.Add(ItemCG);
            ItemList.Add(ItemCH);
            ItemList.Add(ItemCI);

            ItemList.Add(ItemDA);
            ItemList.Add(ItemDB);
            ItemList.Add(ItemDC);
            ItemList.Add(ItemEA);
            ItemList.Add(ItemEB);
            ItemList.Add(ItemEC);
            ItemList.Add(ItemFA);
            ItemList.Add(ItemFB);
            ItemList.Add(ItemFC);

            ItemList.Add(ItemDD);
            ItemList.Add(ItemDE);
            ItemList.Add(ItemDF);
            ItemList.Add(ItemED);
            ItemList.Add(ItemEE);
            ItemList.Add(ItemEF);
            ItemList.Add(ItemFD);
            ItemList.Add(ItemFE);
            ItemList.Add(ItemFF);

            ItemList.Add(ItemDG);
            ItemList.Add(ItemDH);
            ItemList.Add(ItemDI);
            ItemList.Add(ItemEG);
            ItemList.Add(ItemEH);
            ItemList.Add(ItemEI);
            ItemList.Add(ItemFG);
            ItemList.Add(ItemFH);
            ItemList.Add(ItemFI);

            ItemList.Add(ItemGA);
            ItemList.Add(ItemGB);
            ItemList.Add(ItemGC);
            ItemList.Add(ItemHA);
            ItemList.Add(ItemHB);
            ItemList.Add(ItemHC);
            ItemList.Add(ItemIA);
            ItemList.Add(ItemIB);
            ItemList.Add(ItemIC);

            ItemList.Add(ItemGD);
            ItemList.Add(ItemGE);
            ItemList.Add(ItemGF);
            ItemList.Add(ItemHD);
            ItemList.Add(ItemHE);
            ItemList.Add(ItemHF);
            ItemList.Add(ItemID);
            ItemList.Add(ItemIE);
            ItemList.Add(ItemIF);

            ItemList.Add(ItemGG);
            ItemList.Add(ItemGH);
            ItemList.Add(ItemGI);
            ItemList.Add(ItemHG);
            ItemList.Add(ItemHH);
            ItemList.Add(ItemHI);
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
            this.IsEnabled = false;

            int _BoxIndex = 1;
            foreach(Button button in ItemList)
            {
                if(button.Content.ToString() == "")
                {
                    ItemSolverList.Add(button);
                    Console.WriteLine(button.Name);
                }
                else
                {
                    if(_BoxIndex <= 9)
                    {
                        BoxAAChars.Add(Convert.ToChar(button.Content));
                    }
                    else if(10 <= _BoxIndex && _BoxIndex <= 18)
                    {
                        BoxABChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (19 <= _BoxIndex && _BoxIndex <= 27)
                    {
                        BoxACChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (28 <= _BoxIndex && _BoxIndex <= 36)
                    {
                        BoxBAChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (37 <= _BoxIndex && _BoxIndex <= 45)
                    {
                        BoxBBChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (46 <= _BoxIndex && _BoxIndex <= 54)
                    {
                        BoxBCChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (55 <= _BoxIndex && _BoxIndex <= 63)
                    {
                        BoxCAChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (64 <= _BoxIndex && _BoxIndex <= 72)
                    {
                        BoxCBChars.Add(Convert.ToChar(button.Content));
                    }
                    else if (73 <= _BoxIndex && _BoxIndex <= 81)
                    {
                        BoxCCChars.Add(Convert.ToChar(button.Content));
                    }
                }
                _BoxIndex++;
            }

            this.IsEnabled = true;
        }
    }
}
