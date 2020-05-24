namespace CPMusic.Areas.Admin.ViewModels
{
    public class StatisticalViewModel
    {
        public string Name { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public string BackgroundIcon { get; set; } = null!;
        
        public int Total { get; set; }
        
        public double Percent { get; set; }
    }
}
