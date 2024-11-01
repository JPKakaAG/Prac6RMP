using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Prac6RMP
{
    public partial class AlarmPage : ContentPage
    {
        private List<Alarm> alarms = new List<Alarm>();

        public AlarmPage()
        {
            InitializeComponent();
        }

        private void SetAlarmButton_Clicked(object sender, EventArgs e)
        {
            TimeSpan selectedTime = alarmTimePicker.Time;
            alarms.Add(new Alarm { Time = selectedTime });

            // Здесь добавьте логику а также таймер для проверки срабатывания будильника
            CheckAlarms();
        }

        private async void CheckAlarms()
        {
            while (true)
            {
                foreach (var alarm in alarms)
                {
                    if (DateTime.Now.TimeOfDay >= alarm.Time)
                    {
                        // Срабатывание будильника
                        await Application.Current.MainPage.DisplayAlert("Будильник", "Время будильника!", "OK");
                        alarms.Remove(alarm); // Удаляем сигнализировавший будильник
                        break; // выход из цикла
                    }
                }
                await Task.Delay(1000); // Проверка каждую секунду
            }
        }
    }

    public class Alarm
    {
        public TimeSpan Time { get; set; }
    }
}
