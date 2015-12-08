using System.Collections.Generic;

public class Computer
{
    public int Id { get; set; }
    public System.Guid Guid { get; set; }
    public string ComputerName { get; set; }
    public List<Command> Commands { get; set; }
}

public class Command {
    public string Executable { get; set; }
    public string Parameters { get; set; }
}