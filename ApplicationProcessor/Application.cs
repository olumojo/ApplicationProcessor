using System;
using Ulaw.ApplicationProcessor.Implementation;
using Ulaw.ApplicationProcessor.Interfaces;
using Ulaw.ApplicationProcessor.Model;
using ULaw.ApplicationProcessor.Enums;  

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        //can introduce logging and DI properly
        private IDecisionMaker _decisionMaker; // this can be Inject
        decimal depositAmount = 350.00M;
        public Application(string faculty, string CourseCode, DateTime Startdate, string Title, string FirstName, string LastName, DateTime DateOfBirth, bool requiresVisa)
        {
            this.ApplicationId = new Guid();
            Applicant = new Applicant
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Title = Title,
                RequiredVisa = requiresVisa
            };
            Course = new Course
            {
                CourseCode = CourseCode,
                StartDate = Startdate,
                Faculty = faculty
            };
            IDecisionResult decisionResult = new DecisionResult();
            _decisionMaker = new DecisionMaker(decisionResult);
        }

        public Applicant Applicant { get; set; }

        public Course Course { get; set; }

        public Guid ApplicationId { get; private set; }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }

        public string Process()
        {
            var decisionDeterminant = new DecisionDeterminant
            {
                DegreeGrade = DegreeGrade,
                DegreeSubject = DegreeSubject
            };
            var applicantionDetails = new ApplicationDetails
            {
                Applicant = Applicant,
                Course = Course,
                Deposit = depositAmount
            };
            var result = _decisionMaker.Decide(decisionDeterminant, applicantionDetails);

            return result.ToString();
        }

    }
}

