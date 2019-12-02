using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State.States
{
    public class Proposed : State
    {
        public Proposed(WorkItem owner) : base(owner)
        {
        }

        public override bool CanDelete => true;

        public override void SetState(string state)
        {
            switch (state)
            {
                case "Proposed":
                    // Already proposed, do nothing
                    break;
                case "Active":
                    Owner.SetState(new Active(Owner));
                    break;
                case "Resolved":
                    throw new InvalidOperationException();
                case "Closed":
                    throw new InvalidOperationException();
                default:
                    break;
            }
        }

        public override string ToString() => "Proposed";
    }
}