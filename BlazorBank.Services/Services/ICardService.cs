using BlazorBank.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBank.Services.Services
{
    public interface ICardService
    {
        Task<IEnumerable<CardInternal>> GetCards();
    }
}
