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

    public abstract class Load
    {
        public abstract double ApplyLoad(double baseAirspeedVelocity);
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
        public Load Load { get; private set; } = new NoLoad();

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load switch
            {
                SwallowLoad.Coconut => new CoconutLoad(),
                _ => throw new ArgumentException("Bad load type.")
            };
        }

        public double GetAirspeedVelocity()
        {
            return Load.ApplyLoad(BaseAirspeedVelocity);
        }
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow()
        {
            BaseAirspeedVelocity = 22D;
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow()
        {
            BaseAirspeedVelocity = 20D;
        }
    }
}
