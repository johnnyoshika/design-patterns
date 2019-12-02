using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State.States
{
    public abstract class State
    {
        public State(WorkItem owner)
        {
            Owner = owner;
        }

        protected WorkItem Owner { get; }

        public abstract bool CanDelete { get; }

        public virtual void Edit(string title, string desc)
        {
            Owner.Title = title;
            Owner.Description = desc;
        }

        public abstract void SetState(string state);
    }
}
