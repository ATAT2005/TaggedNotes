using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaggedNotes.Interfaces
{
    /// <summary>
    /// Note interface
    /// </summary>
    public interface INote : IBaseObject
    {
        /// <summary>
        /// Note text
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Tags linked to note
        /// </summary>
        ObservableCollection<ITag> Tags { get; set; }
    }
}