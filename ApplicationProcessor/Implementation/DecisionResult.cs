using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Interfaces;
using Ulaw.ApplicationProcessor.Model;
using ULaw.ApplicationProcessor;
using ULaw.ApplicationProcessor.Enums;

namespace Ulaw.ApplicationProcessor.Implementation
{
    public class DecisionResult : IDecisionResult
    {
        private const string ResultHeader = "<html><body><h1>Your Recent Application from the University of Law</h1>";
        private const string ResultFooter = "</body></html>";
        private StringBuilder _decisionResult;
        private Dictionary<DecisionDeterminant, string> degreeResultMatcher;


        public DecisionResult()
        {
            degreeResultMatcher = new Dictionary<DecisionDeterminant, string>(new DeterminantEqualityComparer());
            _decisionResult = new StringBuilder();
            _decisionResult.Append(ResultHeader);

            //Two Two Possible OutComes
            var twotwoEnglish = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoTwo, DegreeSubject = DegreeSubjectEnum.English};
            degreeResultMatcher.Add(twotwoEnglish, ResultStringBuilder.GetTwoTwoResult());

            var twotwoMaths = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoTwo, DegreeSubject = DegreeSubjectEnum.maths };
            degreeResultMatcher.Add(twotwoMaths, ResultStringBuilder.GetTwoTwoResult());

            var twotwoLaw = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoTwo, DegreeSubject = DegreeSubjectEnum.law };
            degreeResultMatcher.Add(twotwoLaw, ResultStringBuilder.GetTwoTwoResult());

            var twotwoLawAndBusiness = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoTwo, DegreeSubject = DegreeSubjectEnum.lawAndBusiness };
            degreeResultMatcher.Add(twotwoLawAndBusiness, ResultStringBuilder.GetTwoTwoResult());


            //First Possible Outcome
            var firstMaths =
                new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.first, DegreeSubject = DegreeSubjectEnum.maths };
            degreeResultMatcher.Add(firstMaths, ResultStringBuilder.GetFirstOthers());
            var firstEnglish =
               new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.first, DegreeSubject = DegreeSubjectEnum.English };
            degreeResultMatcher.Add(firstEnglish, ResultStringBuilder.GetFirstOthers());
            var firstLaw =
          new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.first, DegreeSubject = DegreeSubjectEnum.law };
            degreeResultMatcher.Add(firstLaw, ResultStringBuilder.GetTwoOneFirstLawAndBusiness());
            var firstLawAndBusiness =
               new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.first, DegreeSubject = DegreeSubjectEnum.lawAndBusiness };
            degreeResultMatcher.Add(firstLawAndBusiness, ResultStringBuilder.GetTwoOneFirstLawAndBusiness());



            //Third Possible Outcome
            var thirdEnglish = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.third , DegreeSubject = DegreeSubjectEnum.English };
            degreeResultMatcher.Add(thirdEnglish, ResultStringBuilder.GetThirdResult());

            var thirdMaths = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.third, DegreeSubject = DegreeSubjectEnum.maths };
            degreeResultMatcher.Add(thirdMaths, ResultStringBuilder.GetThirdResult());

            var thirdLaw = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.third, DegreeSubject = DegreeSubjectEnum.law };
            degreeResultMatcher.Add(thirdLaw, ResultStringBuilder.GetThirdResult());

            var thirdLawAndBusiness = new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.third, DegreeSubject = DegreeSubjectEnum.lawAndBusiness };
            degreeResultMatcher.Add(thirdLawAndBusiness, ResultStringBuilder.GetThirdResult());


            //Second One Possible Outcome
            var TwoOneMaths =
               new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoOne, DegreeSubject = DegreeSubjectEnum.maths };
            degreeResultMatcher.Add(TwoOneMaths, ResultStringBuilder.GetFirstOthers());
            var TwoOneEnglish =
               new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoOne, DegreeSubject = DegreeSubjectEnum.English };
            degreeResultMatcher.Add(TwoOneEnglish, ResultStringBuilder.GetFirstOthers());
            var TwoOneLaw =
             new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoOne, DegreeSubject = DegreeSubjectEnum.law };
            degreeResultMatcher.Add(TwoOneLaw, ResultStringBuilder.GetTwoOneFirstLawAndBusiness());
            var TwoOneLawAndBusiness =
               new DecisionDeterminant { DegreeGrade = DegreeGradeEnum.twoOne, DegreeSubject = DegreeSubjectEnum.lawAndBusiness };
            degreeResultMatcher.Add(TwoOneLawAndBusiness, ResultStringBuilder.GetTwoOneFirstLawAndBusiness());
        }

        public string Generate(DecisionDeterminant decisionDeterminant, ApplicationDetails applicationDetails)
        {
            if(degreeResultMatcher.ContainsKey(decisionDeterminant))
            {
                var val = degreeResultMatcher[decisionDeterminant];
                var result = val.Replace("{{APPLICANT_FISRTNAME}}", applicationDetails.Applicant.FirstName)
                    .Replace("{{COURSE_CODE}}", applicationDetails.Course.CourseCode)
                    .Replace("{{START_DATE}}", applicationDetails.Course.StartDate.ToLongDateString())
                    .Replace("{{DEGREE_SUBJECT}}", decisionDeterminant.DegreeSubject.ToDescription())
                    .Replace("{{DEGREE_GRADE}}", decisionDeterminant.DegreeGrade.ToDescription()).ToString()
                    .Replace("{{DEPOSIT}}",applicationDetails.Deposit.ToString());
                _decisionResult.Append(result);
                _decisionResult.Append(ResultFooter);
                return _decisionResult.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
