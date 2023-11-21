﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace HardwareStore.Components.PartialClass
{
    public partial class Service
    {
        public decimal TotalCost
        {
            get
            {
                if (Discount != 0)
                    return Cost - (Cost * (decimal)Discount / 100);
                else
                    return Cost;
            }

        }
        public string CostTime
        {
            get
            {
                if (Discount == 0)
                    return $" {Cost:0} рублей за {DurationInSeconds / 60} минут";
                else
                    return $" {Cost - (Cost * (decimal)Discount / 100):0} рублей за {DurationInSeconds / 60} минут";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string DiscountStr
        {
            get
            {
                if (Discount == 0)
                    return null;
                else
                    return $"* скидка {Discount}%";

            }

        }

        public Brush DiscountBrush
        {
            get
            {
                if (Discount != 0)
                    return new SolidColorBrush(Colors.LightGreen);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }

        public int Discount { get; private set; }
        public int Cost { get; private set; }
        public int DurationInSeconds { get; private set; }
    }
}


