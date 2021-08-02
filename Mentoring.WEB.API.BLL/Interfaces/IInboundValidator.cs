﻿using Mentoring.WEB.API.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IInboundValidator
    {
        Task<bool> ValidateUserApplication(UserApplicationModel userApplication);
    }
}
