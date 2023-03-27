using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAdrrress, decimal moneyToInvest, string brokerName )
        {
            FullName = fullName;
            EmailAddress = emailAdrrress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            Portfolio = new List<Stock>();



        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public List<Stock> Portfolio { get; set; }

        public int Count => Portfolio.Count;


        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;

            }

        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(s =>s.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
           
                Stock foundSock = Portfolio.Where(s => s.CompanyName == companyName).FirstOrDefault();
                if (sellPrice < foundSock.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }

            

            Portfolio.Remove(foundSock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";


        }
        public Stock FindStock(string companyName)
        {


            if (Portfolio.Any(s => s.CompanyName == companyName))
            {
                Stock findStock = Portfolio.Where(s => s.CompanyName == companyName).FirstOrDefault();
                return findStock;
            }
            else return null;

        }
        public Stock FindBiggestCompany()
        {

            if (Portfolio.Count > 0)
            {
                decimal max = 0;
                Stock maxStock = null;
                foreach (var stock in Portfolio)
                {
                    if (stock.MarketCapitalization > max)
                    {
                        max = stock.MarketCapitalization;
                        maxStock = stock;

                    }
                }
                return maxStock;

            }
            else return null;


        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());

            }


            return sb.ToString().Trim();
        }
    }
}
