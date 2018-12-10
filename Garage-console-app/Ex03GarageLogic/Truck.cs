using System;

namespace Ex03GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterial;
        float m_MaxAllowedWeightLoad;

        private string[] m_TruckSpecialParameterNames =
        {
            "Is it carrying hazardous materials? [Yes/No]",
            "Maximum Allowed Weight Load [Weight in KG]"
        };

        internal override string[] GetSpecialVehicleParameterNames()
        {
            return m_TruckSpecialParameterNames;
        }

        internal override void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue)
        {
            if (i_ParameterName.Equals(m_TruckSpecialParameterNames[0]))
            {
                if (i_ParameterValue.ToLower().Equals("yes"))
                {
                    m_IsCarryingHazardousMaterial = true;
                }
                else if (i_ParameterValue.ToLower().Equals("no"))
                {
                    m_IsCarryingHazardousMaterial = false;
                }
                else throw new ArgumentException("Illegal value entered for Hazardous Materials question. Expected: Yes/No");
            }

            if (i_ParameterName.Equals(m_TruckSpecialParameterNames[1]))
            {
                m_MaxAllowedWeightLoad = float.Parse(i_ParameterValue);
            }
        }

        internal override string GetDetails()
        {
            string truckDetails;

            truckDetails = String.Format(
                "{0}" +
                "Is carrying hazardous material: {1}" + Environment.NewLine +
                "Maximum allowed weight load: {2}" + Environment.NewLine,
                this.GetBasicDetails(),
                this.m_IsCarryingHazardousMaterial,
                this.m_MaxAllowedWeightLoad);

            return truckDetails;
        }
    }
}
