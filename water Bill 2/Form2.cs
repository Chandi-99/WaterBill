using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace water_Bill_2
{
    public partial class Form2 : Form
    {
        public Form2(string month, string[] customerNames, int[] units)
        {
            InitializeComponent();
            CenterToParent();
            for (int i = 0; i < customerNames.Length; i++)
            {
                double usageCharge = findUsageCharge(units[i]);
                double serviceCharge = findServiceCharge(units[i]);

                dgv_display.Rows.Add(month, customerNames[i],
                    units[i].ToString(), usageCharge.ToString(),
                    serviceCharge.ToString(), (usageCharge + serviceCharge).ToString());
            }
        }
        public double findUsageCharge(int unit)
        {
            int totalCharge = 0;

            int[] rates = { 12, 16, 20, 40, 58, 88, 105, 120, 130, 140 };

            int currentRateIndex = 0;

            while (unit > 0)
            {
                if (unit > 0 && (unit - 5) >= 0)
                {
                    totalCharge += (rates[currentRateIndex] * 5);
                    unit -= 5;
                }
                else if (unit > 0 && (unit - 5) < 0)
                {
                    totalCharge += (rates[currentRateIndex] * unit);
                    unit -= unit;
                    break;
                }

                currentRateIndex++;
            }

            return totalCharge;
        }
        public double findServiceCharge(int unit)
        {
            double serviceCharge = 0;

            if (unit > 75)
                serviceCharge = 1600.0;
            else if (unit >= 51)
                serviceCharge = 1000.0;
            else if (unit >= 41)
                serviceCharge = 650.0;
            else if (unit >= 31)
                serviceCharge = 400.0;
            else if (unit >= 26)
                serviceCharge = 200.0;
            else if (unit >= 21)
                serviceCharge = 100.0;
            else if (unit >= 16)
                serviceCharge = 80.0;
            else if (unit >= 11)
                serviceCharge = 70.0;
            else if (unit >= 6)
                serviceCharge = 65.0;
            else if (unit >= 0)
                serviceCharge = 50.0;
            else
                serviceCharge = 0.0;

            return serviceCharge;
        }
    }  


}

