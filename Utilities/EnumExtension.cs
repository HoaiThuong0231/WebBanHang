using System;
using System.ComponentModel;
using System.Reflection;

namespace WebBanHang.Utilities
{
    public static class EnumExtension
    {
        //public static TrackingOrderResponse EnumToStateOrder(this short stateId)
        //{
        //    var state = (StateOrderEnum)Enum.GetValues(typeof(StateOrderEnum)).GetValue(stateId);
        //    string description = state.DescriptionAttr();
        //    return new TrackingOrderResponse
        //    {
        //        Description = description,
        //        State = (short)state
        //    };
        //}
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
