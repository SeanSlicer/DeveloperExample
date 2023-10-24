using System;

namespace DeveloperSample.ClassRefactoring
{
    public interface IBird
    {
        double GetAirspeedVelocity();
    }

    public enum SwallowType
    {
        African,
        European
    }

    public enum SwallowLoad
    {
        None,
        Coconut
    }

public interface ILoad
{
    double ApplyLoad(double baseAirspeedVelocity);
}

public abstract class Load : ILoad
{
    public abstract double ApplyLoad(double baseAirspeedVelocity);
}

public interface ILoadFactory
{
    ILoad GetLoad(SwallowLoad load);
}

public class LoadFactory : ILoadFactory
{
    public ILoad GetLoad(SwallowLoad load) => load switch
    {
        SwallowLoad.None => new NoLoad(),
        SwallowLoad.Coconut => new CoconutLoad(),
        _ => throw new ArgumentException("Bad load type.")
    };
}

    public class NoLoad : Load
    {
        public override double ApplyLoad(double baseAirspeedVelocity)
        {
            return baseAirspeedVelocity;
        }
    }

    public class CoconutLoad : Load
    {
        public const double CoconutEffect = 4D;
        public override double ApplyLoad(double baseAirspeedVelocity)
        {
            double newAirspeedVelocity = baseAirspeedVelocity - CoconutEffect;
            return newAirspeedVelocity;
        }
    }

    public class SwallowFactory
    {
        private readonly ILoadFactory _loadFactory;

    public SwallowFactory(ILoadFactory factory = null) => _loadFactory = factory ?? new LoadFactory();
        public Swallow GetSwallow(SwallowType swallowType) => swallowType switch
    {
        SwallowType.African => new AfricanSwallow(_loadFactory),
        SwallowType.European => new EuropeanSwallow(_loadFactory),
        _ => throw new ArgumentException("Bad swallow type.")
    };
    }
    
    public abstract class Swallow : IBird
{
    private readonly ILoadFactory _loadFactory;

    protected Swallow(double baseAirspeedVelocity, ILoadFactory loadFactory)
    {
        BaseAirspeedVelocity = baseAirspeedVelocity;
        _loadFactory = loadFactory;
        Load = _loadFactory.GetLoad(SwallowLoad.None);
    }

    protected double BaseAirspeedVelocity { get; set; } = 0;
    public ILoad Load { get; private set; }

    public void ApplyLoad(SwallowLoad load) => Load = _loadFactory.GetLoad(load);

    public double GetAirspeedVelocity()
    {
        return Load.ApplyLoad(BaseAirspeedVelocity);
    }
}


    public class AfricanSwallow : Swallow
{
    public AfricanSwallow(ILoadFactory factory)
        : base(22D, factory)
    {
    }
}

    public class EuropeanSwallow : Swallow
{
    public EuropeanSwallow(ILoadFactory factory)
        : base(20D, factory)
    {
    }
}
}
