using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prince_of_Persia_SOT
{
    public partial class TrainerInstructions : Form
    {
        static TrainerInstructions new_msgbox;
        static string Button_id;
        public TrainerInstructions()
        {
            InitializeComponent();
        }

        public static string ShowBox(string txtMessage)
        {
            new_msgbox = new TrainerInstructions();
            new_msgbox.label1.Text = txtMessage;
            new_msgbox.ShowDialog();
            return Button_id;
        }

        public static string ShowBox(string txtMessage, string txtTitle)
        {
            new_msgbox = new TrainerInstructions();
            new_msgbox.label1.Text = txtMessage;
            new_msgbox.Text = txtTitle;
            new_msgbox.ShowDialog();
            return Button_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_id = "1";
            new_msgbox.Dispose();
        }
    }
}
