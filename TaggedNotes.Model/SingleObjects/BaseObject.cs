﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

using TaggedNotes.Interfaces;

namespace TaggedNotes.Model
{
	/// <summary>
	/// Base object realization
	/// </summary>
	public abstract class BaseObject : IBaseObject, INotifyPropertyChanged
	{
		#region Private members

		private int _id;

		private ObservableCollection<TagNoteLink> _tagNoteLinks;

		#endregion

		#region IBaseObject contract

		public int Id
		{
			get => _id;
			set
			{
				_id = value;
				OnPropertyChanged("Id");
			}
		}
		
		#endregion

		#region INotifyPropertyChanged contract

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		/// <summary>
		/// Links between tags and notes
		/// </summary>
		public ObservableCollection<TagNoteLink> TagNoteLinks
		{
			get => _tagNoteLinks;
			set
			{
				_tagNoteLinks = value;

				OnPropertyChanged("TagNoteLinks");
			}
		}

		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}