using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State
{
    public class WorkItem
    {
        public WorkItem(IRepository repository, int id)
        {
            Repository = repository;
            Id = id;
            State = new States.Proposed(this);
        }

        IRepository Repository { get; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public States.State State { get; private set; }

        public void Delete()
        {
            bool canDelete = State.CanDelete;
            if (canDelete)
                Repository.Delete(Id);
        }

        public void Edit(string title, string desc) => State.Edit(title, desc);

        public string Print() => $"{Id} {Title} {State}";

        public void SetState(string state) => State.SetState(state);

        internal void SetState(States.State state) => State = state;
    }
}
