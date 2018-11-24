using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.DTO.Coins;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public interface ICryptoInformationService
    {
        Task<AllCryptoCurrenciesRootObject> GetListOfAllCryptoAsync();
    }
}
