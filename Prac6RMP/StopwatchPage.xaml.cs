namespace Prac6RMP;

public partial class StopwatchPage : ContentPage
{
    private bool isRunning = false;
    private TimeSpan elapsedTime;
    private DateTime startTime;
    private System.Timers.Timer timer;

    public StopwatchPage()
    {
        InitializeComponent();
        timer = new System.Timers.Timer(1000); // Каждую секунду
        timer.Elapsed += OnTimedEvent;
    }

    private void StartStopButton_Clicked(object sender, EventArgs e)
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = DateTime.Now;
            timer.Start();
        }
        else
        {
            isRunning = false;
            timer.Stop();
        }
    }

    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        elapsedTime = DateTime.Now - startTime;
        // Обновить UI в основном потоке
        Device.BeginInvokeOnMainThread(() =>
        {
            ElapsedTimeLabel.Text = elapsedTime.ToString(@"hh\:mm\:ss"); // Отображение времени
        });
    }
}