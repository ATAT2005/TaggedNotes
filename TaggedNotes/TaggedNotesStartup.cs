using System;
using System.Collections.Generic;
using System.Text;

namespace TaggedNotes
{
    class TaggedNotesStartup
    {
        static TaggedNotesApp _app;

        [STAThread]
        static void Main(string[] args)
        {
            _app = new TaggedNotesApp();
            _app.Run();
        }
    }
}