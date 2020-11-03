using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BUS.Models;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Api_SprintRetrospective.Controllers;

namespace SprintRetrospectiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : BaseController
    {
        private readonly IBoardService _IBoardService;
        public BoardController(IBoardService boardService)
        {
            _IBoardService = boardService;
        }
     
        [HttpGet("[action]")]
        public List<Board> GetAllBoard()
        {
            var result = _IBoardService.GetAllBoard();
            return result;
        }

        [HttpGet("[action]")]
        [Authorize]
        public List<Board> GetBoardForUser()
        {
            var result = _IBoardService.GetBoardByUser(_User.Id);
            return result;
        }

        [HttpGet("[action]")]

        public List<BoardDetail> GetBoardDetail(int id)
        {
            var result = _IBoardService.GetBoardDetailByBoardId(id);
            return result;
        }
    }
}