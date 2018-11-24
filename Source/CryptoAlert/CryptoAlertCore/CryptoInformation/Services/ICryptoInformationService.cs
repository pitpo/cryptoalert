using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public interface ICryptoInformationService
    {
        Task<AllCryptoCurrenciesRootObject> GetListOfAllCryptoAsync();
    }
}
