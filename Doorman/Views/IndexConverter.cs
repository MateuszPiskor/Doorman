
using System;
using System.Windows.Controls;

namespace Doorman.Views
{
    public class IndexConverter
    {
        public object Convert(object value, Type TargetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Get the ListViewItem from Value remember we deleted Path, so the value is an object of ListViewItem and not Person
            ListViewItem lvi = (ListViewItem)value;
            //Get lvi's container (listview)
            ListView listView = ItemsControl.ItemsControlFromItemContainer(lvi) as ListView;

            //Find out the position for the Person obj in the ListView
            //we can get the Person object from lvi.Content
            // Of course you can do as in the accepted answer instead!
            // I just think this is easier to understand for a beginner.
            int index = listView.Items.IndexOf(lvi.Content);

            //Convert your XML parameter value of 1 to an int.
            int startingIndex = System.Convert.ToInt32(parameter);

            return index + startingIndex;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
