using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class ComputerController : Controller
    {
        private ComputerService _computerService;
        
        public ComputerController(){
            _computerService = new ComputerService();
        }
        
        [HttpGet]
        public List<Computer> Get()
        {
            return _computerService.Get(x => true).ToList();
        }
        
        [HttpGet("{id}")]
        public Computer Get(int id)
        {
            return _computerService.Get(x => x.Id == id).First();
        }
    }
    
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private ComputerService _computerService;
        
        public CommandController(){
            _computerService = new ComputerService();
        }
        
        [HttpGet("{id}")]
        public List<Command> Get(int id)
        {
            return _computerService.Get(x => x.Id == id).First().Commands.ToList();
        }
        
        [HttpPost("{id}")]
        public void Post(int id, Command command){
            
            System.Console.WriteLine(command.Executable);
            System.Console.WriteLine(command.Parameters);
            
            _computerService.AddCommand(id, command);
        }
    }
}
