using ADC.Portal.Solution.Domain.Entity.Common;
using ADC.Portal.Solution.Domain.Validation.CategoryValidation;
using System;

namespace ADC.Portal.Solution.Domain.ObjectValue
{
    public class Category : EntityBase
    {
        protected Category()
        {
            Id = Guid.NewGuid();
            CreatedIn = DateTime.Now;
            ChangedIn = DateTime.Now;
            Status = Status.Active;
        }

        public Category(string name)
            :this()
        {
            Name = name;
            Validate(this, new CategoryValidator());
        }

        public virtual string Name { get; set; }        

        public virtual string Description { get; set; }        

        public Status Status { get; set; }

        public override string ToString()
        {
            return Name;
        }


        #region Constant

        public const int NAME_MAXLENGHT = 250;
        public const int NAME_MINLENGHT = 3;

        public const int DESCRIPTION_MAXLENGHT = 500;
        public const int DESCRIPTION_MINLENGHT = 3;

        #endregion

        #region Operator

        public override int GetHashCode()
        {
            return string.Format("[{0}:{1}]", this.GetType().Name, Id).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Category equal = obj as Category;
            return !Equals(equal, null) && this.GetHashCode() == equal.GetHashCode();
        }

        public static bool operator ==(Category a, Category b)
        {
            return object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));
        }

        public static bool operator !=(Category a, Category b)
        {
            return !(object.Equals(a, null) && object.Equals(b, null)
                || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b)));
        }

        #endregion
    }
}
