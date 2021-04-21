using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotes.Model
{
	/// <summary>
	/// Link between note ang tag (so the tags can be bound to the notes)
	/// </summary>
	public class TagNoteLink
	{
		public int IdTag { get; set; }

		public Tag Tag { get; set; }

		public int IdNote{ get; set; }

		public Note Note { get; set; }

		/// <summary>
		/// Empty constructor (for EntityFramework, etc)
		/// </summary>
		public TagNoteLink() { }

		public TagNoteLink(Note note, Tag tag)
		{
			Note = note;
			Tag = tag;
			IdTag = tag.Id;
			IdNote = note.Id;
		}

		public override string ToString()
		{
			return Tag?.Name;
		}
	}
}