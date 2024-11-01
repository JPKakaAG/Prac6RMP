using System.Timers;

namespace Prac6RMP;

public partial class TimerPage : ContentPage
{
    private System.Timers.Timer timer;

    public TimerPage()
    {
        InitializeComponent();
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        // Получить значение времени из поля ввода
        int timeInSeconds = Int32.Parse(timerInput.Text);
        timer = new System.Timers.Timer(timeInSeconds * 1000);
        timer.Elapsed += TimerElapsed;
        timer.Start();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            DisplayAlert("Время истекло", "Таймер завершен!", "ОК");
            timer.Stop();
        });
    }
}