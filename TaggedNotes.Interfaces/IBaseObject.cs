using System;
using System.Collections.Generic;
using System.Text;

namespace TaggedNotes.Interfaces
{
    /// <summary>
    /// Base interface for all objects
    /// </summary>
    public interface IBaseObject
    {
        /// <summary>
        /// Object identifier
        /// </summary>
        int Id { get; set; }
    }
}