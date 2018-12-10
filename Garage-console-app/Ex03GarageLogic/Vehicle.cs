using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GarageLogic
{
    public abstract class Vehicle
    {
        private string[] v_VehiclePropertyNames =
        {
            "Vehicle License Number", 
            "Owner Name",             
            "Owner Phone",            
            "Model Name",
            "Remaining Quantity of Energy Source (Liters for Fuel, Hours for Battery)",
            "Wheel Manufacturer Name",
            "Current Pressure In The Vehicle's Wheels"
        };
        protected eStatus m_StatusInGarage = eStatus.InRepair;
        protected string m_VehicleOwnerName;
        protected string m_VehicleOwnerPhone;
        protected Engine m_Engine;
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels;

        public string ModelName
        {
            set
            {
                m_ModelName = value;
            }

            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            set
            {
                m_LicenseNumber = value;
            }
            get
            {
                return m_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public Engine Engine
        {
            set
            {
                m_Engine = value;
            }
            get
            {
                return m_Engine;
            }
        }

        public eStatus Status
        {
            set
            {
                m_StatusInGarage = value;
            }

            get
            {
                return m_StatusInGarage;
            }
        }

        public string OwnerName
        {
            set
            {
                m_VehicleOwnerName = value;
            }
            get
            {
                return m_VehicleOwnerName;
            }
        }

        public string OwnerPhone
        {
            set
            {
                m_VehicleOwnerPhone = value;
            }
            get
            {
                return m_VehicleOwnerPhone;
            }
        }

        public void InflateTiresToMaximum()
        {
            foreach (Wheel vehicleWheel in m_Wheels)
            {
                vehicleWheel.InflateToMaximum();
            }
        }

        public void SetWheelsCurrentAirPressure(float i_WheelPressure)
        {
            foreach (Wheel vehicleWheel in m_Wheels)
            {
                vehicleWheel.CurrentAirPressure = i_WheelPressure;
            }
        }

        public void SetWheelManufacturer(string i_WheelManufacturer)
        {
            foreach (Wheel vehicleWheel in m_Wheels)
            {
                vehicleWheel.ManufacturerName = i_WheelManufacturer;
            }
        }

        public void SetWheelMaximumAirPressure(float i_WheelPressure)
        {
            foreach (Wheel vehicleWheel in m_Wheels)
            {
                vehicleWheel.MaximumAirPressure = i_WheelPressure;
            }
        }

        public eEngineType GetEngineType()
        {
            return m_Engine.EngineType;
        }

        public string GetBasicDetails()
        {
            string basicDetails;
            basicDetails = String.Format(
                "License number: {0}" + Environment.NewLine +
                "Model name: {1}" + Environment.NewLine +
                "Owner name: {2}" + Environment.NewLine +
                "Status: {3}" + Environment.NewLine +
                "{4}" + Environment.NewLine +
                "{5}" + Environment.NewLine,
                this.m_LicenseNumber, this.m_ModelName, this.m_VehicleOwnerName,
                Enum.GetName(typeof(eStatus), m_StatusInGarage),
                GetWheelsDetails(),
                this.Engine.GetEngineDetails());

            return basicDetails;
        }

        public string[] GetVehiclePropertyNames()
        {
            return v_VehiclePropertyNames;
        }

        public string GetWheelsDetails()
        {
            StringBuilder wheelsDetails = new StringBuilder();

            foreach (Wheel wheel in this.m_Wheels)
            {
                wheelsDetails.Append(String.Format("Wheel number {0}: " + Environment.NewLine, (m_Wheels.IndexOf(wheel) + 1)));
                wheelsDetails.Append(wheel.GetWheelDetails());
            }

            return wheelsDetails.ToString();
        }

        public void SetProperty(string i_FieldToSet, string i_FieldValue)
        {
            //"Vehicle License Number", 
            //"Owner Name",             
            //"Owner Phone",            
            //"Model Name",
            //"Remaining Quantity of Energy Source (Liters for Fuel, Hours for Battery)",
            //"Wheel Manufacturer Name",
            //"Current Pressure In The Vehicle's Wheels"

            int fieldIndexInArray = Array.IndexOf(v_VehiclePropertyNames, i_FieldToSet);

            if (fieldIndexInArray < 0)
            {
                throw new IndexOutOfRangeException("The selected field does not exist");
            }
            else
            {
                switch (fieldIndexInArray)
                {
                    case 0:
                        LicenseNumber = i_FieldValue;
                        break;
                    case 1:
                        OwnerName = i_FieldValue;
                        break;
                    case 2:
                        OwnerPhone = i_FieldValue;
                        break;
                    case 3:
                        ModelName = i_FieldValue;
                        break;
                    case 4:
                        float inputEnergyLevel = float.Parse(i_FieldValue);
                        if (inputEnergyLevel < 0 || inputEnergyLevel > m_Engine.EnergySourceMaximumAmount)
                        {
                            throw new ValueOutOfRangeException(m_Engine.EnergySourceMaximumAmount, 0);
                        }
                        else
                        {
                            m_Engine.EnergySourceAvailableAmount = inputEnergyLevel;
                        }
                        break;
                    case 5:
                        SetWheelManufacturer(i_FieldValue);
                        break;
                    case 6:
                        float inputAirPressure = float.Parse(i_FieldValue);
                        if (inputAirPressure < 0 || inputAirPressure > GetMaximumAirPressure())
                        {
                            throw new ValueOutOfRangeException(GetMaximumAirPressure(), 0);
                        }
                        else
                        {
                            SetWheelsCurrentAirPressure(inputAirPressure);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private float GetMaximumAirPressure()
        {
            return m_Wheels[0].MaximumAirPressure;
        }

        internal abstract string GetDetails();

        public string[] AvailableEngineTypes()
        {
            return m_Engine.AvailableEngineTypes();
        }

        internal abstract void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue);

        internal abstract string[] GetSpecialVehicleParameterNames();
    }
}
