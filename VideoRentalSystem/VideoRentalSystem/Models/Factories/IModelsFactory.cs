﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRentalSystem.Models.Contracts;

namespace VideoRentalSystem.Models.Factories
{
    public interface IModelsFactory
    {
        ICountry CreateCountry(string name, string code);
    }
}
