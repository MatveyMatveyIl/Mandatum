using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.ApiInterface;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BoardFormat = Mandatum.Models.BoardFormat;

namespace Mandatum.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private IBoardApi _boardApi;
        private TaskModelConverter _taskConverter;
        private BoardModelConverter _boardConverter;
        private IUserApi _userApi;

        public BoardController(ITaskApi taskApi, IBoardApi boardApi, IUserApi userApi, TaskModelConverter taskConverter, 
            BoardModelConverter boardConverter)
        {
            _taskConverter = taskConverter;
            _boardApi = boardApi;
            _boardConverter = boardConverter;
            _userApi = userApi;
        }

        public IActionResult AllBoards()
        {
            return View(_boardConverter.Convert(_userApi.GetBoards(User.Identity.Name)));
        }

        public IActionResult OpenBoard(Guid boardId)
        {
            var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            return View("BoardView", boardView);
        }

        public IActionResult CreateBoard()
        {
            return View("CreateBoard", new BoardModel());
        }
        
        public IActionResult SaveBoard(BoardModel board)
        {
            if (ModelState.IsValid)
            {
                board.Id = Guid.NewGuid();
                _boardApi.CreateBoard(_boardConverter.Convert(board), User.Identity.Name);
                var boardView = new BoardViewModel(board, GetTasks(board.Id));
                return View("BoardView", boardView);
            }
            return View("CreateBoard");
        }
        public IActionResult DeleteBoard(Guid boardId)
        {
            _boardApi.DeleteBoard(boardId);
            var boards = _boardConverter.Convert(_userApi.GetBoards(User.Identity.Name));
            return View("AllBoards", boards);
        }
        
        
        private IEnumerable<TaskModel> GetTasks(Guid boardId)
        {
            return _taskConverter.Convert(_boardApi.GetBoardTasks(boardId));
        }
    }
}