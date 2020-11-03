using BUS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS.Interface
{
    public interface IColumnService
    {
        List<Column> GetAllColumn();
    }
}
