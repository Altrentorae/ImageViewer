using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer {
    public partial class FindBoxForm : Form {
        public FindBoxForm() {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void button_Find_Click(object sender, EventArgs e) {
            MainForm owner = (MainForm)Owner;
            if (!Int32.TryParse(textBox1.Text, out int idx)) { Close(); };
            owner.GotoIndex_Return(idx-1);
            Close();
        }

        private void ControlKeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter: button_Find.PerformClick(); break;
            }
        }

        private void FindBoxForm_Load(object sender, EventArgs e) {
            textBox1.Focus();
        }
    }
}
