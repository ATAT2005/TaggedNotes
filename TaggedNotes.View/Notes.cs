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
            this.Add(new Note(2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", null));
        }
    }
}