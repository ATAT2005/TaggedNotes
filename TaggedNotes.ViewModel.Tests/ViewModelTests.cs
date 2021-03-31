using NUnit.Framework;

using TaggedNotes.Model;
using TaggedNotes.ViewModel;

namespace TaggedNotes.ViewModel.Tests
{
	public class ViewModelTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestViewModel()
		{
			var vm = new ViewModel();
			Assert.IsNotNull(vm);
			vm.Tags.Clear();
			vm.Notes.Clear();

			var selectedNode = vm.SelectedNote;
			Assert.IsNull(selectedNode);

			var tag = new Tag(1, "test", false);

			/*vm.AddTag(tag);
			Assert.AreEqual(vm.Tags.Count, 1);
			
			vm.RemoveTag(tag);
			Assert.AreEqual(vm.Tags.Count, 0);

			var note = new Note(1, "text", new System.Collections.ObjectModel.ObservableCollection<Interfaces.ITag>(new Tag[] { tag }));
			vm.AddNote(note);
			Assert.AreEqual(vm.Notes.Count, 1);

			vm.RemoveNote(note);
			Assert.AreEqual(vm.Tags.Count, 0);*/
		}
	}
}