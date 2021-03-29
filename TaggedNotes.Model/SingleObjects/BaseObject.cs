using System;
using System.Collections.Generic;
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
		private int _id;

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

		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}