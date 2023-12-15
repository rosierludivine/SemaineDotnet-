namespace BookStoreAPI.Models
{
    public class AuteurCreateRequestDto
    {
        public  string Name { get; init; } = default!; 
        public string? firstName { get; set; }
        public int  Age {get; set; }
    }
}