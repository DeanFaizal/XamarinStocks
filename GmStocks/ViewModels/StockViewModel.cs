using System;
using GmStocks.Models;

namespace GmStocks.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                RaisePropertyChanged();
            }
        }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }

        public StockViewModel(BaseStock stock)
        {
            Symbol = stock.MetaData.Symbol;
        }

    }
}
