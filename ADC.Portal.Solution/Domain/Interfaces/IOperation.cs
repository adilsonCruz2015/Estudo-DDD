

namespace ADC.Portal.Solution.Domain.Interfaces
{
    public interface IOperation<TEntity> where TEntity : class
    {
        void Apply(ref TEntity entity);

        void Undo(ref TEntity entity);
    }
}
