using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GarageLogic
{
    public class GarageManger
    {
        Dictionary<string, Vehicle> m_GarageDictionary;

        public GarageManger()
        {
            m_GarageDictionary = new Dictionary<string, Vehicle>();
        }

        public bool VehicleExists(string i_curentLicenseNumber)
        {
            bool v_VehicleIsPresentInGarage = false;

            if (this.m_GarageDictionary.ContainsKey(i_curentLicenseNumber))
            {
                v_VehicleIsPresentInGarage = true;
            }

            return v_VehicleIsPresentInGarage;
        }

        public void InsertVehicle(Vehicle i_NewVehicle)
        {
            if (VehicleExists(i_NewVehicle.LicenseNumber))
            {
                this.m_GarageDictionary[i_NewVehicle.LicenseNumber].Status = eStatus.InRepair;
            }
            else
            {
                this.m_GarageDictionary.Add(i_NewVehicle.LicenseNumber, i_NewVehicle);
            }
        }

        public void ChangeVehicleStatus(string i_curentLicenseNumber, eStatus i_newStatus)
        {
            this.m_GarageDictionary[i_curentLicenseNumber].Status = i_newStatus;
        }

        public void InflateTiresToMaximum(string i_curentLicenseNumber)
        {
            this.m_GarageDictionary[i_curentLicenseNumber].InflateTiresToMaximum();
        }

        public void RefuelFuelVehicle(string i_curentLicenseNumber, eFuelType fuelType, float amountToFuel)
        {
            FuelEngine FuelEngineToFill;
            try
            {
                FuelEngineToFill = ((FuelEngine)(m_GarageDictionary[i_curentLicenseNumber].Engine));
            }
                 catch (Exception)
            {
                throw new ArgumentException("Wrong engine type!");
            }

            FuelEngineToFill.ReplenishEnergy(fuelType, amountToFuel);
        }

        public void ChargeElectricBasedVehicle(string i_curentLicenseNumber, float amountToCharge)
        {
            ElectricEngine electricEngineTofill;
            try
            {
                electricEngineTofill = ((ElectricEngine)(m_GarageDictionary[i_curentLicenseNumber].Engine));

            }
            catch(Exception)
            {
                throw new ArgumentException("Wrong engine type!");
            }

            electricEngineTofill.ReplenishEnergy(amountToCharge);
        }

        public string GetLicenseNumbersCurrentlyInTheGarage()
        {
            StringBuilder licenseNumbersList = new StringBuilder();

            foreach (Vehicle vehicle in m_GarageDictionary.Values)
            {
                licenseNumbersList.Append(vehicle.LicenseNumber + Environment.NewLine);
            }

            return licenseNumbersList.ToString();
        }

        public string GetVehicleDetails(string i_curentLicenseNumber)
        {
            return m_GarageDictionary[i_curentLicenseNumber].GetDetails();
        }

        public string GetLicenseNumbersCurrentlyInTheGarage(eStatus i_fillterStatus)
        {
            StringBuilder licenseNumbersList = new StringBuilder();

            foreach (Vehicle vehicle in m_GarageDictionary.Values)
            {
                if (vehicle.Status.Equals(i_fillterStatus))
                {
                    licenseNumbersList.Append(vehicle.LicenseNumber + Environment.NewLine);
                }
            }

            return licenseNumbersList.ToString();
        }


    }
}
