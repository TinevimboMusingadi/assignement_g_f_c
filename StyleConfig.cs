using System.Drawing;
using System.Windows.Forms;

namespace Assignment
{
    public static class StyleConfig
    {
        // Colors
        public static Color PrimaryBlue = Color.FromArgb(0, 122, 204); // VS Blue
        public static Color DarkBlue = Color.FromArgb(16, 24, 48);
        public static Color BackgroundColor = Color.FromArgb(240, 245, 250);
        public static Color TextColor = Color.FromArgb(30, 30, 30);
        public static Color White = Color.White;

        // Fonts
        public static Font TitleFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static Font NormalFont = new Font("Segoe UI", 10F);

        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = NormalFont;
            form.ForeColor = TextColor;
        }

        public static void ApplyButtonStyle(Button btn, bool isPrimary = true)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = isPrimary ? PrimaryBlue : Color.LightGray;
            btn.ForeColor = isPrimary ? White : TextColor;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        public static void ApplyLabelStyle(Label lbl, bool isHeader = false)
        {
            lbl.Font = isHeader ? HeaderFont : NormalFont;
            lbl.ForeColor = isHeader ? DarkBlue : TextColor;
        }
    }
}
