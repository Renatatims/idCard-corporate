namespace idCard.Corporate
{
    class Employee
    {
        private string CompanyName;
        private string FirstName;
        private string LastName;
        private int Id;
        private string PhotoUrl;

        public Employee(string companyName, string firstName, string lastName, int id, string photoUrl)
        {
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }
        // Company Name
        public string GetCompanyName()
        {
            return CompanyName;
        }

        // Employee's Full Name
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        // Employee's ID
        public int GetId()
        {
            return Id;
        }

        // Employee's photo
        public string GetPhotoUrl()
        {
            return PhotoUrl;
        }
    }
}