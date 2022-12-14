using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;
using Model;

namespace View
{
    /*
        The PlayerUserControl class
        The class responsible to the interaction between the user and the player
     */
    public partial class PlayerUserControl : UserControl
    {
        // Declaring a field for the view model
        private PlayerViewModel playerVM;
        // Constructor of the PlayerUserControl class
        public PlayerUserControl()
        {
            InitializeComponent();
            this.playerVM = new PlayerViewModel(FIAModel.Model);
            DataContext = this.playerVM;
        }
        // Open the "Open File" dialog to load the CSV file
        private void OpenCSV_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadCSV();
            this.exception.Text = "";
        }
        // Pause the video on mouse up
        private void Pause_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.pause();
            (e.Source as FrameworkElement).Opacity = 0.8;
            //this.play.Opacity = 1;
            //this.pause.Opacity = 0.3;
        }
        // Play the video on mouse up
        private void Play_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.play();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Stop the video on mouse up
        private void Stop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.stop();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Jump 10 seconds backwards on mouse up
        private void FastBackwards_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastBackwards();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Jump 10 seconds forward on mouse up
        private void FastForward_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.fastForward();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Jump to the start of the video on mouse up
        private void JumpToStart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToStart();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Jump to the end of the video on mouse up
        private void JumpToEnd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.playerVM.jumpToEnd();
            (e.Source as FrameworkElement).Opacity = 0.8;
        }
        // Jump to the new time set when the slider's value change
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.playerVM.VM_Time = (int)playerSlider.Value;
        }
        // Change the playback speed based on the input, on enter key up
        private void playbackSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && playbackSpeed != null)
            {
                if (this.playerVM.VM_PlaybackSpeed == 0)
                {
                    this.playerVM.play();
                }
                float speed;
                bool valid = float.TryParse(playbackSpeed.Text, out speed);
                if (valid)
                {
                    this.playerVM.VM_PlaybackSpeed = speed;
                    this.exception.Text = "";
                }
                else
                {
                    this.exception.Text = "Please enter a valid value";
                    this.playbackSpeed.Text = this.playerVM.VM_PlaybackSpeed.ToString();
                }
            }
        }
        // Open the "Open File" dialog to load the XML file
        private void openXML_Click(object sender, RoutedEventArgs e)
        {
            this.playerVM.loadXML();
            this.OpenCSV.IsEnabled = true;
            this.exception.Text = "Please load a flight record";
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            (e.Source as FrameworkElement).Opacity = 0.8;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (e.Source as FrameworkElement).Opacity = 1;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (e.Source as FrameworkElement).Opacity = 0.5;
        }
    }
}
