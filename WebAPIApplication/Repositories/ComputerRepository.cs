using System.Linq;
using System;
using System.Collections.Generic;

public class ComputerRepository
{
	private List<Computer> _computers;
	public ComputerRepository ()
	{
		_computers = new List<Computer>();
		_computers.Add(new Computer(){
			Id = 1,
			Guid = Guid.NewGuid(),
			ComputerName = "Bram",
			Commands = new List<Command>(){
				new Command {
                    Executable = "cmd.exe",
                    Parameters = "notepad.exe"
                }
			}
		});
		
		_computers.Add(new Computer(){
			Id = 2,
			Guid = Guid.NewGuid(),
			ComputerName = "Albert",
			Commands = new List<Command>() {
				new Command {
                    Executable = "cmd.exe",
                    Parameters = "ping www.google.com"
                }
			}
		});
	}

    internal void AddCommand(int id, Command command)
    {
        _computers.First(x => x.Id == id).Commands.Add(command);
    }

    public Computer GetOne(Func<Computer, bool> predicate)
	{
		return _computers.Single(predicate);
	}
	
	public IEnumerable<Computer> Get(Func<Computer, bool> predicate)
	{
		return _computers.Where(predicate);
	}
	
	public bool AddComputer(Computer computer){
		if(!_computers.Exists(x => x.Guid == computer.Guid)){
			_computers.Add(computer);
			return true;
		} else {
			return false;
		}
	}
}