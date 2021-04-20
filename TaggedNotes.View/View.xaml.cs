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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class TaggedNotesMainWindow : Window
	{
		private ViewModel.ViewModel VM { get => DataContext as ViewModel.ViewModel; }

		CollectionViewSource _viewSourceNotes;

		CollectionViewSource _viewSourceTags;

		public TaggedNotesMainWindow()
		{
			InitializeComponent();

			AddHandler(CheckBox.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(tag_PreviewMouseLeftButtonDownEvent));
			//AddHandler(ListBox.SelectionChangedEvent, new RoutedEventHandler(List_SelectionChanged));

			DataContext = new ViewModel.ViewModel();
		}

		/// <summary>
		/// Special workaround for stretching short textbox items of the listbox
		/// </summary>
		/// <see cref="https://social.msdn.microsoft.com/Forums/security/en-US/d066ea21-2723-4622-8276-698c745f4184/how-to-make-textbox-stretch-horizontally-to-fill-width-of-listbox?forum=silverlightnet"/>
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

		private void FilterNotes(object sender, FilterEventArgs e)
		{
			var note = e.Item as Note;

			if (note != null && !string.IsNullOrWhiteSpace(NoteFilter.Text))
				e.Accepted = note.Text.Contains(NoteFilter.Text, StringComparison.OrdinalIgnoreCase);
		}

		private void FilterTags(object sender, FilterEventArgs e)
		{
			var tag = e.Item as Tag;

			if (tag != null && !string.IsNullOrWhiteSpace(TagFilter.Text))
				e.Accepted = tag.Name.Contains(TagFilter.Text, StringComparison.OrdinalIgnoreCase);
		}

		private void noteFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			_viewSourceNotes.View.Refresh();
		}

		private void tagFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			_viewSourceTags.View.Refresh();
		}

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
			if (e.OriginalSource is FrameworkElement fe && fe.DataContext is ITag dc)
				DragDrop.DoDragDrop(fe, dc, DragDropEffects.Copy);
		}

		/// <summary>
		/// Dropping a tag on a note to make a link with it
		/// </summary>
		private void note_Drop(object sender, DragEventArgs e)
		{

		}
	}
}