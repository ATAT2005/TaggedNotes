using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace TaggedNotes.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TaggedNotesMainWindow : Window, IView
    {
        /// <summary>
        /// All tags to show
        /// </summary>
        public Tags CurrentTags { get; set; } = new Tags();

        /// <summary>
        /// All notes to show
        /// </summary>
        public Notes CurrentNotes { get; set; } = new Notes();

        public TaggedNotesMainWindow()
        {
            InitializeComponent();

            AddHandler(CheckBox.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(tag_PreviewMouseLeftButtonDownEvent));
        }

        /// <summary>
        /// Special workaround for stretching short textbox items of the listbox
        /// </summary>
        /// <see cref="https://social.msdn.microsoft.com/Forums/security/en-US/d066ea21-2723-4622-8276-698c745f4184/how-to-make-textbox-stretch-horizontally-to-fill-width-of-listbox?forum=silverlightnet"/>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement g = sender as FrameworkElement;
            g.Width = List.ActualWidth - 6;  // make the grid the same width as the listbox (- some border width)
        }
        
        /// <summary>
        /// Start dragging tag on note
        /// </summary>
        private void tag_PreviewMouseLeftButtonDownEvent(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement fe && fe.DataContext is ITag dc)
                DragDrop.DoDragDrop(fe, dc, DragDropEffects.Copy);
        }

        private void lblTarget_Drop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = e.Data.GetData(DataFormats.Text);
        }
    }
}