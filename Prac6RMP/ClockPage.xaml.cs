using System;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace Prac6RMP
{
    public partial class ClockPage : ContentPage, INotifyPropertyChanged
    {
        private string currentTime;
        private string currentDate;

        public string CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        public string CurrentDate
        {
            get => currentDate;
            set
            {
                currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        public ClockPage()
        {
            InitializeComponent();
            StartTimer();
            BindingContext = this; // Установить контекст привязки
        }

        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
                CurrentDate = DateTime.Now.ToString("MMMM dd, yyyy");
                return true; // Продолжать вызов каждые 1 секунду
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
