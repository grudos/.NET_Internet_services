namespace BlazorServerDbContextExample.Grid
{
    public interface IAthleteFilters
    {
        bool Loading { get; set; }

        bool ShowFirstNameFirst { get; set; }
    }
}
