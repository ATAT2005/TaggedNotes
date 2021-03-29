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
            
        }
    }
}