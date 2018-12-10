using System;

namespace Ex03GarageLogic
{
    class Car : Vehicle
    {
        private const int m_CarNumberOfWheels = 4;
        private string[] m_SpecialParameterNames =
        {
            "Car Color [Choose: Yellow/White/Black/Blue]",
            "Number of Doors in Car"
        };
        private eColor? m_CarColor;
        private eDoorNumbers? m_DoorNumber;

        internal override string[] GetSpecialVehicleParameterNames()
        {
            return m_SpecialParameterNames;
        }

        internal override void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue)
        {
            if (i_ParameterName.Equals(m_SpecialParameterNames[0]))
            {
                eColor givenColor = (eColor)Enum.Parse(typeof(eColor), i_ParameterValue);
                if (Enum.IsDefined(typeof(eColor), givenColor))
                {
                    m_CarColor = givenColor;
                }
                else
                {
                    throw new ArgumentException("Invalid input for Car Color!");
                }
            }

            if (i_ParameterName.Equals(m_SpecialParameterNames[1]))
            {
                eDoorNumbers givenDoorNumber = (eDoorNumbers)Enum.Parse(typeof(eDoorNumbers), i_ParameterValue);
                if (Enum.IsDefined(typeof(eDoorNumbers), givenDoorNumber))
                {
                    m_DoorNumber = givenDoorNumber;
                }
                else
                {
                    throw new ArgumentException("Illegal input for Door Number!");
                }
            }
        }

        internal override string GetDetails()
        {
            string carDetails;

            carDetails = String.Format(
                "{0}" +
                "Color: {1}" + Environment.NewLine +
                "Number of doors: {2}" + Environment.NewLine,
                this.GetBasicDetails(),
                Enum.GetName(typeof(eColor), m_CarColor),
                Enum.GetName(typeof(eDoorNumbers), m_DoorNumber));

            return carDetails;
        }
    }
}