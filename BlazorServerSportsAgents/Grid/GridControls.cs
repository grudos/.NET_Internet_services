namespace BlazorServerDbContextExample.Grid
{
    public class GridControls : IAthleteFilters
    {
        public GridControls()
        {}

        public bool Loading { get; set; }

        public bool ShowFirstNameFirst { get; set; }
    }
}
