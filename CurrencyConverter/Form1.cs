using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string APIKey = "bsSlFZvE4WokZlLKR3wEFmoH0pZBoSQssZxEQluI";

        private void btn_convert_Click(object sender, EventArgs e)
        {
            getConversion();
        }

        private void getConversion()
        {
            using (WebClient web = new WebClient())
            {
                if (btn_from_value.Text == "N/A ▼" || btn_to_value.Text == "N/A ▼")
                {
                    lab_amount_to_value.Text = "Select currency!";
                    return;
                }
                if (!IsDigitsOnly(tb_amount_from_value.Text))
                {
                    lab_amount_to_value.Text = "Wrong amount format!\nEnter digits only";
                    return;
                }
                if (tb_amount_from_value.Text == "")
                {
                    lab_amount_to_value.Text = "Enter amount!";
                    return;
                }
                string from_val = btn_from_value.Text;
                from_val = from_val[0].ToString() + from_val[1].ToString() + from_val[2];
                string to_val = btn_to_value.Text;
                to_val = to_val[0].ToString() + to_val[1].ToString() + to_val[2];
                string url = string.Format("https://api.freecurrencyapi.com/v1/latest?apikey={0}&currencies={1}&base_currency={2}", APIKey, to_val, from_val);

                var json = web.DownloadString(url);
                Currency.Root info = JsonConvert.DeserializeObject<Currency.Root>(json);
                double result = double.Parse(tb_amount_from_value.Text);
                double first_result = result;
                switch (to_val)
                {
                    case "AUD":
                        result = result * info.data.AUD;
                        break;
                    case "BGN":
                        result = result * info.data.BGN;
                        break;
                    case "BRL":
                        result = result * info.data.BRL;
                        break;
                    case "CAD":
                        result = result * info.data.CAD;
                        break;
                    case "CHF":
                        result = result * info.data.CHF;
                        break;
                    case "CNY":
                        result = result * info.data.CNY;
                        break;
                    case "CZK":
                        result = result * info.data.CZK;
                        break;
                    case "DKK":
                        result = result * info.data.DKK;
                        break;
                    case "EUR":
                        result = result * info.data.EUR;
                        break;
                    case "GBP":
                        result = result * info.data.GBP;
                        break;
                    case "HKD":
                        result = result * info.data.HKD;
                        break;
                    case "HRK":
                        result = result * info.data.HRK;
                        break;
                    case "HUF":
                        result = result * info.data.HUF;
                        break;
                    case "IDR":
                        result = result * info.data.IDR;
                        break;
                    case "ILS":
                        result = result * info.data.ILS;
                        break;
                    case "INR":
                        result = result * info.data.INR;
                        break;
                    case "ISK":
                        result = result * info.data.ISK;
                        break;
                    case "JPY":
                        result = result * info.data.JPY;
                        break;
                    case "KRW":
                        result = result * info.data.KRW;
                        break;
                    case "MXN":
                        result = result * info.data.MXN;
                        break;
                    case "MYR":
                        result = result * info.data.MYR;
                        break;
                    case "NOK":
                        result = result * info.data.NOK;
                        break;
                    case "NZD":
                        result = result * info.data.NZD;
                        break;
                    case "PHP":
                        result = result * info.data.PHP;
                        break;
                    case "PLN":
                        result = result * info.data.PLN;
                        break;
                    case "RON":
                        result = result * info.data.RON;
                        break;
                    case "RUB":
                        result = result * info.data.RUB;
                        break;
                    case "SEK":
                        result = result * info.data.SEK;
                        break;
                    case "SGD":
                        result = result * info.data.SGD;
                        break;
                    case "THB":
                        result = result * info.data.THB;
                        break;
                    case "TRY":
                        result = result * info.data.TRY;
                        break;
                    case "USD":
                        result = result * info.data.USD;
                        break;
                    case "ZAR":
                        result = result * info.data.ZAR;
                        break;
                    default:
                        lab_amount_to_value.Text = "N/A";
                        break;
                }
                lab_amount_to_value.Text = convertNumber(result.ToString("0.00"));
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private string convertNumber(string number)
        {
            int index;
            string start;
            string end;
            if (number.Contains(','))
            {
                index = number.IndexOf(',');
                Debug.WriteLine(index);
            }
            else
            {
                index = number.Length;
            }
            while (index > 3)
            {
                index -= 3;
                end = number.Substring(index, number.Length - index);
                start = number.Substring(0, index);
                number = start + '.' + end;
            }
            return number;
        }

        private void tb_amount_from_value_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btn_convert_Click(this, new EventArgs());
            }
        }

        private void btn_from_value_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            List<string> currencies = new List<string>();
            currencies.Add("AUD");
            currencies.Add("BGN");
            currencies.Add("BRL");
            currencies.Add("CAD");
            currencies.Add("CHF");
            currencies.Add("CNY");
            currencies.Add("CZK");
            currencies.Add("DKK");
            currencies.Add("EUR");
            currencies.Add("GBP");
            currencies.Add("HKD");
            currencies.Add("HRK");
            currencies.Add("HUF");
            currencies.Add("IDR");
            currencies.Add("ILS");
            currencies.Add("INR");
            currencies.Add("ISK");
            currencies.Add("JPY");
            currencies.Add("KRW");
            currencies.Add("MXN");
            currencies.Add("MYR");
            currencies.Add("NOK");
            currencies.Add("NZD");
            currencies.Add("PHP");
            currencies.Add("PLN");
            currencies.Add("RON");
            currencies.Add("RUB");
            currencies.Add("SEK");
            currencies.Add("SGD");
            currencies.Add("THB");
            currencies.Add("TRY");
            currencies.Add("USD");
            currencies.Add("ZAR");

            var listViewItems = currencies.Select(x => new ListViewItem(x, 0)).ToArray();

            ListView listView = new ListView();
            listView.View = View.SmallIcon;
            listView.MultiSelect = false;

            listView.Items.AddRange(listViewItems);
            int itemToShow = 10;
            var lastItemToShow = listViewItems.Take(itemToShow).Last();
            int height = lastItemToShow.Bounds.Bottom + listView.Margin.Top;
            listView.Height = height;
            listView.HotTracking = true;
            listView.Activation = ItemActivation.OneClick;
            listView.ItemActivate += new EventHandler(listView_ItemActivate);
            var popup = new ToolStripDropDown();
            popup.AutoSize = false;
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            ToolStripControlHost host = new ToolStripControlHost(listView);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = listView.Size;
            popup.Size = listView.Size;
            popup.Items.Add(host);

            popup.Show(this, button.Left, button.Bottom);
        }

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            var item = listView.SelectedItems[0].ToString();
            var dropdown = listView.Parent as ToolStripDropDown;

            listView.SelectedIndexChanged -= listView_ItemActivate;

            dropdown.Close();

            btn_from_value.Text = item[15].ToString() + item[16].ToString() + item[17] + " ▼";
        }

        private void btn_to_value_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            List<string> currencies = new List<string>();
            currencies.Add("AUD");
            currencies.Add("BGN");
            currencies.Add("BRL");
            currencies.Add("CAD");
            currencies.Add("CHF");
            currencies.Add("CNY");
            currencies.Add("CZK");
            currencies.Add("DKK");
            currencies.Add("EUR");
            currencies.Add("GBP");
            currencies.Add("HKD");
            currencies.Add("HRK");
            currencies.Add("HUF");
            currencies.Add("IDR");
            currencies.Add("ILS");
            currencies.Add("INR");
            currencies.Add("ISK");
            currencies.Add("JPY");
            currencies.Add("KRW");
            currencies.Add("MXN");
            currencies.Add("MYR");
            currencies.Add("NOK");
            currencies.Add("NZD");
            currencies.Add("PHP");
            currencies.Add("PLN");
            currencies.Add("RON");
            currencies.Add("RUB");
            currencies.Add("SEK");
            currencies.Add("SGD");
            currencies.Add("THB");
            currencies.Add("TRY");
            currencies.Add("USD");
            currencies.Add("ZAR");

            var listViewItems = currencies.Select(x => new ListViewItem(x, 0)).ToArray();

            ListView listView = new ListView();
            listView.View = View.SmallIcon;
            listView.MultiSelect = false;

            listView.Items.AddRange(listViewItems);
            int itemToShow = 10;
            var lastItemToShow = listViewItems.Take(itemToShow).Last();
            int height = lastItemToShow.Bounds.Bottom + listView.Margin.Top;
            listView.Height = height;
            listView.HotTracking = true;
            listView.Activation = ItemActivation.OneClick;
            listView.ItemActivate += new EventHandler(listView_ItemActivate_to);
            var popup = new ToolStripDropDown();
            popup.AutoSize = false;
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            ToolStripControlHost host = new ToolStripControlHost(listView);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = listView.Size;
            popup.Size = listView.Size;
            popup.Items.Add(host);

            popup.Show(this, button.Left, button.Bottom);
        }
        private void listView_ItemActivate_to(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            var item = listView.SelectedItems[0].ToString();
            var dropdown = listView.Parent as ToolStripDropDown;

            listView.SelectedIndexChanged -= listView_ItemActivate_to;

            dropdown.Close();

            btn_to_value.Text = item[15].ToString() + item[16].ToString() + item[17] + " ▼";
        }

        private void btn_switch_Click(object sender, EventArgs e)
        {
            string val = btn_from_value.Text;
            btn_from_value.Text = btn_to_value.Text;
            btn_to_value.Text = val;
            tb_amount_from_value.Text = "";
            lab_amount_to_value.Text = "N/A";
        }
    }
}
