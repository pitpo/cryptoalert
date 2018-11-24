using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.DTO.Coin;
using CryptoAlertCore.CryptoInformation.DTO.Coins;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public interface ICryptoInformationService
    {
        Task<IEnumerable<Coin>> GetListOfAllCoinsAsync();
        Task<Coin> GetCoinAsync(int coinId);
    }
}
