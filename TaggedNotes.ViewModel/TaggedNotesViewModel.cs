using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaggedNotes.Interfaces;
using TaggedNotes.Model;

namespace TaggedNotes.ViewModel
{
	public class TaggedNotesViewModel : IViewModel
	{
		public INote SelectedNote { get; set; }

		public ObservableCollection<ITag> Tags { get; set; }
		
		public ObservableCollection<INote> Notes { get; set; }

		public TaggedNotesViewModel()
		{
			Tags = new ObservableCollection<ITag>();
			var tag1 = new Tag(1, "Tag 1", true);
			Tags.Add(tag1);
			var tag2 = new Tag(2, "Tag 222", false);
			Tags.Add(tag2);

			Notes = new ObservableCollection<INote>();
			var note1 = new Note(1, "Note 1", new ObservableCollection<ITag>(new Tag[] { tag1, tag2 }));
			Notes.Add(note1);
			var note2 = new Note(2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", new ObservableCollection<ITag>(new Tag[] { tag2 }));
			Notes.Add(note2);
		}

		public void AddTag(ITag tag)
		{
			Tags.Add(tag);
		}

		public void RemoveTag(ITag tag)
		{
			Tags.Remove(tag);
		}

		public void AddNote(INote note)
		{
			Notes.Add(note);
		}

		public void RemoveNote(INote note)
		{
			Notes.Remove(note);
		}
	}
}