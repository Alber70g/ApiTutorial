using System;
using System.Collections.Generic;

public class ComputerService
{
	private ComputerRepository _computerRepository;
	
	public ComputerService(){
		_computerRepository = new ComputerRepository();
	}
	
	public IEnumerable<Computer> Get(Func<Computer, bool> predicate)
	{
		return _computerRepository.Get(predicate);
	}
	
	public void AddCommand(int id, Command command){
		_computerRepository.AddCommand(id, command);
	}
}