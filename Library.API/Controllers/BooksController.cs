using Library.Application.Commands.CreateBook;
using Library.Application.Commands.CreateLoan;
using Library.Application.Commands.CreateUser;
using Library.Application.Commands.LoanDevolver;
using Library.Application.Queries;
using Library.Application.Queries.GetBookById;
using Library.Application.Queries.GetLoanByIdUser;
using Library.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookViewModel>> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            if (book == null) return BadRequest("Não encontrado");

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand createBook)
        {
            var id = await _mediator.Send(createBook);

            return CreatedAtAction(nameof(GetById), new { Id = id }, createBook);
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> PostUser([FromBody] CreateUserCommand createUser)
        {
            var user = await _mediator.Send(createUser);

            return Ok(user);
        }

        [HttpGet("loan/{id}")]
        public async Task<ActionResult<LoanViewModel>> GetByIdLoan(int id)
        {
            var loan = await _mediator.Send(new GetLoanByIdQuery(id));

            return loan;
        }

        [HttpPost("createLoan")]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand createLoan)
        {
            var id = await _mediator.Send(createLoan);

            return Ok(id);
        }
        
        [HttpPut("loans/devolver/{id}")]
        public async Task<IActionResult> DevolverBook(int id)
        {
            var mensagem = await _mediator.Send(new LoanDevolverCommand(id));

            return Ok(mensagem);
        }
    }
}