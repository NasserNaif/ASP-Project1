namespace Project1.Models.DTO;

public class FilterDto
{
    public string? FilterOn { get; set; }
    public string? FilterQuery { get; set; }
    public string? SortBy { get; set; }
    public bool IsAscending { get; set; } = true;
}