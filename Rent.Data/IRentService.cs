using Rent.Data.Entity;
using Rent.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rent.Data
{
    public interface IRentService
    {
        ICompanyRepository Companies { get; set; }
        IRentalRepository Rentals { get; set; }
        IInstructorRepository Instructors { get; set; }
        ILanguageRepository Languages { get; set; }
        ILanguageLevelRepository LanguageLevels { get; set; }
        ITicketRepository Tickets { get; set; }
        IWageRateRepository WageRates { get; set; }
        IExpertiseRepository Expertises { get; set; }
        IExpertiseLevelRepository ExpertiseLevels { get; set; }
        void Dispose();
        void Commit();
        bool CreateCompany(Company company, string userId);
        bool CreateRental(Rental rental, string userId);
        bool CreateInstructor(Instructor instructor, string userId);
        bool CreateLanguage(Language language, string userId);
        bool CreateLanguageLevel(LanguageLevel languageLevel, string userId);
        bool CreateTicket(Ticket ticket, string userId);
        bool CreateWageRate(WageRate wageRate, string userId);
        bool CreateExpertise(Expertise expertise, string userId);
        bool CreateExpertiseLevel(ExpertiseLevel expertiseLevel, string userId);
        bool CreateInstructorAvailability(ICollection<InstructorAvailability> availabilities, string userId);
        bool CreateInstructorAvailability(InstructorAvailability availability, string userId);
    }

    public class RentService : IRentService
    {
        public ICompanyRepository Companies { get; set; }
        public IRentalRepository Rentals { get; set; }
        public IInstructorRepository Instructors { get; set; }
        public ILanguageRepository Languages { get; set; }
        public ILanguageLevelRepository LanguageLevels { get; set; }
        public ITicketRepository Tickets { get; set; }
        public IWageRateRepository WageRates { get; set; }
        public IExpertiseRepository Expertises { get; set; }
        public IExpertiseLevelRepository ExpertiseLevels { get; set; }
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }

        public bool CreateCompany(Company company, string userId)
        {
            try
            {
                company.Name = company.Name.Trim();
                company.UserCreated = userId;
                Companies.Add(company);
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool CreateRental(Rental rental, string userId)
        {
            try
            {
                if(!Rentals.Items.Any(x => x.Name == rental.Name.Trim()))
                {
                    rental.Name = rental.Name.Trim();
                    rental.Shortname = rental.Shortname.Trim();
                    rental.UserCreated = userId;
                    rental.CompanyId = Companies.GetCompany.Id;
                    Rentals.Add(rental);
                    return true;
                }             
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool CreateInstructor(Instructor instructor, string userId)
        {
            try
            {
                if(!Instructors.Items.Any(x => x.Firstname == instructor.Firstname.Trim() && x.Surname == instructor.Surname.Trim()))
                {
                    instructor.Firstname = instructor.Firstname.Trim();
                    instructor.Surname = instructor.Surname.Trim();
                    instructor.UserCreated = userId;
                    instructor.Order = Instructors.Items.Select(x => x.Order).DefaultIfEmpty(0).Max() + 1;

                    foreach (var l in instructor.Languages)
                        l.LanguageLevel = LanguageLevels.FindById(l.LanguageLevelId);

                    var languages = new List<InstructorLanguage>(instructor.Languages);
                    foreach (var l in languages)
                        if (instructor.Languages.Any(x => x.LanguageId == l.LanguageId && x.LanguageLevel.Level > l.LanguageLevel.Level))
                            instructor.Languages.Remove(l);

                    foreach (var e in instructor.Expertises)
                        e.ExpertiseLevel = ExpertiseLevels.FindById(e.ExpertiseLevelId);

                    var expertises = new List<InstructorExpertise>(instructor.Expertises);
                    foreach (var e in expertises)
                        if (instructor.Expertises.Any(x => x.ExpertiseId == e.ExpertiseId && x.ExpertiseLevel.Level > e.ExpertiseLevel.Level))
                            instructor.Expertises.Remove(e);

                    foreach (var ticket in instructor.Tickets)
                    {
                        ticket.From = ticket.From.Date;
                        ticket.To = ticket.To.Date;
                    }

                    Instructors.Add(instructor);
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool CreateLanguage(Language language, string userId)
        {
            try
            {
                if(!Languages.Items.Any(x => x.Shortname == language.Shortname.Trim() && x.Name == language.Name.Trim()))
                {
                    language.Shortname = language.Shortname.Trim();
                    language.Name = language.Name.Trim();
                    language.UserCreated = userId;
                    Languages.Add(language);
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool CreateLanguageLevel(LanguageLevel languageLevel, string userId)
        {
            try
            {
                if(!LanguageLevels.Items.Any(x => x.Name == languageLevel.Name.Trim() && x.Level == languageLevel.Level))
                {
                    languageLevel.Name = languageLevel.Name.Trim();
                    languageLevel.UserCreated = userId;
                    LanguageLevels.Add(languageLevel);
                    return true;
                }
            }
            catch (Exception e)
            {
               
            }
            return false;
        }

        public bool CreateTicket(Ticket ticket, string userId)
        {
            try
            {
                if(!Tickets.Items.Any(x => x.Name == ticket.Name.Trim() && x.RentalId == ticket.RentalId))
                {
                    ticket.Name = ticket.Name.Trim();
                    ticket.UserCreated = userId;
                    Tickets.Add(ticket);
                    return true;
                }
            }
            catch (Exception e)
            {
                
            }
            return false;
        }

        public bool CreateWageRate(WageRate wageRate, string userId)
        {
            try
            {
                if(!WageRates.Items.Any(x => x.Name == wageRate.Name.Trim() && x.Rate == wageRate.Rate && x.Percental == wageRate.Percental))
                {
                    wageRate.Name = wageRate.Name.Trim();
                    wageRate.UserCreated = userId;
                    WageRates.Add(wageRate);
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool CreateExpertise(Expertise expertise, string userId)
        {
            try
            {
                if(!Expertises.Items.Any(x => x.Name == expertise.Name.Trim() && x.Shortname == expertise.Shortname.Trim()))
                {
                    expertise.Name = expertise.Name.Trim();
                    expertise.Shortname = expertise.Shortname.Trim();
                    expertise.UserCreated = userId;
                    Expertises.Add(expertise);
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public bool CreateExpertiseLevel(ExpertiseLevel expertiseLevel, string userId)
        {
            try
            {
                if (!ExpertiseLevels.Items.Any(x => x.Name == expertiseLevel.Name.Trim() && x.Shortname == expertiseLevel.Shortname.Trim() && x.Level == expertiseLevel.Level))
                {
                    expertiseLevel.Name = expertiseLevel.Name.Trim();
                    expertiseLevel.Shortname = expertiseLevel.Shortname.Trim();
                    expertiseLevel.UserCreated = userId;
                    ExpertiseLevels.Add(expertiseLevel);
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public bool CreateInstructorAvailability(ICollection<InstructorAvailability> availabilities, string userId)
        {
            try
            {
                if (availabilities.Any())
                {
                    var instructor = Instructors.FindById(availabilities.FirstOrDefault().InstructorId);
                    foreach (var availability in availabilities)
                    {
                        if(availability.From < availability.To)
                        {
                            availability.UserCreated = userId;
                            instructor.Availabilities.Add(availability);
                        }                        
                    }
                    Instructors.Update(instructor);
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public bool CreateInstructorAvailability(InstructorAvailability availability, string userId)
        {
            try
            {
                var instructor = Instructors.FindById(availability.InstructorId);
                if (availability.From < availability.To)
                {
                    availability.UserCreated = userId;
                    instructor.Availabilities.Add(availability);
                }
                Instructors.Update(instructor);
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

    }
}
