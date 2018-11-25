using CryptoAlertCore.CoinsInformation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.CoinsInformation.Factories
{
    interface ICoinInformationServiceFactory
    {
        ICoinsInformationService Create();
    }
}
