using BUS.Interface;
using BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS.Services
{
    public class BoardServices:IBoardService
    {
        public List<Board> GetAllBoard()
        {
            try
            {
                var result = new List<Board>();
                using (var db = new SprintRetrospectiveContext())
                {
                    result = db.Board.ToList();
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
