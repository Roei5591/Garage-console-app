using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public class VehicleMaker
    {
        private Vehicle m_CreatedVehicle;

        //To add a new type of vehicle, add to this array of supported presets
        //This class is allowed to know the list of supported vehicles (described in PDF)
        private readonly VehiclePreset[] v_SupportedVehicles =
        {
            new VehiclePreset(
                1,
                "Regular Motorcycle: 2 Wheels, 33 Max PSI, Octane95, 5.5 Liters",
                eVehicleTypes.Motorcycle,
                2,
                33,
                eEngineType.Fuel,
                eFuelType.Octane95,
                5.5f),
            new VehiclePreset(
                2,
                "Electric Motorcycle: 2 Wheels, 33 Max PSI, 2.7 Hours (Battery)",
                eVehicleTypes.Motorcycle,
                2,
                33,
                eEngineType.Electric,
                null,
                2.7f
                ),
            new VehiclePreset(
                3,
                "Regular Car: 4 Wheels, 30 Max PSI, Octane98, 42 Liters",
                eVehicleTypes.Car,
                4,
                30,
                eEngineType.Fuel,
                eFuelType.Octane98,
                42f),
            new VehiclePreset(
                4,
                "Electric Car: 4 Wheels, 30 Max PSI, 2.5 Hours (Battery)",
                eVehicleTypes.Car,
                4,
                30,
                eEngineType.Electric,
                null,
                2.5f),
            new VehiclePreset(
                5,
                "Truck: 12 Wheels, 32 Max PSI, Octane96, 135 Liters",
                eVehicleTypes.Truck,
                12,
                32,
                eEngineType.Fuel,
                eFuelType.Octane96,
                135)
        };

        public string[] GetVehicleOptions()
        {
            string[] options = new string[v_SupportedVehicles.Length];
            for (int i = 0; i < v_SupportedVehicles.Length; i++)
            {
                options[i] = v_SupportedVehicles[i].PresetDrescription;
            }

            return options;
        }

        public void CreateVehicleFromPreset(int i_PresetNumber)
        {
            int selectedPresetInArray = i_PresetNumber - 1;
            VehiclePreset preset = v_SupportedVehicles[selectedPresetInArray];

            switch (preset.VehicleType)
            {
                case eVehicleTypes.Car:
                    m_CreatedVehicle = new Car();
                    break;
                case eVehicleTypes.Motorcycle:
                    m_CreatedVehicle = new Motorcycle();
                    break;
                case eVehicleTypes.Truck:
                    m_CreatedVehicle = new Truck();
                    break;
                default:
                    m_CreatedVehicle = new CustomVehicle();
                    break;
            }

            InstallEngine(preset.EngineType, preset.FuelType, preset.EngineMaxEnergy);
            InstallWheels(preset.NumberOfWheels, preset.WheelsMaxPressure);
        }

        public void InstallWheels(int i_NumberOfWheels, float i_WheelsMaxPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel();
                wheel.MaximumAirPressure = i_WheelsMaxPressure;
                wheels.Add(wheel);
            }

            m_CreatedVehicle.Wheels = wheels;
        }

        public string[] GetCommonVehiclePropertyNames()
        {
            return m_CreatedVehicle.GetVehiclePropertyNames();
        }

        public void SetCommonVehicleProperty(string i_FieldToSet, string i_FieldValue)
        {
            m_CreatedVehicle.SetProperty(i_FieldToSet, i_FieldValue);
        }

        void InstallEngine(eEngineType i_EngineType, eFuelType? i_FuelType, float i_EngineMaxEnergy)
        {
            Engine engine;

            if (i_EngineType == eEngineType.Fuel)
            {
                engine = new FuelEngine((eFuelType)i_FuelType);
            }
            else
            {
                engine = new ElectricEngine();
            }

            engine.EnergySourceMaximumAmount = i_EngineMaxEnergy;

            m_CreatedVehicle.Engine = engine;
        }

        public void SetEngineEnergySourceCurrentLevel(float i_Value)
        {
            m_CreatedVehicle.Engine.EnergySourceAvailableAmount = i_Value;
        }

        public string[] GetSpecialVehicleParameterNames()
        {
            return m_CreatedVehicle.GetSpecialVehicleParameterNames();
        }

        public void SetSpecialVehicleParameter(string i_ParameterName, string i_ParameterValue)
        {
            m_CreatedVehicle.SetSpecialVehicleParameter(i_ParameterName, i_ParameterValue);
        }

        public Vehicle FinalizeVehicle()
        {
            return m_CreatedVehicle;
        }
    }
}
