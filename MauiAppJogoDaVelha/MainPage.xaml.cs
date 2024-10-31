using Microsoft.Maui.Controls.Handlers;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //TypeCast = Atribui a categoria button a um object (genérico)
            Button btn = (Button)sender;

            if (vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }
            CheckResult();           
        }//FECHA MÉTODO BUTTON CLICKED

        private void CheckResult()
        {
            string[,] tabuleiro = new string[3, 3];
            int child = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = ((Button)GridMenu.Children[child]).Text;
                    child++;
                }           
            }
            //VERIFICA LINHAS
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[i, 0]) && tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 0] == tabuleiro[i, 2])
                {
                    DisplayAlert("Parabéns!", $"{tabuleiro[i,0]} venceu!", "OK");
                    ResetGame();
                }
            }
            //VERIFICA COLUNAS
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[0,i]) && tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[0, i] == tabuleiro[2, i])
                {
                    DisplayAlert("Parabéns!", $"{tabuleiro[0, i]} venceu!", "OK");
                    ResetGame();
                }
            }
            //VERIFICA DIAGONAIS
            if (!string.IsNullOrEmpty(tabuleiro[0, 0]) && tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[0, 0] == tabuleiro[2, 2])
            {
                DisplayAlert("Parabéns!", $"{tabuleiro[0, 0]} venceu!", "OK");
                ResetGame();
            }
            if (!string.IsNullOrEmpty(tabuleiro[0, 2]) && tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[0, 2] == tabuleiro[2, 0])
            {
                DisplayAlert("Parabéns!", $"{tabuleiro[0, 2]} venceu!", "OK");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            foreach (var control in GridMenu.Children)
            {
                if (control is Button btn)
                {
                    btn.Text = "";
                    btn.IsEnabled = true;
                }
            }
            vez = "X";
        }//FECHA MÉTODO RESET GAME
    }//FECHA CLASSE MAIN PAGE
}//FECHA NAMESPACE
