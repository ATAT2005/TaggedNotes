using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TaggedNotes.Interfaces;
using TaggedNotes.Model;

namespace TaggedNotes.ViewModel
{
	public class ViewModel
	{
		private ModelContext _context = null;

		public Note SelectedNote { get; set; }

		public Tag SelectedTag { get; set; }

		public ObservableCollection<Tag> Tags { get; set; }

		public ObservableCollection<Note> Notes { get; set; }

		private RelayCommand addNote;
		/// <summary>
		/// Command for adding notes to collection
		/// </summary>
		public RelayCommand AddNote
		{
			get
			{
				return addNote ??= new RelayCommand(() =>
				  {
					  var note = new Note(Notes.Max(x => x.Id) + 1, "New Note");
					  Notes.Add(note);
					  SelectedNote = note;
				  });
			}
		}

		private RelayCommand removeNote;
		/// <summary>
		/// Command for removing notes from collection
		/// </summary>
		public RelayCommand RemoveNote
		{
			get
			{
				return removeNote ??= new RelayCommand(() =>
				{
					Notes.Remove(SelectedNote);
				});
			}
		}

		private RelayCommand addTag;
		/// <summary>
		/// Command for adding tags to collection
		/// </summary>
		public RelayCommand AddTag
		{
			get
			{
				return addTag ??= new RelayCommand(() =>
				{
					var tag = new Tag(Tags.Max(x => x.Id) + 1, "New Tag", false);
					Tags.Add(tag);
				});
			}
		}

		private RelayCommand removeTag;
		/// <summary>
		/// Command for removing tags from collection
		/// </summary>
		public RelayCommand RemoveTag
		{
			get
			{

				return removeTag ??= new RelayCommand(() =>
				{
					Tags.Remove(SelectedTag);
				});
			}
		}

		private RelayCommand saveChanges;
		/// <summary>
		/// Command for saving changes to database
		/// </summary>
		public RelayCommand SaveChanges
		{
			get
			{
				return saveChanges ??= new RelayCommand(() =>
				{
					foreach (var note in _context.Notes)
						if (!Notes.Contains(note))
							_context.Notes.Remove(note);

					foreach (var tag in _context.Tags)
						if (!Tags.Contains(tag))
							_context.Tags.Remove(tag);

					foreach (var note in Notes)
						if (!_context.Notes.Contains(note))
							_context.Notes.Add(note);

					foreach (var tag in Tags)
						if (!_context.Tags.Contains(tag))
							_context.Tags.Add(tag);

					_context.SaveChanges();
				});
			}
		}

		public ViewModel()
		{
			Tags = new ObservableCollection<Tag>();

			Notes = new ObservableCollection<Note>();

			_context = new ModelContext();

			foreach (var note in _context.Notes.Include(x => x.TagNoteLinks))
				Notes.Add(note);

			foreach (var tag in _context.Tags)
				Tags.Add(tag);
		}
	}
}