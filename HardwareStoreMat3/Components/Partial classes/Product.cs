﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareStoreMat3.Components
{
    public partial class Product
    {
        public string CostWithDiscount
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost: 0.00} р.";
                else
                    return $"{(Cost - Cost * (decimal)Discount): 0.00} р.";
            }
        }

        public Visibility CostVisiblity
        {
            get
            {
                if (Discount == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public string TextDiscount
        {
            get
            {
                if (Discount == 0)
                    return null;
                else
                    return $"* скидка {Discount * 100}%";
            }
        }

        public double AvgOcenka
        {
            get
            {
                var feedBacks = App.db.Feedback.Where(x => x.ProductId == Id).ToList();
                double sum = 0;
                int i = 0;
                foreach (var feedback in feedBacks)
                {
                    sum += feedback.Evaluation;
                    i++;
                }
                if (i == 0)
                    return 0;
                else
                    return sum / i;
            }
        }

        public int KolvoOtziv
        {
            get
            {
                return App.db.Feedback.Where(x => x.ProductId == Id).Count();
            }
        }
    }
}
