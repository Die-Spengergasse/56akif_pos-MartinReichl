using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.DomainLinQ.App.Model
{
    /// <summary>
    /// * Name
    /// * Department [Die ersten 3 Zeichen von Name]
    /// * Guid
    /// (4P)
    /// </summary>
    public class SchoolClass : EntityBase
    {
        // TODO: Implementation
        private List<Student> _students = new();
        private List<Subject> _subjects = new();

        public string Name { get; set; } = string.Empty;
        public string Department => Name.Substring(0, 2);
        public Guid Guid { get; private set; }
        public virtual IReadOnlyList<Student> Students => _students;
        public virtual IReadOnlyList<Subject> Subjects => _subjects;
        public Teacher Kv { get; set; }

        protected SchoolClass()
        { }

        public SchoolClass(string name, Teacher kv,Guid guid)
        {
            Name = name;
            Kv = kv;
            Guid = guid;
        }
    }
}
