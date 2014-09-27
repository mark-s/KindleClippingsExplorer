using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ClippingsExplorer.Entities;
using ClippingsExplorer.ServiceLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace ClippingsExplorer.UILayer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISettingsRepo _settingsRepo;
        private readonly IClippingsRepository _clippingsRepository;

        public ObservableCollection<string> BookTitles { get; private set; }
        public ObservableCollection<HighlightItem> HigilightsForBook { get; private set; }

        private string _selectedBookTitle;
        private HighlightItem _selectedDateItem;

        public string SelectedBookTitle
        {
            get { return _selectedBookTitle; }
            set
            {
                _selectedBookTitle = value;
                UpdateDatesListForBook(value);
            }
        }

        public HighlightItem SelectedDateItem
        {
            get { return _selectedDateItem; }
            set
            {
                Set(() => SelectedDateItem, ref  _selectedDateItem, value);
            }
        }


        public RelayCommand ShowFileChoice { get; private set; }

        
        public MainWindowViewModel(ISettingsRepo settingsRepo, IClippingsRepository clippingsRepository)
        {
            _settingsRepo = settingsRepo;
            _clippingsRepository = clippingsRepository;

            BookTitles = new ObservableCollection<string>();
            HigilightsForBook = new ObservableCollection<HighlightItem>();

            ShowFileChoice = new RelayCommand(OpenFile, () => true);
            
            var fileNameFromSettings = _settingsRepo.GetClippingsFileName();

            if (String.IsNullOrWhiteSpace(fileNameFromSettings) == false)
                PopulateFromSaved(fileNameFromSettings);
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog { Filter = "Clippings Files (My Clippings.txt)|My Clippings.txt|All files (*.*)|*.*" };

            if (openFileDialog.ShowDialog() == true)
                PopulateFromSaved(openFileDialog.FileName);
        }

        private void UpdateDatesListForBook(string selectedBookTitle)
        {
            HigilightsForBook.Clear();
            var tmp = _clippingsRepository.GetHighlightsForBook(selectedBookTitle);
            foreach (var highlightItem in tmp)
                HigilightsForBook.Add(highlightItem);
        }

        private void PopulateFromSaved(string fileNameFromSettings)
        {
            // TODO ERROR HANDLING!

            _clippingsRepository.LoadFromFile(fileNameFromSettings);

            var bookTitles = _clippingsRepository.GetBookTitles();

            BookTitles.Clear();

            foreach (var bookTitle in bookTitles)
                BookTitles.Add(bookTitle);
        }

    }
}
