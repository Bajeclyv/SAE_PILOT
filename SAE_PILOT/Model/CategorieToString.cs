using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static System.Net.Mime.MediaTypeNames;

namespace SAE_PILOT.Model
{
    public class CategorieToString : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            String text = "Valeur invalide";
            if (value is CategorieProduit cat)
            {
                switch (cat)
                {
                    case CategorieProduit.Ecole: text = "école"; break;
                    case CategorieProduit.Loisir: text = "loisir"; break;
                    case CategorieProduit.Bureau: text = "bureau"; break;
                    case CategorieProduit.HauteEcriture: text = "haute écriture"; break;
                }
            }
            return text;
        }

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is string text)
        //    {
        //        switch (text)
        //        {
        //            case CategorieProduit.Ecole: text = "école"; break;
        //            case CategorieProduit.Loisir: text = "loisir"; break;
        //            case CategorieProduit.Bureau: text = "bureau"; break;
        //            case CategorieProduit.HauteEcriture: text = "haute écriture"; break;
        //        }
        //    }
        //    return text;
        //}

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
