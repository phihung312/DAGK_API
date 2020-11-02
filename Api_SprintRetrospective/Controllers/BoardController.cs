using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BUS.Models;
using System.Collections;

namespace SprintRetrospectiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
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
    }
}