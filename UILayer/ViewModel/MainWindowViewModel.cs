using System;
using System.Collections.ObjectModel;
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

        public RelayCommand ShowFileChoice { get; private set; }


        public MainWindowViewModel(ISettingsRepo settingsRepo, IClippingsRepository clippingsRepository)
        {
            _settingsRepo = settingsRepo;
            _clippingsRepository = clippingsRepository;

            BookTitles = new ObservableCollection<string>();
            ShowFileChoice = new RelayCommand(OpenFile, () => true);

            var fileNameFromSettings = _settingsRepo.GetClippingsFileName();
            
            if (String.IsNullOrWhiteSpace(fileNameFromSettings) == false)
                PopulateFromSaved(fileNameFromSettings);
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog{Filter = "Clippings Files (My Clippings.txt)|My Clippings.txt|All files (*.*)|*.*"};

            if (openFileDialog.ShowDialog() == true)
                PopulateFromSaved(openFileDialog.FileName);
        }

        private void PopulateFromSaved(string fileNameFromSettings)
        {
            // TODO ERROR HANDLING!

            _clippingsRepository.LoadFromFile(fileNameFromSettings);
            
            var bookTitles = _clippingsRepository.GetBookTitles();

            BookTitles.Clear();
            
            foreach (var  bookTitle in bookTitles)
                BookTitles.Add(bookTitle);
        }

    }
}
