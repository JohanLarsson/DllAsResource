namespace DllAsResource
{
    using System.Windows;
    using Newtonsoft.Json;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            TextBlock.Text = JsonConvert.SerializeObject(new Dto(1));
        }
    }
}
