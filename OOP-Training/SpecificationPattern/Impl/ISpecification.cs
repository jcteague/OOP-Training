namespace OOP_Training.SpecificationPattern.Impl
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);
    }

    public abstract class CompositeSpecificationBase<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _leftExpr;
        private readonly ISpecification<T> _rightExpr;

        protected CompositeSpecificationBase(
            ISpecification<T> left,
            ISpecification<T> right)
        {
            _leftExpr = left;
            _rightExpr = right;
        }

        public ISpecification<T> Left { get { return _leftExpr; } }
        public ISpecification<T> Right { get { return _rightExpr; } }

        public abstract bool IsSatisfiedBy(T obj);
    }

    public class AndSpecification<T> : CompositeSpecificationBase<T>
    {
        public AndSpecification(
            ISpecification<T> left,
            ISpecification<T> right)
            : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T obj)
        {
            return Left.IsSatisfiedBy(obj) && Right.IsSatisfiedBy(obj);
        }
    }

    public class OrSpecification<T> : CompositeSpecificationBase<T>
    {
        public OrSpecification(
            ISpecification<T> left,
            ISpecification<T> right)
            : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T obj)
        {
            return Left.IsSatisfiedBy(obj) || Right.IsSatisfiedBy(obj);
        }
    }

    public class NegatedSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _inner;
     
        public NegatedSpecification(ISpecification<T> inner)
        {
            _inner = inner;
        }
     
        public ISpecification<T> Inner
        {
            get { return _inner; }
        }
     
        public bool IsSatisfiedBy(T obj)
        {
            return !_inner.IsSatisfiedBy(obj);
        }
    }

    public static class ISpecificationExtensions
    {
        public static ISpecification<T> And<T>(
            this ISpecification<T> left,
            ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(
            this ISpecification<T> left,
            ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static ISpecification<T> Negate<T>(this ISpecification<T> inner)
        {
            return new NegatedSpecification<T>(inner);
        }
    }


}