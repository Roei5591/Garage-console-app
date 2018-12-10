using System;

namespace Ex03GarageLogic
{
    class CustomVehicle : Vehicle
    {
        private const string m_NoSpecialParametersMessage = "No Special Parameters are defined for a custom vehicle";

        internal override string GetDetails()
        {
            throw new ArgumentException(m_NoSpecialParametersMessage);
        }

        internal override string[] GetSpecialVehicleParameterNames()
        {
            throw new ArgumentException(m_NoSpecialParametersMessage);
        }

        internal override void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue)
        {
            throw new ArgumentException(m_NoSpecialParametersMessage);
        }
    }
}
