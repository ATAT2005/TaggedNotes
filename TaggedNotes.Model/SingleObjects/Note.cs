using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.Model
{
	/// <summary>
	/// Note realization
	/// </summary>
	public class Note : BaseObject, INote
	{
		private string _text;

		private ObservableCollection<ITag> _tags;

		#region INote contract

		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				OnPropertyChanged("Text");
			}
		}

		public ObservableCollection<ITag> Tags
		{
			get => _tags;
			set
			{
				_tags = value;
				OnPropertyChanged("Tags");
			}
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Object identifier</param>
		/// <param name="name">Tag name</param>
		/// <param name="selected">Is tag checked</param>
		public Note(int id, string text, ObservableCollection<ITag> tags)
		{
			Id = id;
			Text = text;
			Tags = tags;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}