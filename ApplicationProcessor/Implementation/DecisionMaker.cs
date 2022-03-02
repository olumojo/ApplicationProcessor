using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using Ulaw.ApplicationProcessor.Model;
using ULaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor.Implementation
{
    public class DecisionMaker : IDecisionMaker
    {
        private readonly IDecisionResult _decisionResult;
        public DecisionMaker(IDecisionResult decisionResult)
        {
           if(decisionResult == null)
           {
                throw new ArgumentNullException(nameof(decisionResult));
           }
           _decisionResult = decisionResult;
        }

        public string Decide(DecisionDeterminant decisionDeterminant, ApplicationDetails applicationDetails)
        {
           if(applicationDetails == null)
           {
               throw new ArgumentNullException(nameof(applicationDetails));
           }

           if (decisionDeterminant == null)
           {
               throw new ArgumentNullException(nameof(decisionDeterminant));
           }

            var result = _decisionResult.Generate(decisionDeterminant, applicationDetails);
            if (string.IsNullOrEmpty(result))
            {
                throw new InvalidOperationException("No Matching Outcomes from the Possible Outcome Store");
            }
            return result;
        }
    }
}
