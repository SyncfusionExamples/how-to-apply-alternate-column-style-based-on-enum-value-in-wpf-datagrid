using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Data;

namespace SfDataGridDemo
{
    public class DataGridCellContentToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //get the GridCell proeprty 
            var cell = values[0] as GridCell;

            //get the columnIndex value  
            var columnIndex = (int)values[1];

            //get the rowIndex value  
            var rowIndex = (int)values[2];

            //get the SfDataGrid 
            var dataGrid = values[3] as SfDataGrid;

            //Returns start column index of the VisibleColumn. 
            var startIndex = dataGrid.ResolveToStartColumnIndex();
            columnIndex = columnIndex - startIndex;

            // Get the resolved current record index  
            var recordIndex = dataGrid.ResolveToRecordIndex(rowIndex);

            object data = null;
            if (values[0] != null && values[1] != null)
            {
                //check if datagrid grouped or not 
                if (dataGrid.View.TopLevelGroup != null)
                {
                    // Get the current row record while grouping 
                    var record = dataGrid.View.TopLevelGroup.DisplayElements[recordIndex];

                    if (!record.IsRecords) //skips caption summary, group summary rows 
                        return DependencyProperty.UnsetValue;

                    var dataCell = (record as RecordEntry).Data;

                    data = (dataCell as DataRowView).Row.ItemArray[columnIndex];
                }
                else
                {
                    data = (cell.DataContext as DataRowView).Row.ItemArray[columnIndex];
                }

                //type case to get the comparison enum value                 
                var employeeComparison = (data as Employee).ComparisonState;

                if (employeeComparison == ComparisonStateEnum.DIFFERENT)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if (employeeComparison == ComparisonStateEnum.EQUAL)
                {
                    return new SolidColorBrush(Colors.Blue);
                }
                else
                    return DependencyProperty.UnsetValue;

            }
            return DependencyProperty.UnsetValue;

        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
