﻿using Alligator.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer
{
    public interface IClientService
    {
        List<ClientModel> GetAllClients();
    }
}