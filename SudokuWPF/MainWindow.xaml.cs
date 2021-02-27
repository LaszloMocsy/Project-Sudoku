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

        private void Load_ItemList()
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
            this.IsEnabled = false;
            List<string> NumberLine = new List<string>();

            foreach(Button button in ItemList)
            {
                if(button.Content.ToString() == "")
                {
                    ItemSolverList.Add(button);
                    NumberLine.Add("1");
                    Console.WriteLine(button.Name);
                }
            }
            Console.WriteLine(NumberLine.Count());

            bool solved = false;
            List<string> _ItemValueList = new List<string>();
            while (!solved)
            {
                _ItemValueList.Clear();
                int ItemNumber = 0;
                foreach (Button button in ItemList)
                {
                    if (ItemSolverList.Contains(button))
                    {
                        Refresh(button, NumberLine[ItemNumber], true);
                        _ItemValueList.Add(button.Content.ToString());
                    }
                    else
                    {
                        _ItemValueList.Add(button.Content.ToString());
                    }
                }

                solved = SudokuProcess(_ItemValueList);

            }

            this.IsEnabled = true;
        }

        public bool SudokuProcess(List<string> ItemValueList)
        {
            string[] Chars = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] HorizontalA = { ItemValueList[0], ItemValueList[1], ItemValueList[2], ItemValueList[3], ItemValueList[4], ItemValueList[5], ItemValueList[6], ItemValueList[7], ItemValueList[8] };
            string[] HorizontalB = { ItemValueList[9], ItemValueList[10], ItemValueList[11], ItemValueList[12], ItemValueList[13], ItemValueList[14], ItemValueList[15], ItemValueList[16], ItemValueList[17] };
            string[] HorizontalC = { ItemValueList[18], ItemValueList[19], ItemValueList[20], ItemValueList[21], ItemValueList[22], ItemValueList[23], ItemValueList[24], ItemValueList[25], ItemValueList[26] };
            string[] HorizontalD = { ItemValueList[27], ItemValueList[28], ItemValueList[29], ItemValueList[30], ItemValueList[31], ItemValueList[32], ItemValueList[33], ItemValueList[34], ItemValueList[35] };
            string[] HorizontalE = { ItemValueList[36], ItemValueList[37], ItemValueList[38], ItemValueList[39], ItemValueList[40], ItemValueList[41], ItemValueList[42], ItemValueList[43], ItemValueList[44] };
            string[] HorizontalF = { ItemValueList[45], ItemValueList[46], ItemValueList[47], ItemValueList[48], ItemValueList[49], ItemValueList[50], ItemValueList[51], ItemValueList[52], ItemValueList[53] };
            string[] HorizontalG = { ItemValueList[54], ItemValueList[55], ItemValueList[56], ItemValueList[57], ItemValueList[58], ItemValueList[59], ItemValueList[60], ItemValueList[61], ItemValueList[62] };
            string[] HorizontalH = { ItemValueList[63], ItemValueList[64], ItemValueList[65], ItemValueList[66], ItemValueList[67], ItemValueList[68], ItemValueList[69], ItemValueList[70], ItemValueList[71] };
            string[] HorizontalI = { ItemValueList[72], ItemValueList[73], ItemValueList[74], ItemValueList[75], ItemValueList[76], ItemValueList[77], ItemValueList[78], ItemValueList[79], ItemValueList[80] };
            string[] VerticalA = { ItemValueList[0], ItemValueList[9], ItemValueList[18], ItemValueList[27], ItemValueList[36], ItemValueList[45], ItemValueList[54], ItemValueList[63], ItemValueList[72] };
            string[] VerticalB = { ItemValueList[1], ItemValueList[10], ItemValueList[19], ItemValueList[28], ItemValueList[37], ItemValueList[46], ItemValueList[55], ItemValueList[64], ItemValueList[73] };
            string[] VerticalC = { ItemValueList[2], ItemValueList[11], ItemValueList[20], ItemValueList[29], ItemValueList[38], ItemValueList[47], ItemValueList[56], ItemValueList[65], ItemValueList[74] };
            string[] VerticalD = { ItemValueList[3], ItemValueList[12], ItemValueList[21], ItemValueList[30], ItemValueList[39], ItemValueList[48], ItemValueList[57], ItemValueList[66], ItemValueList[75] };
            string[] VerticalE = { ItemValueList[4], ItemValueList[13], ItemValueList[22], ItemValueList[31], ItemValueList[40], ItemValueList[49], ItemValueList[58], ItemValueList[67], ItemValueList[76] };
            string[] VerticalF = { ItemValueList[5], ItemValueList[14], ItemValueList[23], ItemValueList[32], ItemValueList[41], ItemValueList[50], ItemValueList[59], ItemValueList[68], ItemValueList[77] };
            string[] VerticalG = { ItemValueList[6], ItemValueList[15], ItemValueList[24], ItemValueList[33], ItemValueList[42], ItemValueList[51], ItemValueList[60], ItemValueList[69], ItemValueList[78] };
            string[] VerticalH = { ItemValueList[7], ItemValueList[16], ItemValueList[25], ItemValueList[34], ItemValueList[43], ItemValueList[52], ItemValueList[61], ItemValueList[70], ItemValueList[79] };
            string[] VerticalI = { ItemValueList[8], ItemValueList[17], ItemValueList[26], ItemValueList[35], ItemValueList[44], ItemValueList[53], ItemValueList[62], ItemValueList[71], ItemValueList[80] };
            string[] BoxA = { ItemValueList[0], ItemValueList[1], ItemValueList[2], ItemValueList[9], ItemValueList[10], ItemValueList[11], ItemValueList[18], ItemValueList[19], ItemValueList[20] };
            string[] BoxB = { ItemValueList[3], ItemValueList[4], ItemValueList[5], ItemValueList[12], ItemValueList[13], ItemValueList[14], ItemValueList[21], ItemValueList[22], ItemValueList[23] };
            string[] BoxC = { ItemValueList[6], ItemValueList[7], ItemValueList[8], ItemValueList[15], ItemValueList[16], ItemValueList[17], ItemValueList[24], ItemValueList[25], ItemValueList[26] };
            string[] BoxD = { ItemValueList[27], ItemValueList[28], ItemValueList[29], ItemValueList[36], ItemValueList[37], ItemValueList[38], ItemValueList[45], ItemValueList[46], ItemValueList[47] };
            string[] BoxE = { ItemValueList[30], ItemValueList[31], ItemValueList[32], ItemValueList[39], ItemValueList[40], ItemValueList[41], ItemValueList[48], ItemValueList[49], ItemValueList[50] };
            string[] BoxF = { ItemValueList[33], ItemValueList[34], ItemValueList[35], ItemValueList[42], ItemValueList[43], ItemValueList[44], ItemValueList[51], ItemValueList[52], ItemValueList[53] };
            string[] BoxG = { ItemValueList[54], ItemValueList[55], ItemValueList[56], ItemValueList[63], ItemValueList[64], ItemValueList[65], ItemValueList[72], ItemValueList[73], ItemValueList[74] };
            string[] BoxH = { ItemValueList[57], ItemValueList[58], ItemValueList[59], ItemValueList[66], ItemValueList[67], ItemValueList[68], ItemValueList[75], ItemValueList[76], ItemValueList[77] };
            string[] BoxI = { ItemValueList[60], ItemValueList[61], ItemValueList[62], ItemValueList[69], ItemValueList[70], ItemValueList[71], ItemValueList[78], ItemValueList[79], ItemValueList[80] };

            foreach(string _char in Chars){
                if (!HorizontalA.Contains(_char)) { return false; }
                if (!HorizontalB.Contains(_char)) { return false; }
                if (!HorizontalC.Contains(_char)) { return false; }
                if (!HorizontalD.Contains(_char)) { return false; }
                if (!HorizontalE.Contains(_char)) { return false; }
                if (!HorizontalF.Contains(_char)) { return false; }
                if (!HorizontalG.Contains(_char)) { return false; }
                if (!HorizontalH.Contains(_char)) { return false; }
                if (!HorizontalI.Contains(_char)) { return false; }
                if (!VerticalA.Contains(_char)) { return false; }
                if (!VerticalB.Contains(_char)) { return false; }
                if (!VerticalC.Contains(_char)) { return false; }
                if (!VerticalD.Contains(_char)) { return false; }
                if (!VerticalE.Contains(_char)) { return false; }
                if (!VerticalF.Contains(_char)) { return false; }
                if (!VerticalG.Contains(_char)) { return false; }
                if (!VerticalH.Contains(_char)) { return false; }
                if (!VerticalI.Contains(_char)) { return false; }
                if (!BoxA.Contains(_char)) { return false; }
                if (!BoxB.Contains(_char)) { return false; }
                if (!BoxC.Contains(_char)) { return false; }
                if (!BoxD.Contains(_char)) { return false; }
                if (!BoxE.Contains(_char)) { return false; }
                if (!BoxF.Contains(_char)) { return false; }
                if (!BoxG.Contains(_char)) { return false; }
                if (!BoxH.Contains(_char)) { return false; }
                if (!BoxI.Contains(_char)) { return false; }
            }

            Console.WriteLine("SUDOKU SOLVED!!!");
            return true; //Sudoku solved!
        }
    }
}
