namespace Ex03GarageLogic
{
    public struct VehiclePreset
    {

        private int m_PresetNumber;  
        private string m_PresetDescription;
        private eVehicleTypes m_VehicleType;
        private int m_NumberOfWheels;
        private float  m_WheelsMaxPressure;
        private eEngineType m_EngineType;
        private eFuelType? m_FuelType;
        private float m_EngineMaxEnergy;

        public eVehicleTypes VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public int NumberOfWheels
        {
            get { return m_NumberOfWheels; }
            set { m_NumberOfWheels = value; }
        }

        public int PresetNumber
        {
            get { return m_PresetNumber; }
            set { m_PresetNumber = value; }
        }

        public string PresetDrescription
        {
            get { return m_PresetDescription; }
            set { m_PresetDescription = value; }
        }

        public float WheelsMaxPressure
        {
            get { return m_WheelsMaxPressure; }
            set { m_WheelsMaxPressure = value; }
        }
        
        public eEngineType EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }
        }

        public eFuelType? FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public float EngineMaxEnergy
        {
            get { return m_EngineMaxEnergy; }
            set { m_EngineMaxEnergy = value; }
        }

        public VehiclePreset(
            int i_PresetNumber,
            string i_PresetDescription,
            eVehicleTypes i_VehicleType,
            int i_NumberOfWheels,
            float i_WheelsMaxPressure,
            eEngineType i_EngineType,
            eFuelType? i_FuelType,
            float i_EngineMaxEnergy
            )
        {
            m_PresetNumber = i_PresetNumber;
            m_PresetDescription = i_PresetDescription;
            m_VehicleType = i_VehicleType;
            m_EngineType = i_EngineType;
            m_FuelType = i_FuelType;
            m_EngineMaxEnergy = i_EngineMaxEnergy;
            m_NumberOfWheels = i_NumberOfWheels;
            m_WheelsMaxPressure = i_WheelsMaxPressure;
        }
    }
}
