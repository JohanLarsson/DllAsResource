namespace DllAsResource
{
    using System.Windows;
    using Newtonsoft.Json;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var dto = new Dto(1);
            var json = JsonConvert.SerializeObject(dto);
            var roundtripped = JsonConvert.DeserializeObject<Dto>(json);
            this.InitializeComponent();
        }
    }
}
