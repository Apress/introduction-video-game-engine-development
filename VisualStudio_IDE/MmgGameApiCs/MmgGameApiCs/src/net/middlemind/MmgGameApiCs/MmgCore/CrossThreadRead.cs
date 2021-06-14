using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A cross thread read object that pulls cross thread commands from a data structure one at a time for processing.
    /// </summary>
    public class CrossThreadRead
    {
        /// <summary>
        /// The data structure used to store unprocessed task objects.
        /// </summary>
        public CrossThreadWrite commandList;

        /// <summary>
        /// A constructor that sets the data source a cross thread write object.
        /// </summary>
        /// <param name="ctw"></param>
        public CrossThreadRead(CrossThreadWrite ctw)
        {
            commandList = ctw;
        }

        /// <summary>
        /// Returns the next task object from the store of unprocessed task objects.
        /// </summary>
        /// <returns>The next task object from the store of unprocessed task objects.</returns>
        public CrossThreadCommand GetNextCommand()
        {
            CrossThreadCommand ret = null;
            if (commandList != null && commandList.commands.Count > 0)
            {
                //int len = commandList.commands.Count;
                ret = commandList.commands[0];
                commandList.commands.RemoveAt(0);
            }

            return ret;
        }

        /// <summary>
        /// Returns true if the list of task objects to process if empty.
        /// </summary>
        /// <returns>A boolean indicating if the list of task objects is empty.</returns>
        public bool IsEmpty()
        {
            if(commandList == null || commandList.commands == null || commandList.commands.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}