namespace CalculatorMobile
{
    public partial class MainPage : ContentPage
    {
        char[,] caractere;

        public MainPage()
        {
            InitializeComponent();

            Initialise();

        }

        public void Initialise()
        {
            string[,] caractere = {
            { "C", "+/-", "%", "/" },
            { "7", "8", "9", "*" },
            { "4", "5", "6", "-" },
            { "1", "2", "3", "+" },
            { ".", "0", "R", "=" }
        };

            int row = grid.RowDefinitions.Count;
            int col = grid.ColumnDefinitions.Count;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Button button = new Button();
                    button.Text = caractere[i, j]; ;
                    button.FontSize = 25;
                    button.FontAttributes = FontAttributes.Bold;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    if(i == 0 || j == col - 1)
                    {
                        button.TextColor = Color.FromHex("1ec9d8");
                    }
                    if (caractere[i, j].Equals("="))
                    {
                        button.BackgroundColor = Color.FromHex("1ec9d8");
                        button.TextColor = Colors.White;
                    }
                    button.Command = new Command(() =>
                    {
                        if (button.Text.Equals("="))
                        {
                            result.Text = $"={Evaluate(lbl.Text)}";
                        }
                        else
                        {
                            lbl.Text += button.Text;
                        }
                        if (button.Text.Equals("C"))
                        {
                            lbl.Text = "";
                        }
                    });
                    grid.Children.Add(button);
                }
            }
        }

        private double Evaluate(string expression)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expression, string.Empty));
        }
    }
}