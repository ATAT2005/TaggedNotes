using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using TaggedNotes.Interfaces;
using TaggedNotes.View;

namespace TaggedNotes
{
    class TaggedNotesApp : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            TaggedNotesMainWindow window = new TaggedNotesMainWindow();
            this.MainWindow = window;
            window.Show();
        }
    }
}