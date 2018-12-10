using System;

namespace Ex03GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int v_MotorcycleNumberOfWheels = 2;
        private int m_EngineVolume;
        private eMotorcycleLicenseTypes m_LicenseType;
        private string[] m_MotorcycleSpecialParameterNames =
        {
            "Engine Volume [CC]",
            "License Type [A/AB/A2/B1]"
        };

        internal override string[] GetSpecialVehicleParameterNames()
        {
            return m_MotorcycleSpecialParameterNames;
        }

        internal override void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue)
        {
            if (i_ParameterName.Equals(m_MotorcycleSpecialParameterNames[0]))
            {
                m_EngineVolume = int.Parse(i_ParameterValue);
            }

            if (i_ParameterName.Equals(m_MotorcycleSpecialParameterNames[1]))
            {
                m_LicenseType = (eMotorcycleLicenseTypes)Enum.Parse(typeof(eMotorcycleLicenseTypes), i_ParameterValue.ToUpper());
            }
        }

        internal override string GetDetails()
        {
            string motorcycleDetails;

            motorcycleDetails = String.Format(
                "{0}" +
                "Engine volume: {1}" + Environment.NewLine +
                "License Type: {2}" + Environment.NewLine,
                this.GetBasicDetails(),
                this.m_EngineVolume,
                Enum.GetName(typeof(eMotorcycleLicenseTypes), this.m_LicenseType));

            return motorcycleDetails;
        }

    }


}
