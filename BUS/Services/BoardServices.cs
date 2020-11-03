using BUS.Interface;
using BUS.Models;
using Microsoft.EntityFrameworkCore;
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
        public List<Board> GetBoardByUser(int id)
        {
            try
            {
                var result = new List<Board>();
                using (var db = new SprintRetrospectiveContext())
                {
                    result = db.Board.Where(x=>x.Id == id).ToList();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<BoardDetail> GetBoardDetailByBoardId(int boardId)
        {
            try
            {
                var result = new List<BoardDetail>();
                using (var db = new SprintRetrospectiveContext())
                {
                    result = db.BoardDetail.Where(x => x.BoardId == boardId).ToList();
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
