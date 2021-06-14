using System;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A cross thread writng class meant to store task objects in a data structure that is read from by a cross thread red object.
    /// </summary>
    public class CrossThreadWrite
    {
        /// <summary>
        /// A list of unprocesses task objects.
        /// </summary>
        public List<CrossThreadCommand> commands = new List<CrossThreadCommand>();

        /// <summary>
        /// Appends a new task object to the list of unprocessed task objects.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="payload"></param>
        public void AddCommand(string name, object[] payload)
        {
            commands.Add(new CrossThreadCommand(name, payload));
        }
    }
}