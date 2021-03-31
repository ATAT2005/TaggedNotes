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

		#endregion

		/// <summary>
		/// Empty constructor (for EntityFramework, etc)
		/// </summary>
		public Note() { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Object identifier</param>
		/// <param name="name">Tag name</param>
		/// <param name="selected">Is tag checked</param>
		public Note(int id, string text)
		{
			Id = id;
			Text = text;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}