using System;
using System.Collections.Generic;
using System.Text;
using Ulaw.ApplicationProcessor.Model;

namespace Ulaw.ApplicationProcessor
{
    public static class ResultStringBuilder
    {
        public static string GetTwoTwoResult()
        {
            var result = new StringBuilder();
            result.Append("<p> Dear {{APPLICANT_FISRTNAME}}, </p>");
            result.Append("<p/> Further to your recent application for our course reference: {{COURSE_CODE}} starting on {{START_DATE}}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            return result.ToString();
        }

        public static string GetFirstOthers()
        {
            var result = new StringBuilder();
            result.Append("<p> Dear {{APPLICANT_FISRTNAME}}, </p>");
            result.Append("<p/> Further to your recent application for our course reference: {{COURSE_CODE}} starting on {{START_DATE}}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            return result.ToString();
        }

        public static string GetThirdResult()
        {
            var result = new StringBuilder();
            result.Append("<p> Dear {{APPLICANT_FISRTNAME}}, </p>");
            result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
            result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            return result.ToString();
        }

        public static string GetTwoOneFirstLawAndBusiness()
        {
            var result = new StringBuilder();
            result.Append("<p> Dear {{APPLICANT_FISRTNAME}}, </p>");
            result.Append("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {{COURSE_CODE}} starting on {{START_DATE}}.");
            result.Append("<br/> This offer will be subject to evidence of your qualifying {{DEGREE_SUBJECT}} degree at grade: {{DEGREE_GRADE}}.");
            result.Append("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{{DEPOSIT}} deposit fee to secure your place.");
            result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));
            result.Append(string.Format("<br/> Yours sincerely,"));
            result.Append(string.Format("<p/> The Admissions Team,"));
            return result.ToString();
        }
    }
}
