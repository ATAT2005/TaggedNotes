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
        }

        /// <summary>
        /// Special workaround for stretching short textbox items of the listbox
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Routed event arguments</param>
        /// <see cref="https://social.msdn.microsoft.com/Forums/security/en-US/d066ea21-2723-4622-8276-698c745f4184/how-to-make-textbox-stretch-horizontally-to-fill-width-of-listbox?forum=silverlightnet"/>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement g = sender as FrameworkElement;
            g.Width = List.ActualWidth - 6;  // make the grid the same width as the listbox (- some border width)
        }
    }
}