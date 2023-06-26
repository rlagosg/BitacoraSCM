using System;
using System.Windows.Forms;
using Guna.UI.WinForms;

public class CustomGunaDateTimePicker : GunaDateTimePicker
{
    private const int WM_LBUTTONDOWN = 0x0201;
    private const int WM_LBUTTONUP = 0x0202;
    private const int WM_LBUTTONDBLCLK = 0x0203;

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_LBUTTONDOWN ||
            m.Msg == WM_LBUTTONUP ||
            m.Msg == WM_LBUTTONDBLCLK)
        {
            return; // Ignorar los mensajes de clic del mouse
        }

        base.WndProc(ref m);
    }
}
