using Model;
using System.Windows.Controls;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class joystickUserControl : UserControl
    {
        private JoystickViewModel joystickVM;
        public joystickUserControl()
        {
            InitializeComponent();
            joystickVM = new JoystickViewModel(FIAModel.Model);
            DataContext = joystickVM;
        }
    }
}

