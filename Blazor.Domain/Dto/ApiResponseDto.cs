using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Domain.Dto
{
    public class ApiResponseDto<T> : EmptyResponseDto
    {
        public T Result { get; set; }

        public ApiResponseDto()
        {

        }

        public ApiResponseDto(T result)
        {
            Succeed = true;
            Result = result;
        }

        public ApiResponseDto(string errorMsg, string errorCode)
        {
            ErrorMessage = errorMsg;
            ErrorMessageId = errorCode;
        }
    }
}
