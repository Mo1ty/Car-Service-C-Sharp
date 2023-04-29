using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace CarServiceApp.Pages.Amination
{
    public static class Animation
    {
        public static void AnimateLabel(Label label)
        {
            label.Visibility = Visibility.Visible;
            DoubleAnimation blinkAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new TimeSpan(0, 0, 0, 0, 500),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };

            label.BeginAnimation(Label.OpacityProperty, blinkAnimation);
        }
    }
}
