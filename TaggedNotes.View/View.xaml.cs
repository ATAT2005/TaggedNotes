using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TaggedNotes.Interfaces;
using TaggedNotes.ViewModel;
using TaggedNotes.Model;

namespace TaggedNotes.View
{
	/// <summary>
	/// Interaction logic for TaggedNotesMainWindow.xaml
	/// </summary>
	public partial class TaggedNotesMainWindow : Window
	{
		/// <summary>
		/// Shortcut for ViewModel
		/// </summary>
		private ViewModel.ViewModel VM { get => DataContext as ViewModel.ViewModel; }

		/// <summary>
		/// Notes source view
		/// </summary>
		private CollectionViewSource _viewSourceNotes;

		/// <summary>
		/// Tags source view
		/// </summary>
		private CollectionViewSource _viewSourceTags;

		public TaggedNotesMainWindow()
		{
			InitializeComponent();

			AddHandler(CheckBox.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(tag_PreviewMouseLeftButtonDownEvent));
			//AddHandler(ListBox.SelectionChangedEvent, new RoutedEventHandler(List_SelectionChanged));

			DataContext = new ViewModel.ViewModel();
		}

		/// <summary>
		/// Initializing collection views for notes and tags
		/// </summary>
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			if (DataGridNotes.Items.Count > 0)
				DataGridNotes.SelectedItem = DataGridNotes.Items[0];

			_viewSourceNotes = new CollectionViewSource() { Source = VM.Notes };
			_viewSourceNotes.Filter += new FilterEventHandler(FilterNotes);
			ICollectionView notesList = _viewSourceNotes.View;
			DataGridNotes.ItemsSource = notesList;

			_viewSourceTags = new CollectionViewSource() { Source = VM.Tags };
			_viewSourceTags.Filter += new FilterEventHandler(FilterTags);
			ICollectionView tagsList = _viewSourceTags.View;
			DataGridTags.ItemsSource = tagsList;

			//FrameworkElement g = sender as FrameworkElement;
			//g.Width = ListNotes.ActualWidth - 6;  // make the grid the same width as the listbox (- some border width)
		}

		/// <summary>
		/// Filters notes by text note filter and checked tags
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Args</param>
		private void FilterNotes(object sender, FilterEventArgs e)
		{
			var note = e.Item as Note;

			var textFilterAccepted = true;
			var tagFilterAccepted = true;

			if (note != null)
			{
				if (!string.IsNullOrWhiteSpace(NoteFilter.Text))
					textFilterAccepted = note.Text.Contains(NoteFilter.Text, StringComparison.OrdinalIgnoreCase);

				var checkedTags = GetCheckedTags();

				if (checkedTags?.Count > 0)
					tagFilterAccepted = note.TagNoteLinks.Any(x => checkedTags.Contains(x.IdTag));
			}

			e.Accepted = textFilterAccepted && tagFilterAccepted;
		}

		/// <summary>
		/// Filters tags by text tag filter
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Args</param>
		private void FilterTags(object sender, FilterEventArgs e)
		{
			var tag = e.Item as Tag;

			if (tag != null && !string.IsNullOrWhiteSpace(TagFilter.Text))
				e.Accepted = tag.Name.Contains(TagFilter.Text, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// If text filter for notes was changed, notes would be filtered
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Args</param>
		private void noteFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			_viewSourceNotes?.View?.Refresh();
		}

		/// <summary>
		/// If text filter for tags was changed, tags would be filtered
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Args</param>
		private void tagFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			_viewSourceTags?.View?.Refresh();
		}

		/// <summary>
		/// ToDo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void List_SelectionChanged(object sender, RoutedEventArgs args)
		{
			//var viewmodel = DataContext as ViewModel.ViewModel;

			//if (viewmodel == null)
			//	return;

			//var tags = viewmodel.SelectedNote.TagNoteLinks;

			//int i = 0;
		}

		/// <summary>
		/// Start dragging a tag on a note
		/// </summary>
		private void tag_PreviewMouseLeftButtonDownEvent(object sender, RoutedEventArgs e)
		{
			//todo
			if (e.OriginalSource is FrameworkElement fe && fe.DataContext is ITag dc)
				DragDrop.DoDragDrop(fe, dc, DragDropEffects.Copy);
		}

		/// <summary>
		/// If tag was selected/unselected, notes would be filtered
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Args</param>
		private void OnChecked(object sender, RoutedEventArgs e)
		{
			_viewSourceNotes?.View?.Refresh();
		}

		/// <summary>
		/// Returns list of checked tag ids
		/// </summary>
		/// <returns>List of checked tag ids</returns>
		private List<int> GetCheckedTags()
		{
			var result = new List<int>();

			foreach (var item in DataGridTags.Items)
				if (item is Tag tag && tag.Selected)
					result.Add(tag.Id);

			return result;
		}

		/// <summary>
		/// Dropping a tag on a note to make a link with it
		/// </summary>
		private void note_Drop(object sender, DragEventArgs e)
		{
			//todo
		}
	}
}