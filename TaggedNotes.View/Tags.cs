﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.View
{
    /// <summary>
    /// Tag collection
    /// </summary>
    public class Tags : ObservableCollection<ITag>
    {
        public Tags()
        {
           
        }
    }
}