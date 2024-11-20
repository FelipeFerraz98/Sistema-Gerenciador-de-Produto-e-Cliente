using System.Windows.Forms;

public static class FormManager
{
    // Método para trocar de formulários com Dispose no anterior
    public static void SwitchForm(Form currentForm, Form newForm)
    {
        if (currentForm != null && currentForm.Visible)
        {
            currentForm.Hide(); // Esconde o formulário atual
        }

        // Exibe o novo formulário
        newForm.Show();
    }
}