using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Domain.Dto
{
    public class ApiListResponseDto<T>: ApiResponseDto<List<T>>
    {
        public ApiListResponseDto()
        {
            Succeed = true;
            Result = new List<T>();
        }

        public ApiListResponseDto(List<T> results) : base(results)
        {
        }
    }
}
