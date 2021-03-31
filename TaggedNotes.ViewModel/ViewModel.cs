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
	public class ViewModel
	{
		public INote SelectedNote { get; set; }

		public ObservableCollection<ITag> Tags { get; set; }
		
		public ObservableCollection<INote> Notes { get; set; }

		public ViewModel()
		{
			Tags = new ObservableCollection<ITag>();

			Notes = new ObservableCollection<INote>();

			using (var context = new ModelContext())
			{
				foreach (var note in context.Notes)
					Notes.Add(note);

				foreach (var tag in context.Tags)
					Tags.Add(tag);
			}
		}

		/*public void AddTag(ITag tag)
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
		}*/
	}
}