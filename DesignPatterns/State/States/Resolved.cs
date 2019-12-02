using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State.States
{
    public class Resolved : State
    {
        public Resolved(WorkItem owner) : base(owner)
        {
        }

        public override bool CanDelete => false;

        public override void Edit(string title, string desc) => throw new InvalidOperationException();

        public override void SetState(string state)
        {
            switch (state)
            {
                case "Proposed":
                    throw new InvalidOperationException();
                case "Active":
                    Owner.SetState(new Active(Owner));
                    break;
                case "Resolved":
                    // Already resolved, do nothing
                    break;
                case "Closed":
                    Owner.SetState(new Closed(Owner));
                    break;
                default:
                    break;
            }
        }

        public override string ToString() => "Resolved";
    }
}
