using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaggedNotes.Interfaces
{
	public interface IViewModel
	{
		INote SelectedNote { get; set; }
		
		ObservableCollection<ITag> Tags { get; set; }

		ObservableCollection<INote> Notes { get; set; }
	}
}
