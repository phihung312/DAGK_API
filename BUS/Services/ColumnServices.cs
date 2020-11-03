using BUS.Interface;
using BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS.Services
{
    public class ColumnServices: IColumnService
    {
        public List<Column> GetAllColumn()
        {
            try
            {
                var result = new List<Column>();
                using (var db = new SprintRetrospectiveContext())
                {
                    result = db.Column.ToList();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
