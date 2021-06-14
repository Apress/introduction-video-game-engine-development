using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A task object meant to be passed across threads using a CrossThreadRead and CrossThreadWrite object.
    /// </summary>
    public class CrossThreadCommand
    {
        /// <summary>
        /// The name of the command used to run this task object. 
        /// </summary>
        public string name;

        /// <summary>
        /// The data used to process this task object.
        /// </summary>
        public object[] payload;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="Name">The name of the command to be used to run this task object.</param>
        /// <param name="Payload">The data used to process this task object.</param>
        public CrossThreadCommand(string Name, object[] Payload)
        {
            name = Name;
            payload = Payload;
        }
    }
}