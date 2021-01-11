using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.View
{
    public class Notes : ObservableCollection<INote>
    {
        public Notes()
        {
            this.Add(new Note(1, "Note 1", null));
            this.Add(new Note(2, "Note 222", null));
        }
    }
}