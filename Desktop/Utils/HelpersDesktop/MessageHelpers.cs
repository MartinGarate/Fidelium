using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Utils.HelpersDesktop
{
    public static class MessageHelpers
    {
        public static DialogResult ShowError(string message) =>
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static DialogResult ShowSuccess(string message) =>
            MessageBox.Show(message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static DialogResult ShowWarning(string message) =>
            MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static DialogResult ShowConfirmation(string message, string title) =>
            MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}