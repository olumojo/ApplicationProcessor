using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Model;

namespace Ulaw.ApplicationProcessor.Interfaces
{
    public interface IDecisionResult
    {
        string Generate(DecisionDeterminant decisionDeterminant, ApplicationDetails applicationDetails);
    }
}
