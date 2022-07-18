namespace Blazor.Domain.Dto.Clients.Response
{
    public class ClientResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
