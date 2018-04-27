using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PlanerAkademia
{
    /// <summary>
    /// Base Value Converter
    /// </summary>
    /// <typeparam name="T">Type of value to convert</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region PrivateInstance

        /// <summary>
        /// Instance of this converter
        /// </summary>
        private static T Converter = null;

        #endregion

        #region InstanceProvider

        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">Provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ?? (Converter = new T());
        }

        #endregion

        #region ConverterMethods

        /// <summary>
        /// The method to convert one value type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert value type back to it's first type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
