using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Date (?)
    /// * Lesson (int?)
    /// * Created
    /// * Guid
    /// * Grade (Note 1-5)
    /// (4P)
    /// </summary>
    public class Exam : EntityBase
    {
        // TODO: Implementation
        private int _grade;

        public int Id { get; private set; }
        public DateTime? Date { get; private set; }
        public int? Lesson { get; set; } = default!;
        public DateTime Created { get; private set; }
        public Guid Guid { get; private set; }
        public int SubjectNavigationId { get; set; }
        public virtual Subject SubjectNavigation { get; set; } = default!;
        public int Grade 
        {
            get => _grade;

            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Grade must be between 1 and 5!");
                }

                _grade = value;
            }
        }

        protected Exam()
        { }

        public Exam(Guid guid, 
            DateTime? date,
            int? lesson,
            int grade,
            Subject subject,
            DateTime created)
        {
            Guid = guid;
            Date = date;
            Lesson = lesson;
            Grade = grade;
            SubjectNavigation = subject;
            Created = created;
        }
    }
}
