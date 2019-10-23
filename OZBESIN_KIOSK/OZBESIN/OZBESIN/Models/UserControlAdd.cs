using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OZBESIN.Models
{
    public class UserControlAdd
    {
        public static void Uc_Add(Grid grid, UserControl user)
        {
            if (grid.Children.Count > 0)
            {
                grid.Children.Clear();
                grid.Children.Add(user);
            }
            else
            {
                
                grid.Children.Add(user);
            }
        }
    }
}
