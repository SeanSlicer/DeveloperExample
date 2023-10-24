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
        protected double BaseAirspeedVelocity { get; set; } = 0;
        public SwallowLoad Load { get; private set; }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return Load switch 
            {
                SwallowLoad.None => BaseAirspeedVelocity,
                SwallowLoad.Coconut => BaseAirspeedVelocity -4D,
                _ => throw new InvalidOperationException(),
            };
        }
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow()
        {
        BaseAirspeedVelocity = 22;
        } 
    }

    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow()
        {
        BaseAirspeedVelocity = 20;
        }
    }
}
