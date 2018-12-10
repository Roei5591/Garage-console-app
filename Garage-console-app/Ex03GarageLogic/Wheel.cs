using System;

namespace Ex03GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        private float m_CurrentAirPressure;

        internal float CurrentAirPressure
        {
            set
            {
                m_CurrentAirPressure = value;
            }
            get
            {
                return m_CurrentAirPressure;
            }
        }

        private float m_ManufacturerMaximumAirPressure;

        internal float MaximumAirPressure
        {
            set
            {
                m_ManufacturerMaximumAirPressure = value;
            }    
            get
            {
                return m_ManufacturerMaximumAirPressure;
            }
        }

        internal void Inflate(float i_airToAdd)
        {
            if (i_airToAdd + this.m_CurrentAirPressure > this.m_ManufacturerMaximumAirPressure)
            {
                throw new ValueOutOfRangeException(m_ManufacturerMaximumAirPressure, 0);
            }

            this.m_CurrentAirPressure += i_airToAdd;
        }

        internal void InflateToMaximum()
        {
            this.m_CurrentAirPressure = this.m_ManufacturerMaximumAirPressure;
        }

        public string GetWheelDetails()
        {
            return String.Format("    Manufacturer: {0}" + Environment.NewLine + "    Pressure: {1}" + Environment.NewLine,
                this.m_ManufacturerName, this.m_CurrentAirPressure);
        }
    }
}
