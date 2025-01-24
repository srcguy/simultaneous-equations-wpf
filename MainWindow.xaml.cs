using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uklad_rownan
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Calc(object sender, RoutedEventArgs e)
        {
            double W = (Convert.ToDouble(x1.Text) * Convert.ToDouble(y2.Text)) - (Convert.ToDouble(x2.Text) * Convert.ToDouble(y1.Text));
            double Wx = (Convert.ToDouble(q1.Text) * Convert.ToDouble(y2.Text)) - (Convert.ToDouble(q2.Text) * Convert.ToDouble(y1.Text));
            double Wy = (Convert.ToDouble(x1.Text) * Convert.ToDouble(q2.Text)) - (Convert.ToDouble(x2.Text) * Convert.ToDouble(q1.Text));

            double x = Wx / W;
            if (x == -0)
            {
                x = 0;
            }
            double y = Wy / W;
            if (y == -0)
            {
                y = 0;
            }

            string x_str = x.ToString("G2", CultureInfo.InvariantCulture);
            string y_str = y.ToString("G2", CultureInfo.InvariantCulture);

            string y1_str = Convert.ToString(y1.Text);
            string y2_str = Convert.ToString(y2.Text);
            string x1_str = Convert.ToString(x1.Text);
            string x2_str = Convert.ToString(x2.Text);
            string q2_str = Convert.ToString(q2.Text);
            string q1_str = Convert.ToString(q1.Text);

            if (x < 0)
            {
                x_str = "(" + Convert.ToString(x) + ")";
            }

            if (y < 0)
            {
                y_str = "(" + Convert.ToString(y) + ")";
            }

            if (Convert.ToDouble(y1.Text) < 0)
            {
                y1_str = "(" + Convert.ToString(y1.Text) + ")";
            }

            if (Convert.ToDouble(y2.Text) < 0)
            {
                y2_str = "(" + Convert.ToString(y2.Text) + ")";
            }

            if (Convert.ToDouble(x1.Text) < 0)
            {
                x2_str = "(" + Convert.ToString(x1.Text) + ")";
            }

            if (Convert.ToDouble(x2.Text) < 0)
            {
                x2_str = "(" + Convert.ToString(x2.Text) + ")";
            }

            if (Convert.ToDouble(q2.Text) < 0)
            {
                q2_str = "(" + Convert.ToString(q2.Text) + ")";
            }

            if (Convert.ToDouble(q1.Text) < 0)
            {
                q1_str = "(" + Convert.ToString(q1.Text) + ")";
            }

            if (W == 0 && (Wx != 0 || Wy != 0))
            {
                wynikx.Content = "Układ sprzeczny";
                wyniky.Content = "Układ sprzeczny";

                wynikx.Foreground = new SolidColorBrush(Colors.Red);
                wyniky.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (Double.IsNaN(x) && Double.IsNaN(y))
            {
                wynikx.Content = "Układ nieoznaczony";
                wyniky.Content = "Układ nieoznaczony";

                wynikx.Foreground = new SolidColorBrush(Colors.Red);
                wyniky.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                wynikx.Content = "x= " + x.ToString("G2", CultureInfo.InvariantCulture);
                wyniky.Content = "y= " + y.ToString("G2", CultureInfo.InvariantCulture);

                wynikx.Foreground = new SolidColorBrush(Colors.White);
                wyniky.Foreground = new SolidColorBrush(Colors.White);
            }

            obliczenia1.Content =
                "W = " + x1_str + "*" + y2_str + "-" + x2_str + "*" + y1_str + " = " + Convert.ToString(W) + "\n" +
                "Wx = " + q1_str + "*" + y2_str + "-" + q2_str + "*" + y1_str + " = " + Convert.ToString(Wx) + "\n" +
                "Wy = " + x1_str + "*" + q2_str + "-" + x2_str + "*" + q1_str + " = " + Convert.ToString(Wy) + "\n";
            obliczenia2.Content = 
                "x = " + "Wx / W = " + x.ToString("G2", CultureInfo.InvariantCulture) + "\n" +
                "y =" +"Wy / W = " + y.ToString("G2", CultureInfo.InvariantCulture);
        }
    }
}