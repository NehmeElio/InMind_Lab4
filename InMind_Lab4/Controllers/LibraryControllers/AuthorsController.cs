using InMind_Lab4.Context;
using InMind_Lab4.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController:ODataController
{
    private readonly LibraryDbContext _dbContext;
    public AuthorsController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    [EnableQuery]
    public ActionResult<IEnumerable<Author>> Get()
    {
        return Ok(_dbContext.Authors);
    }
    
    

   
}