using System;

namespace Ex03GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine()
        {
            EngineType = eEngineType.Electric;
        }

        internal void ReplenishEnergy(float i_Amount)
        {
            if (!AddedEnergyDoesntExceedMaximum(i_Amount))
            {
                throw new ValueOutOfRangeException(EnergySourceMaximumAmount, 0);
            }

            EnergySourceAvailableAmount += i_Amount;
        }

        internal override string GetEngineDetails()
        {
            string engineDetails;

            engineDetails = String.Format("Available amount of battery: {0}" + Environment.NewLine, this.EnergySourceAvailableAmount);

            return engineDetails;
        }
    }
}
