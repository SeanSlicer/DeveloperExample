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
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow : IBird
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return Type switch
            {
                SwallowType.African => CalculateAirspeedForAfrican(),
                SwallowType.European => CalculateAirspeedForEuropean(),
                _ => throw new InvalidOperationException(),
            };
        }

        private double CalculateAirspeedForAfrican()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => (double)18,
                _ => throw new InvalidOperationException(),
            };
        }

        private double CalculateAirspeedForEuropean()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => (double)16,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
