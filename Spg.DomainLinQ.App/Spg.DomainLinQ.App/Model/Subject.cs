using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Description
    /// (4P)
    /// </summary>
    public class Subject : EntityBase
    {
        // TODO: Implementation
        private List<Exam> _exams = new();

        public string Description { get; set; } = string.Empty;
        public int SchoolClassNavigationId { get; set; }
        public virtual SchoolClass SchoolClassNavigation { get; set; } = default!;
        public int StudentNavigationId { get; set; }
        public virtual Student StudentNavigation { get; set; } = default!;
        public virtual IReadOnlyList<Exam> Exams => _exams;
        public int TeacherNavigationId { get; set; }
        public virtual Teacher TeacherNavigation { get; set; } = default!;

        protected Subject()
        { }

        public Subject(string description, SchoolClass schoolClass)
        {
            Description = description;
            SchoolClassNavigation = schoolClass;
        }
    }
}
