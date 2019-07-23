using System;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using GmStocks.Services;
using GmStocks.Models;
using System.Collections.Generic;
using GmStocks.Extensions;

namespace GmStocks.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly StockMarketService _stockMarketService = new StockMarketService();

        private string _symbolToAdd;
        public string SymbolToAdd
        {
            get => _symbolToAdd;
            set
            {
                _symbolToAdd = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<StockViewModel> _stocks = new ObservableCollection<StockViewModel>();
        public ObservableCollection<StockViewModel> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value;
                RaisePropertyChanged();
            }
        }

        private int _intradayIntervalIndex;
        public int IntradayIntervalIndex
        {
            get => _intradayIntervalIndex;
            set
            {
                _intradayIntervalIndex = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _intervals;
        public ObservableCollection<string> Intervals
        {
            get => _intervals;
            set
            {
                _intervals = value;
                RaisePropertyChanged();
            }
        }

        private Command _addStock;
        public Command AddStock => _addStock ?? (_addStock = new Command(async () =>
        {
            if (!string.IsNullOrEmpty(_symbolToAdd))
            {
                if (!Stocks?.Any(a => a.Symbol == _symbolToAdd) ?? true)
                {
                    var stock = await _stockMarketService.GetStockAsync(_symbolToAdd, (IntradayIntervals)_intradayIntervalIndex).ConfigureAwait(false);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Stocks.Add(new StockViewModel(stock));
                    });
                }
            }
        }));


        public MainPageViewModel()
        {
            Intervals = new ObservableCollection<string>
           {
               IntradayIntervals.one.ToDescription(),
               IntradayIntervals.five.ToDescription(),
               IntradayIntervals.fifteen.ToDescription(),
               IntradayIntervals.thirty.ToDescription(),
               IntradayIntervals.sixty.ToDescription()
           };
        }
    }
}
