namespace BlazorServerDbContextExample.Grid
{
    public interface IAthleteFilters
    {
        AthleteFilterColumns FilterColumn { get; set; }

        bool Loading { get; set; }

        string? FilterText { get; set; }

        bool ShowFirstNameFirst { get; set; }

        bool SortAscending { get; set; }

        AthleteFilterColumns SortColumn { get; set; }
    }
}
