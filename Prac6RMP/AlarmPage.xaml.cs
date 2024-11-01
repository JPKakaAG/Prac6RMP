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

            // ����� �������� ������ � ����� ������ ��� �������� ������������ ����������
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
                        // ������������ ����������
                        await Application.Current.MainPage.DisplayAlert("���������", "����� ����������!", "OK");
                        alarms.Remove(alarm); // ������� ����������������� ���������
                        break; // ����� �� �����
                    }
                }
                await Task.Delay(1000); // �������� ������ �������
            }
        }
    }

    public class Alarm
    {
        public TimeSpan Time { get; set; }
    }
}
