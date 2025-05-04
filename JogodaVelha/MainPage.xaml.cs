namespace JogodaVelha
{
    public partial class MainPage : ContentPage
    {
     
        string jogador = "x";
        private string[,] mat = new string[3,3];//A virgula no primeiro colchete indica que são duas dimensões

        public int VerificaGanhador(string[,] mat, string jogador)
        {
            if (mat[0,0] == jogador && mat[0,1] == jogador && mat[0,2] == jogador
             || mat[1,0] == jogador && mat[1,1] == jogador && mat[1,2] == jogador
             || mat[2,0] == jogador && mat[2,1] == jogador && mat[2,2] == jogador
             || mat[0,0] == jogador && mat[1,0] == jogador && mat[2,0] == jogador
             || mat[0,1] == jogador && mat[1,1] == jogador && mat[2,1] == jogador
             || mat[0,2] == jogador && mat[1,2] == jogador && mat[2,2] == jogador
             || mat[0,2] == jogador && mat[1,1] == jogador && mat[2,0] == jogador
             || mat[0,0] == jogador && mat[1,1] == jogador && mat[2,2] == jogador
            )
            {
                return 1;

            }

            return 0;
        }

        public int VerificaEmpate(string[,] mat)
        {
            if (mat[0,0] != null && mat[0,1] != null && mat[0,2] != null && 
                mat[1,0] != null && mat[1,1] != null && mat[1,2] != null &&
                mat[2,0] != null && mat[2,1] != null && mat[2,2] != null)
            {
                return 1;
            }

            return 0;
        }

        
        public MainPage()
        {
            InitializeComponent();
        }

        public void reiniciaTab()
        {
            
            foreach (var child in Tabuleiro.Children)//Loop para percorrer todos os itens do grid(matriz)
            {
                if (child is Button b)//Verifica se o elemento encontrado é um butão
                {
                    int linha = Grid.GetRow(b);//Pega a linha
                    int coluna = Grid.GetColumn(b);//Pega a coluna
                    b.Text = (linha * 3 + coluna + 1).ToString();//Transforma o numero(resultado da formula) em texto
                    //Coloca os textos dos botôes usando numeros de 1-9, igual coloquei no inicio
                    //Fórmula --> linha*3 + coluna + 1
                    //Na prática --> linha 0, coluna 0 -> (0+3)+0+1 = 1
                    //               linha 0, coluna 1 -> (0+3)+1+1 = 2
                }

            }
            mat = new string[3, 3];
        }

        private void OnClicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;//Deu um o nome b para o botão
            if (b.Text != "x" && b.Text != "o" && b.Text != "0")
            {
                
                switch (b.Text)
                {
                    case "1":
                        mat[0, 0] = jogador;

                        break;
                    case "2":
                        mat[0, 1] = jogador;
                        break;
                    case "3":
                        mat[0, 2] = jogador;
                        break;
                    case "4":
                        mat[1, 0] = jogador;
                        break;
                    case "5":
                        mat[1, 1] = jogador;
                        break;
                    case "6":
                        mat[1, 2] = jogador;
                        break;
                    case "7":
                        mat[2, 0] = jogador;
                        break;
                    case "8":
                        mat[2, 1] = jogador;
                        break;
                    case "9":
                        mat[2, 2] = jogador;
                        break;

                }
               
                b.Text = jogador;//Botão b recebeu o "valor" de jogador depois de verificar se Text era algum dos valores de 1 a 9
            }

            if (VerificaGanhador(mat, jogador) == 1)
            {
                DisplayAlert("Vitoria!!!", $"Jogador {jogador} venceu.", "OK"); //Precisa de titulo, Mensagem e um botão de OK
                reiniciaTab();
            }
            else if (VerificaEmpate(mat) == 1)
            {
                DisplayAlert("EMPATE!!!", "Ninguém levou essa!", "OK");

            }


            if (jogador == "x")
            {
                jogador = "o";
            }
            else
            {
                jogador = "x";
            }
        }
    }

}
