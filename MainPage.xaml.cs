using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace cheque_writer_graphical
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static string my_num;
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void convert_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ch_rial.IsChecked == true)
            {
                my_num = num_input.Text;
                try
                {
                    if (my_num.Contains('.'))
                    {
                        op_number.Text = my_num;
                        string myNum_float = my_num.Substring((my_num.IndexOf('.') + 1), 2);
                        my_num = my_num.Substring(0, my_num.IndexOf('.'));
                        if (my_num == "0")
                        {
                            output.Text = (Rial.NumToArray(myNum_float) + " ریال");
                        }
                        else
                        {
                            output.Text = (Rial.NumToArray(my_num) + " تومان و ") + (Rial.NumToArray(myNum_float) + " ریال");
                        }
                    }
                    else
                    {
                        if (my_num == "0")
                        {
                            op_number.Text = my_num;
                            output.Text = "صفر";
                        }
                        else
                        {
                            my_num = my_num.TrimStart('0');
                            op_number.Text = my_num;
                            output.Text = Rial.NumToArray(my_num) + " تومان";
                        }
                    }
                }
                catch
                {
                    op_number.Text = "";
                    output.Text = "عبارت وارد شده اشتباه است. دوباره تلاش کنید";
                }
            }

            try
            {
                if (ch_dollar.IsChecked == true)
                {
                    my_num = num_input.Text;
                    if (my_num.Contains('.'))
                    {
                        op_number.Text = my_num;
                        string myNum_float = my_num.Substring((my_num.IndexOf('.') + 1), 2);
                        my_num = my_num.Substring(0, my_num.IndexOf('.'));
                        if (my_num == "0")
                        {
                            output.Text = (Dollar.NumToArray(myNum_float) + " cent");
                        }
                        else
                        {
                            output.Text = (Dollar.NumToArray(my_num) + " dollar and ") + (Dollar.NumToArray(myNum_float) + " cent");
                        }
                    }
                    else
                    {
                        if (my_num == "0")
                        {
                            op_number.Text = my_num;
                            output.Text = "zero";
                        }
                        else
                        {
                            my_num = my_num.TrimStart('0');
                            op_number.Text = my_num;
                            output.Text = Dollar.NumToArray(my_num) + " dollar";
                        }
                    }
                }
            }
            catch
            {
                op_number.Text = "";
                output.Text = "Your input is incorrect. please enter a valid number";
            }
        }
    }
}