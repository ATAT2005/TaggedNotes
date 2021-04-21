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

			var selectedTag = vm.SelectedTag;
			Assert.IsNull(selectedTag);

			vm.AddNote.Execute(null);
			var note = vm.Notes[0];
			vm.RemoveNote.Execute(note);

			vm.AddTag.Execute(null);
			var tag = vm.Tags[0];
			vm.RemoveTag.Execute(tag);
		}
	}
}