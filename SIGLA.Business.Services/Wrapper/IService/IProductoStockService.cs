﻿using SIGLA.Business.Dto;
using SIGLA.Business.Dto.ProductoStocksss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IProductoStockService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoStockCreacionDto dto);

    }
}
