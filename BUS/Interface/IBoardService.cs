using BUS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS.Interface
{
    public interface IBoardService
    {
        List<Board> GetAllBoard();
        List<Board> GetBoardByUser(int id);
        List<BoardDetail> GetBoardDetailByBoardId(int boardId);

    }
}
