using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowsAppUI
{
    public partial class GameForm : Form
    {
        public event Action<Button> ButtonClicked;

        private readonly int r_BoardRows;
        private readonly int r_BoardCols;
        private readonly eGameMode r_GameMode;
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private Button[,] m_MatrixOfButtons;

        public GameForm(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            InitializeComponent();
            r_FirstPlayer = i_Player1;
            r_SecondPlayer = i_Player2;
            r_BoardRows = i_BoardRows;
            r_BoardCols = i_BoardCols;
            r_GameMode = i_GameMode;
            m_CurrentPlayer.Text = string.Format("Current Player: {0}", r_FirstPlayer.PlayerName);
            m_FirstPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_FirstPlayer.PlayerName, r_FirstPlayer.PlayerScore);
            m_SecondPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_SecondPlayer.PlayerName, r_SecondPlayer.PlayerScore);
            m_MatrixOfButtons = new Button[r_BoardRows, r_BoardCols];
            createButtonsOnGameBoard();
        }

        internal Button[,] MatrixOfButtons
        {
            get { return m_MatrixOfButtons; }
        }

        internal Label FirstPlayerLabel
        {
            get { return m_FirstPlayerName; }
        }

        internal Label SecondPlayerLabel
        {
            get { return m_SecondPlayerName; }
        }

        private void createButtonsOnGameBoard()
        {
            Button currentButton;
            int topPosition = 25;
            int leftPosition = 25;
            int addSpacingTop = 120;
            int addSpacingLeft = 120;

            for (int i = 0; i < r_BoardRows; i++)
            {
                for (int j = 0; j < r_BoardCols; j++)
                {
                    currentButton = new Button
                    {
                        Name = i + "," + j,
                        Width = 100,
                        Height = 100,
                        BackColor = Color.LightGray,
                        Location = new Point(leftPosition, topPosition),
                        Visible = true,
                        Margin = new Padding(15, 15, 25, 15),
                    };

                    currentButton.Click += CurrentCard_Click;
                    Controls.Add(currentButton);
                    m_MatrixOfButtons[i, j] = currentButton;
                    leftPosition += addSpacingLeft;
                }

                leftPosition = 25;
                topPosition += addSpacingTop;
            }

            m_CurrentPlayer.Top = topPosition + 15;
            m_FirstPlayerName.Top = topPosition + 50;
            m_SecondPlayerName.Top = topPosition + 85;
            m_SecondPlayerName.Margin = new Padding(0, 0, 0, 25);
        }

        internal void CurrentCard_Click(object sender, EventArgs e)
        {
            OnClickCard(sender, e);
        }

        protected virtual void OnClickCard(object sender, EventArgs e)
        {
            if (Enabled && sender is Button)
            {
                ButtonClicked?.Invoke(sender as Button);
            }
        }

        internal void UpdateCurrentPlayer(string i_PlayerName)
        {
            m_CurrentPlayer.BackColor = i_PlayerName == r_FirstPlayer.PlayerName ? m_FirstPlayerName.BackColor : m_SecondPlayerName.BackColor;
            m_CurrentPlayer.Text = string.Format("Current Player: {0}", i_PlayerName);
            m_CurrentPlayer.Refresh();
        }

        internal void UpdateFirstPlayerPairs()
        {
            m_FirstPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_FirstPlayer.PlayerName, r_FirstPlayer.PlayerScore);
            m_FirstPlayerName.Refresh();
        }

        internal void UpdateSecondPlayerPairs()
        {
            m_SecondPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_SecondPlayer.PlayerName, r_SecondPlayer.PlayerScore);
            m_SecondPlayerName.Refresh();
        }
    }
}
