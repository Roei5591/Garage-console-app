using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03GarageLogic
{
    public abstract class Engine
    {
        private eEngineType m_EngineType;
        private float m_EnergySourceMaximumAmount;
        private float m_EnergySourceAvailableAmount;

        public eEngineType EngineType
            {
                set
                {
                    m_EngineType = value;
                }
                get
                {
                    return m_EngineType;
                }
            }

        public float EnergySourceAvailableAmount
        {
            set
            {
                m_EnergySourceAvailableAmount = value;
            }
            get
            {
                return m_EnergySourceAvailableAmount;
            }
        }

        public float EnergySourceMaximumAmount
        {
            set
            {
                m_EnergySourceMaximumAmount = value;
            }
            get
            {
                return m_EnergySourceMaximumAmount;
            }
        }

        private string[] m_AvailableEngineTypes =
        {
            "Fuel",
            "Electric"
        };

        protected bool AddedEnergyDoesntExceedMaximum(float i_EnergyToAdd)
        {
            return (m_EnergySourceAvailableAmount + i_EnergyToAdd <= m_EnergySourceMaximumAmount);
        }

        public string[] AvailableEngineTypes()
        {
            return m_AvailableEngineTypes;
        }

        internal abstract string GetEngineDetails();
    }
}
