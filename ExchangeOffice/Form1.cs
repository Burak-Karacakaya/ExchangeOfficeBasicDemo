using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace ExchangeOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string todayExchangeInfo = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(todayExchangeInfo);

            string dollarBuying = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerText;
            LblDollarBuy.Text = dollarBuying;

            string dollarSelling = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerText;
            LblDollarSell.Text = dollarSelling;

            string euroBuying = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerText;
            LblEuroBuy.Text = euroBuying;

            string euroSelling = xmlDocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerText;
            LblEuroSell.Text = euroSelling;
        }

        private void BtnDollarBuyInfo_Click(object sender, EventArgs e)
        {
            offerBox.Text = LblDollarBuy.Text;
        }

        private void BtnDollarSellInfo_Click(object sender, EventArgs e)
        {
            offerBox.Text = LblDollarSell.Text;
        }

        private void BtnEuroBuyInfo_Click(object sender, EventArgs e)
        {
            offerBox.Text = LblEuroBuy.Text;
        }

        private void BtnEuroSellInfo_Click(object sender, EventArgs e)
        {
            offerBox.Text = LblEuroSell.Text;
        }

        private void BtnForAmount_Click(object sender, EventArgs e)
        {
            double offer, amount, price;
            offer = Convert.ToDouble(offerBox.Text);
            amount = Convert.ToDouble(amountBox.Text);
            price = offer * amount;
            priceBox.Text = price.ToString();
        }

        private void offerBox_TextChanged(object sender, EventArgs e)
        {
            offerBox.Text = offerBox.Text.Replace(".", ",");
        }

        private void btnFprPrice_Click(object sender, EventArgs e)
        {
            double offer = Convert.ToDouble(offerBox.Text);
            int price = Convert.ToInt32(priceBox.Text);
            int amount = Convert.ToInt32(price / offer);
            amountBox.Text = amount.ToString();

            double change;
            change = price % offer;
            changeBox.Text = change.ToString(); 
        }
    }
}
