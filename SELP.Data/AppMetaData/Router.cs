using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";

        public const string defaultRoot = "SELP";
        public const string version = "V1";
        public const string role = defaultRoot + "/" + version + "/";

        #region ApplicationUser
        public static class ApplicationUser
        {
            public const string prefix = role + "User";
             public const string List = prefix + "/List";
              public const string GetByID = prefix + SingleRoute;

            public const string Create = "/Register";
              public const string Edit = prefix + "/Edit";
              public const string ChangePassword = prefix + "/ChangePassword";
              public const string Delete = prefix + "/{id}";
        }
        public static class Authentication
        {
            public const string ConfirmEmail = "/Api/V1/Authentication/ConfirmEmail";
            public const string prefix = role + "User";
             //public const string List = prefix + "/List";
             // public const string GetByID = prefix + SingleRoute;

            public const string SignIn = prefix + "/SignIn";
            public const string SendResetPassword = prefix + "/SendResetPassword";
            public const string ConfirmResetPass = prefix + "/ConfirmResetPass";
            public const string ChangePassword = prefix + "/ChangePassword";
              //public const string Edit = prefix + "/Edit";
              //public const string ChangePassword = prefix + "/ChangePassword";
              //public const string Delete = prefix + "/{id}";
        }
        public static class Authorization
        {
            public const string prefix = role + "User";
             public const string List = prefix + "/List";
              public const string GetByID = prefix + SingleRoute;

            public const string Create = prefix + "/Role" + "/Create";
              public const string Edit = prefix + "/Role" + "/Edit_Roles";
              //public const string ChangePassword = prefix + "/ChangePassword";
              public const string Delete = prefix + "/Role" + "/{id}";


            public const string ManageUserRoles = prefix + "/Role" + "/ManageUserRoles/{UserId}";

            public const string ManageUserClaims = prefix + "/Claim" + "/ManageUserClaims/{userId}";
            public const string CreateUserClaims = prefix + "/Claim" + "/CreateUserClaims";
        }
        #endregion





        public static class StudentRouting
        {
            public const string prefix = role + "Student";
            public const string List = prefix + "/List";
            public const string GetByID = prefix + SingleRoute;

            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + "/{id}";
        }
        
        public static class InstructorRouting
        {
            public const string prefix = role + "Instructor";
              public const string GetAllInstructors = prefix + "/List";
            public const string GetByID = prefix + SingleRoute;
            public const string AddInstructor = prefix + "/AddInstructor";
            public const string UpdateInstructor = prefix + "/UpdateInstructor";
            public const string DeleteInstructor = prefix + "/{id}";

        }
        public static class SubjectRouting
        {
            public const string prefix = role + "Subject";
            public const string GetAllSubject = prefix + "/List";
            public const string GetByID = prefix + SingleRoute;
           public const string AddSubject = prefix + "/AddSubject";
             public const string UpdateSubject = prefix + "/UpdateSubject";
            public const string DeleteSubject = prefix + "/{id}";
           
            public const string GetSubjectsForContent = prefix + "/GetSubjectsForContent";
            public const string AddContentToSubject = prefix + "/AddContentToSubject";


            public const string GetSubjectsForInstructor = prefix + "/GetSubjectsForInstructor";
            public const string AddSubjectToInstructor = prefix + "/AddSubjectToInstructor";
            //public const string RemoveSubjectFromInstructor = prefix + "/RemoveSubjectFromInstructor";
    

            public const string GetSubjectsForStudent = prefix + "/GetSubjectsForStudent";
            public const string AddSubjectToStudent = prefix + "/AddSubjectToStuent";
            public const string RemoveSubjectFromStudent = prefix + "/RemoveSubjectFromStudent";
            

        }

        public static class ContentRouting
        {
            public const string prefix = role + "Content";
            public const string GetByID = prefix + SingleRoute;
            public const string List = prefix + "/List";

            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + "/{id}";
        }
        public static class QuizRouting
        {
            public const string prefix = role + "Quiz";
            public const string GetByID = prefix + SingleRoute;
            public const string List = prefix + "/List";

            public const string Create = prefix + "/Create";
            public const string Edit = prefix + "/Edit";
            public const string Delete = prefix + "/{id}";
        }
    }
}
