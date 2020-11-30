using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartApi.Domain.Services
{
    public interface ISmartService
    {
        void BlokInsert(BLOK blok);
        void BlokDelete(BLOK blok);
        void BlokUpdate(BLOK blok);
        IEnumerable<BLOK> BlokSelect();
    }
}