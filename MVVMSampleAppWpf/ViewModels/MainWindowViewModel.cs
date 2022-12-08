using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMSampleAppWpf.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace MVVMSampleAppWpf.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<DemoItem> DemoItems { get; }
        private ICollectionView _demoItemsView;

        [ObservableProperty]
        public DemoItem selectedItem;

        [ObservableProperty]
        public bool drawerOpened = false;

        [ObservableProperty]
        public string searchKeyword = String.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BackExecuteCommand), nameof(ForwardExecuteCommand))]
        public int selectedIndex = 0;
        public MainWindowViewModel()
        {
            DemoItems = new ObservableCollection<DemoItem>()
            {
                new DemoItem("Home"),
                new DemoItem("Buttons"),
                new DemoItem("Cards"),
                //new DemoItem("Chips"),
                //new DemoItem("Color Tool"),
                //new DemoItem("Colour Zones"),
                //new DemoItem("ComboBoxes"),
                //new DemoItem("Data Grids"),
                //new DemoItem("Dialogs"),
                //new DemoItem("Drawer"),
                //new DemoItem("Elevation"),
                //new DemoItem("Expander"),
                //new DemoItem("Fields"),
                //new DemoItem("Fields line up"),
                //new DemoItem("Group Boxes"),
                //new DemoItem("Icon Pack"),
                //new DemoItem("Lists"),
                //new DemoItem("Menus & Tool Bars"),
                //new DemoItem("Navigation Rail"),
                //new DemoItem("Palette"),
                //new DemoItem("Pickers"),
                //new DemoItem("Progress Indicators"),
                //new DemoItem("Rating Bar"),
                //new DemoItem("Sliders"),
                //new DemoItem("Snackbar"),
                //new DemoItem("Tabs"),
                //new DemoItem("Toggles"),
                //new DemoItem("Transitions"),
                //new DemoItem("Trees"),
                //new DemoItem("Typography"),
            };
            selectedItem = DemoItems.First();

            _demoItemsView = CollectionViewSource.GetDefaultView(DemoItems);
            _demoItemsView.Filter = DemoItemsFilter;
        }
        private bool DemoItemsFilter(object obj)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                return true;
            }

            return obj is DemoItem item
                   && item.Name.ToLower().Contains(searchKeyword!.ToLower());
        }

        partial void OnSelectedItemChanged(DemoItem value)
        {
            DrawerOpened = false;
        }

        partial void OnSearchKeywordChanged(string value)
        {
            _demoItemsView.Refresh();
        }

        [RelayCommand(CanExecute = nameof(CanBackExecute))]
        private void BackExecute()
        {
            if (!string.IsNullOrWhiteSpace(SearchKeyword))
                SearchKeyword = string.Empty;

            SelectedIndex--;
        }

        [RelayCommand(CanExecute = nameof(CanHomeExecute))]
        private void HomeExecute()
        {
            if (!string.IsNullOrWhiteSpace(SearchKeyword))
                SearchKeyword = string.Empty;

            SelectedIndex = 0;
        }

        [RelayCommand(CanExecute = nameof(CanForwardExecute))]
        private void ForwardExecute()
        {
            SearchKeyword = string.Empty;
            SelectedIndex ++;
        }

        private bool CanBackExecute()
        {
            return SelectedIndex > 0;
        }

        private bool CanHomeExecute()
        {
            return true;
        }

        private bool CanForwardExecute()
        {
            return SelectedIndex < DemoItems.Count - 1;
        }
    }
}
