using System.Collections.Generic;

using NUnit.Framework;

using TaggedNotes.Model;

namespace TaggedNotes.Model.Tests
{
	public class ModelTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestTag()
		{
			var tag = new Tag(1, "test", true);

			Assert.AreEqual(tag.Id, 1);
			Assert.AreEqual(tag.Name, "test");
			Assert.IsTrue(tag.Selected);
			Assert.AreEqual(tag.ToString(), "test");
		}

		[Test]
		public void TestNote()
		{
			var tag = new Tag(1, "test", true);

			var note = new Note(1, "noteText");//, new System.Collections.ObjectModel.ObservableCollection<Tag>(new Tag[] { tag }));

			Assert.AreEqual(note.Id, 1);
			Assert.AreEqual(note.Text, "noteText");
			Assert.AreEqual(note.TagNoteLinks, new List<Interfaces.ITag>(new[] { tag }));
			Assert.AreEqual(note.ToString(), "noteText");
		}
	}
}