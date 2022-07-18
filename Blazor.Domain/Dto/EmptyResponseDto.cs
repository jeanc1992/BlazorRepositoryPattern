namespace Blazor.Domain.Dto
{ 
    public class EmptyResponseDto
    {
        public bool Succeed { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageId { get; set; }

        public EmptyResponseDto()
        {
        }

        public EmptyResponseDto(bool succeed) => Succeed = succeed;

        public EmptyResponseDto(string errorMessage, string errorMessageId)
        {
            ErrorMessage = errorMessage;
            ErrorMessageId = errorMessageId;
        }
    }
}
