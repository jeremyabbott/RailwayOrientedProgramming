using System.Collections.Generic;

namespace RailwayOrientedProgramming
{
    public class CommandResult<T>
    {
        public T Entity { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public bool Successful => Messages.Count == 0;
    }
}