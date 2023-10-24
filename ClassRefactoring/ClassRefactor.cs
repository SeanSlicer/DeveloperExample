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

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => swallowType switch
        {
            SwallowType.African => new AfricanSwallow(),
            SwallowType.European => new EuropeanSwallow(),
            _ => throw new ArgumentException("Bad swallow type.")
        };
    }

    public abstract class Swallow : IBird
    {
        public SwallowLoad Load { get; private set; }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }

    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 22,
            SwallowLoad.Coconut => 18D,
            _ => throw new InvalidOperationException(),
        };
    }

    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 20,
            SwallowLoad.Coconut => 16D,
            _ => throw new InvalidOperationException(),
        };
    }
}
