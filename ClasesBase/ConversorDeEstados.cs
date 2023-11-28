using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ClasesBase
{
    public class ConversorDeEstados : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null){
                string valor = value.ToString();
                int num = int.Parse(valor);
                //if (value is int)
                //{
                    if (num == 0)
                    {
                        return new SolidColorBrush(Colors.Green);
                    }
                    else if (num > 0 && num <= 30){
                        return new SolidColorBrush(Colors.LightPink);
                    }
                    else if (num > 30 && num <= 60)
                    {
                        return new SolidColorBrush(Colors.Red);
                    }
                    else{
                        return new SolidColorBrush(Colors.DarkRed);
                    }
               }
               return new SolidColorBrush(Colors.White);
        }
            //throw new NotImplementedException();
      //}
            

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
