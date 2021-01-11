using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.View
{
    /// <summary>
    /// Note realization
    /// </summary>
    class Note : BaseObject, INote, INotifyPropertyChanged
    {
        #region INote contract
        public string Text { get; set; }

        public ObservableCollection<ITag> Tags { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Object identifier</param>
        /// <param name="name">Tag name</param>
        /// <param name="selected">Is tag checked</param>
        public Note(int id, string text, ObservableCollection<ITag> tags)
        {
            Id = id;
            Text = text;
            Tags = tags;
        }

        public override string ToString()
        {
            return Text;
        }

        #region INotifyPropertyChanged contract
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}