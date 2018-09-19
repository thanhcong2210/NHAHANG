using AutoMapper;
using NhaHangTC.Model.Models;
using NhaHangTC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHangTC.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            Mapper.Initialize(cfg =>
            {           
                cfg.CreateMap<LoaiMonAn, LoaiMonAnViewModel>();
                cfg.CreateMap<MonAn, MonAnViewModel>();

            });
        }
    }
}