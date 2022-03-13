using EFCUTY_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFCUTY_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Country> Countries { get; set; }
        private Country selectedCountry;

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = new Country()
                {
                    CountryID = value.CountryID,
                    Name = value.Name,
                    IsOECDMember = value.IsOECDMember,
                    TotalGDPInMillionUSD = value.TotalGDPInMillionUSD
                };
                OnPropertyChanged();
                (DeleteCountryCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateCountryCommand { get; set; }
        public ICommand DeleteCountryCommand { get; set; }
        public ICommand UpdateCountryCommand { get; set; }


        public MainWindowViewModel()
        {
            Countries = new RestCollection<Country>("http://localhost:54726/", "country");
            CreateCountryCommand = new RelayCommand(() =>
            {
                Countries.Add(new Country()
                {
                    Name=SelectedCountry.Name
                });
            });

            UpdateCountryCommand = new RelayCommand(() =>
            {
                Countries.Update(SelectedCountry);
            });

            DeleteCountryCommand = new RelayCommand(() =>
            {
                Countries.Delete(SelectedCountry.CountryID);
            },
            () =>
            {
                return SelectedCountry != null;
            });
            SelectedCountry = new Country();

        }
    }
}
