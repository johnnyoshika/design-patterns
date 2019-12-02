using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State.States
{
    public class Active : State
    {
        public Active(WorkItem owner) : base(owner)
        {
        }

        public override bool CanDelete => false;

        public override void SetState(string state)
        {
            switch (state)
            {
                case "Proposed":
                    Owner.SetState(new Proposed(Owner));
                    break;
                case "Active":
                    // Already active, do nothing
                    break;
                case "Resolved":
                    Owner.SetState(new Resolved(Owner));
                    break;
                case "Closed":
                    throw new InvalidOperationException();
                default:
                    break;
            }
        }

        public override string ToString() => "Active";
    }
}
