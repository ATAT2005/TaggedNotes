using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.View
{
    /// <summary>
    /// Tag realization
    /// </summary>
    class Tag : BaseObject, ITag, INotifyPropertyChanged
    {
        #region ITag contract
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Object identifier</param>
        /// <param name="name">Tag name</param>
        /// <param name="selected">Is tag checked</param>
        public Tag(int id, string name, bool selected)
        {
            Id = id;
            Name = name;
            IsSelected = selected;
        }

        public override string ToString()
        {
            //return $"{(IsSelected ? "☑" : "☐") } {Name} [{Id}]";
            return Name;
        }

        #region INotifyPropertyChanged contract
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}