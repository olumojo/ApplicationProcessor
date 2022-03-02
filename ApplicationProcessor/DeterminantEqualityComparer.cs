using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Model;
using ULaw.ApplicationProcessor;

namespace Ulaw.ApplicationProcessor
{
    public class DeterminantEqualityComparer : IEqualityComparer<DecisionDeterminant>
    {
        public bool Equals(DecisionDeterminant first, DecisionDeterminant second)
        {
            return first.DegreeSubject.ToDescription() == second.DegreeSubject.ToDescription() &&
                second.DegreeGrade.ToDescription() == second.DegreeGrade.ToDescription();
        }

        public int GetHashCode(DecisionDeterminant obj)
        {
            return obj.DegreeSubject.GetHashCode() * obj.DegreeGrade.GetHashCode();
        }
    }
}
