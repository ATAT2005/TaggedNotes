using System;
using System.Collections.Generic;
using System.Text;

namespace TaggedNotes.Interfaces
{
    /// <summary>
    /// Tag interface
    /// </summary>
    public interface ITag : IBaseObject
    {

        /// <summary>
        /// Tag name
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Is tag checked
        /// </summary>
        bool IsSelected { get; set; }
    }
}