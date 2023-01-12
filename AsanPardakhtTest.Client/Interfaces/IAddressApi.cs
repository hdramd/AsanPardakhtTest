using AsanPardakhtTest.Client.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsanPardakhtTest.Client.Interfaces
{
    public interface IAddressApi
    {

        [Get("/Address/GetByProviance")]
        Task<ApiResponse<Result<List<AddressDto>>>> 
            GetByProvianceAsync([Query] GetAddressesByProvianceQuery pagingOptions);
    }
}
