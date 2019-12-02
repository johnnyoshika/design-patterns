using DesignPatterns.State;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.State
{
    public class WorkItem_Should
    {
        [Fact]
        public void Switch_State_From_Proposed_To_Active()
        {
            var repository = new Mock<IRepository>();
            var item = new WorkItem(repository.Object, 1);
            item.SetState("Active");

            Assert.Equal("Active", item.State.ToString());
        }

        [Fact]
        public void Allow_Deleting_Proposed()
        {
            var repository = new Mock<IRepository>();
            var item = new WorkItem(repository.Object, 1);
            item.Delete();

            repository.Verify(r => r.Delete(1), Times.Once());
        }

        [Fact]
        public void Prevent_Deleting_Active()
        {
            var repository = new Mock<IRepository>();
            var item = new WorkItem(repository.Object, 1);
            item.SetState("Active");
            item.Delete();

            repository.Verify(r => r.Delete(1), Times.Never());
        }

        [Fact]
        public void Throw_When_Changing_State_From_Proposed_Resolved()
        {
            var repository = new Mock<IRepository>();
            var item = new WorkItem(repository.Object, 1);
            Assert.Throws<InvalidOperationException>(() => item.SetState("Resolved"));
        }
    }
}
