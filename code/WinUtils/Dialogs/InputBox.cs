using System;
using System.Windows.Forms;
using System.Drawing;

namespace WinUtils.Dialogs
{
    public class InputBox
    {
        public static string Show(string title, string promptText, string defValue = "")
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button button = new Button();
            Button button2 = new Button();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = defValue;
            button.Text = "OK";
            button2.Text = "Cancel";
            button.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            button.SetBounds(228, 72, 75, 23);
            button2.SetBounds(309, 72, 75, 23);
            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            button.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            button2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[]
            {
        label,
        textBox,
        button,
        button2
            });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = button;
            form.CancelButton = button2;
            DialogResult result = form.ShowDialog();
            return result == DialogResult.Cancel ? null : textBox.Text;
        }
    }

    

}