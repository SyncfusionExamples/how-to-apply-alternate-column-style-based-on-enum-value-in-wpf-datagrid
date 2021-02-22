#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    class GridViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            this.EmployeeDetails = this.GetEmployeeDetails();
        }
        #endregion       

        #region Properties

        private DataTable _employeeDetails;

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public DataTable EmployeeDetails
        {
            get { return _employeeDetails; }
            set { _employeeDetails = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeeDetails()
        {
            DataTable employeeTable = new DataTable();

            int maxEmployeeCount = 30;
            int maxEmployeeAttrCount = 50;

            for (int count = 0; count <= maxEmployeeCount; count++)
            {
                employeeTable.Columns.Add($"Employee {count}", typeof(Employee));
            }

            for (int employeeAttrCount = 1; employeeAttrCount <= maxEmployeeAttrCount; employeeAttrCount++)
            {
                DataRow newRow = employeeTable.NewRow();

                int emplyeeCount = 0;

                for (int columnIndex = 0; columnIndex <= maxEmployeeCount; columnIndex++)
                {
                    emplyeeCount++;
                    Employee employee = new Employee();

                    employee.EmployeeInfo = $"Emplyee {emplyeeCount} - Attribute {employeeAttrCount}";

                    if (columnIndex % 2 == 0)
                    {
                        employee.ComparisonState = ComparisonStateEnum.EQUAL;
                    }
                    else
                    {
                        employee.ComparisonState = ComparisonStateEnum.DIFFERENT;
                    }

                    newRow[columnIndex] = employee;
                }

                employeeTable.Rows.Add(newRow);
            }

            return employeeTable;
        }
        #endregion
    }
}
