using System;
using System.Collections.Generic;
using System.Text;

namespace Ulaw.ApplicationProcessor.Model
{
    public class Applicant
    {
        public string FirstName { get; set; }

        public string Title { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool RequiredVisa { get; set; }

    }
}
