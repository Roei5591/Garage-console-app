using System;

namespace Ex03GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue , float i_MinValue)
            : base(string.Format("Value out of range , the range is between {0} and {1}.",
                 i_MinValue , i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, Exception innerException)
            : base(string.Format("Value out of range , the range is between {0} and {1}.",
                 i_MinValue, i_MaxValue) , innerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
