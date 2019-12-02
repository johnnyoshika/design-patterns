using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State.States
{
    public class Closed : State
    {
        public Closed(WorkItem owner) : base(owner)
        {
        }

        public override bool CanDelete => true;

        public override void Edit(string title, string desc) => throw new InvalidOperationException();

        public override void SetState(string state)
        {
            switch (state)
            {
                case "Proposed":
                    throw new InvalidOperationException();
                case "Active":
                    throw new InvalidOperationException();
                case "Resolved":
                    Owner.SetState(new Resolved(Owner));
                    break;
                case "Closed":
                    // Do nothing, already closed
                default:
                    break;
            }
        }

        public override string ToString() => "Closed";
    }
}
