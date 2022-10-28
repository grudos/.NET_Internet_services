namespace BlazorServerDbContextExample.Grid
{
    public class GridControls : IAthleteFilters
    {
        public GridControls()
        {}

        public bool Loading { get; set; }

        public bool ShowFirstNameFirst { get; set; }

        public AthleteFilterColumns SortColumn { get; set; }
            = AthleteFilterColumns.FullName;

        public bool SortAscending { get; set; } = true;

        public AthleteFilterColumns FilterColumn { get; set; }
            = AthleteFilterColumns.FullName;

        public string? FilterText { get; set; }
    }
}
