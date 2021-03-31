using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.Model
{
	/// <summary>
	/// Tag realization
	/// </summary>
	public class Tag : BaseObject, ITag
	{
		private string _name;

		private bool _selected;

		#region ITag contract

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		public bool Selected
		{
			get => _selected;
			set
			{
				_selected = value;
				OnPropertyChanged("Selected");
			}
		}

		#endregion

		/// <summary>
		/// Empty constructor (for EntityFramework, etc)
		/// </summary>
		public Tag() { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Object identifier</param>
		/// <param name="name">Tag name</param>
		/// <param name="selected">Is tag checked</param>
		public Tag(int id, string name, bool selected)
		{
			Id = id;
			Name = name;
			Selected = selected;
		}

		public override string ToString()
		{
			//return $"{(IsSelected ? "☑" : "☐") } {Name} [{Id}]";
			return Name;
		}
	}
}