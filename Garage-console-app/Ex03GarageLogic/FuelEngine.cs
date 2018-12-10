using System;

namespace Ex03GarageLogic
{
    class FuelEngine : Engine
    {
        eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType)
        {
            EngineType = eEngineType.Fuel;
            m_FuelType = i_FuelType;
        }

        bool FuelTypeMatchesEngine(eFuelType i_FuelType)
        {
            return i_FuelType == m_FuelType;
        }

        internal void ReplenishEnergy(eFuelType i_FuelType, float i_Amount)
        {
            if (!FuelTypeMatchesEngine(i_FuelType))
            {
                throw new ArgumentException("Wrong fuel type");
            }

            if (!AddedEnergyDoesntExceedMaximum(i_Amount))
            {
                throw new ValueOutOfRangeException(EnergySourceMaximumAmount, 0);
            }

            EnergySourceAvailableAmount += i_Amount;

        }

        internal override string GetEngineDetails()
        {
            string engineDetails;

            engineDetails = String.Format(
                "Available amount of fuel: {0}" + Environment.NewLine +
                "Fuel type: {1}" + Environment.NewLine,
                EnergySourceAvailableAmount, Enum.GetName(typeof(eFuelType), (m_FuelType)));

            return engineDetails;
        }
    }
}
