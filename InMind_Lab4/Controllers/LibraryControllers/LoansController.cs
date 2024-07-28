using InMind_Lab4.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace InMind_Lab4.Controllers;

[ApiController]
[Route("[controller]")]
public class LoansController:ODataController
{
    private readonly LibraryDbContext _dbContext;
    public LoansController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_dbContext.Loans);
    }
}