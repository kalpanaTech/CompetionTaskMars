using CompetionTaskMars.Helpers;
using CompetionTaskMars.Pages;
using CompetionTaskMars.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetionTaskMars.Steps
{
    public class CertificationSteps : Driver
    {
        readonly Certifications certificationActions;

        public CertificationSteps(IWebDriver driver)
        {
            certificationActions = new Certifications(driver);
        }

        //method for Cleanup
        public void CleanupExistingCertification()
        {
            certificationActions.CleanupCertification();
        }

        //method for Navigate To Certification Tab
        public void NavigateToTheCertificationTab()
        {
            certificationActions.NavigateToCertificationTab();
        }

        public void AddCertification(CertificationCredentials credentials)
        {
            certificationActions.AddNewCertificationButtonActions();
            certificationActions.AddCertificateActions(credentials.Certificate);
            certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
            certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
            certificationActions.AddCertificationButtonActions();
            certificationActions.VerifyCertificationToastMessageActions("AddCertification", credentials.Certificate);

            // Verification steps
            VerifyCertificationOnProfile(credentials);
            VerifyCertificationOnResultsPage(credentials);

        }

        public void UpdateCertification(CertificationCredentials credentials)
        {
            if (credentials.Action == "Add")
            {
                certificationActions.AddNewCertificationButtonActions();
                certificationActions.AddCertificateActions(credentials.Certificate);
                certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.AddCertificationButtonActions();

            }

            else if (credentials.Action == "Update")
            {
                certificationActions.NavigateToCertificationTab();
                certificationActions.UpdateCertificationActions(credentials.Certificate);
                certificationActions.UpdateCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.UpdateYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.UpdateCertificationOptionActions();
                certificationActions.VerifyCertificationToastMessageActions("UpdateCertification", credentials.Certificate);

                VerifyCertificationOnProfile(credentials);
                VerifyCertificationOnResultsPage(credentials);
            }
        }

        public void AddDuplicateCertification(CertificationCredentials credentials)

        {
            certificationActions.AddNewCertificationButtonActions();
            certificationActions.AddCertificateActions(credentials.Certificate);
            certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
            certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
            certificationActions.AddCertificationButtonActions();
            certificationActions.VerifyCertificationToastMessageActions("AddCertification", credentials.Certificate);

            certificationActions.NavigateToCertificationTab();
            certificationActions.AddNewCertificationButtonActions();
            certificationActions.AddCertificateActions(credentials.Certificate);
            certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
            certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
            certificationActions.AddCertificationButtonActions();
            certificationActions.VerifyCertificationToastMessageActions("AddExistingCertification", credentials.Certificate);
        }

        public void AddNullCertification(CertificationCredentials credentials)

        {
            certificationActions.AddNewCertificationButtonActions();
            certificationActions.AddCertificateActions(credentials.Certificate);
            certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
            certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
            certificationActions.AddCertificationButtonActions();
            certificationActions.VerifyCertificationToastMessageActions("AddNullCertification", credentials.Certificate);
        }

        public void CancelAddCertification(CertificationCredentials credentials)

        {
            if (credentials.Action == "Add")
            {
                certificationActions.AddNewCertificationButtonActions();
                certificationActions.AddCertificateActions(credentials.Certificate);
                certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.AddCertificationButtonActions();
                certificationActions.VerifyCertificationToastMessageActions("AddCertification", credentials.Certificate);
                VerifyCertificationOnProfile(credentials);
            }
            else if (credentials.Action == "CancelAdd")
            {
                certificationActions.NavigateToCertificationTab();
                certificationActions.AddNewCertificationButtonActions();
                certificationActions.AddCertificateActions(credentials.Certificate);
                certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.AddCertificationCancelButtonActions();

            }
        }
        public void CancelUpdateCertification(CertificationCredentials credentials)
        {
            if (credentials.Action == "Add")
            {
                certificationActions.AddNewCertificationButtonActions();
                certificationActions.AddCertificateActions(credentials.Certificate);
                certificationActions.AddCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.AddYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.AddCertificationButtonActions();
                VerifyCertificationOnProfile(credentials);

            }

            else if (credentials.Action == "Update")
            {
                certificationActions.NavigateToCertificationTab();
                certificationActions.UpdateCertificationActions(credentials.Certificate);
                certificationActions.UpdateCertifiedFromeActions(credentials.CertifiedFrom);
                certificationActions.UpdateYearOfCertificationActions(credentials.CertificationYear);
                certificationActions.UpdateCertificationCancelButtonActions();

            }
        }



        private void VerifyCertificationOnProfile(CertificationCredentials credentials)
        {
            string addedCertificate = certificationActions.GetAddedCertificateOnProfilePage();
            string addedCertificateFrom = certificationActions.GetAddedCertificateFromOnProfilePage();
            string addedCertificateYear = certificationActions.GetAddedCertificateYearOnProfilePage();

            Console.WriteLine("Added Certificate On Profile page: " + addedCertificate);

            Assert.That(addedCertificate == credentials.Certificate, "Certificate has not been added correctly.");
            Assert.That(addedCertificateFrom == credentials.CertifiedFrom, "CertificateFrom has not been added correctly.");
            Assert.That(addedCertificateYear == credentials.CertificationYear, "CertificateYear has not been added correctly.");

        }

        private void VerifyCertificationOnResultsPage(CertificationCredentials credentials)
        {
            certificationActions.ProfileOpenActionsResultsPage(credentials.User);
            certificationActions.ViewAddedCertificationDetailsOnResultsPage();

            string addedCertificateOnResultPage = certificationActions.GetAddedCertificateOnResultPage();
            string addedCertificateFromOnResultPage = certificationActions.GetAddedCertificateFromOnResultPage();
            string addedCertificateYearOnResultPage = certificationActions.GetAddedCertificateYearOnResultPage();

            Console.WriteLine("Added Certificate On Result Page: " + addedCertificateOnResultPage);

            Assert.That(addedCertificateOnResultPage == credentials.Certificate, "Certificate has not been added on results page.");
            Assert.That(addedCertificateFromOnResultPage == credentials.CertifiedFrom, "CertificateFrom has not been added on results page.");
            Assert.That(addedCertificateYearOnResultPage == credentials.CertificationYear, "CertificateYear has not been added on results page.");


        }


    }
}
