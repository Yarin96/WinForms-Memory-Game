using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowsAppUI
{
    public partial class GameForm : Form
    {
        public event Action<PictureBox> CardsMatch;

        public event Action<PictureBox> CardWasChosen;

        private readonly int r_BoardRows;
        private readonly int r_BoardCols;
        private readonly eGameMode r_GameMode;
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private PictureBox[,] m_MatrixOfPictureBoxes;
        //private int m_PairsCounterPlayerOne;
        //private int m_PairsCounterPlayerTwo;

        public GameForm(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            InitializeComponent();
            r_FirstPlayer = i_Player1;
            r_SecondPlayer = i_Player2;
            r_BoardRows = i_BoardRows;
            r_BoardCols = i_BoardCols;
            r_GameMode = i_GameMode;
            //m_PairsCounterPlayerOne = 0;
            //m_PairsCounterPlayerTwo = 0;
            m_CurrentPlayer.Text = string.Format("Current Player: {0}", r_FirstPlayer.PlayerName);
            m_FirstPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_FirstPlayer.PlayerName, r_FirstPlayer.PlayerScore);
            m_SecondPlayerName.Text = string.Format("{0}: {1} Pair(s)", r_SecondPlayer.PlayerName, r_SecondPlayer.PlayerScore);
            m_MatrixOfPictureBoxes = new PictureBox[r_BoardRows, r_BoardCols];
            createCardPicturesOnBoard();
        }

        public PictureBox[,] MatrixOfPictureBoxes
        {
            get { return m_MatrixOfPictureBoxes; }
        }

        private void createCardPicturesOnBoard()
        {
            PictureBox currentCard;
            int topPosition = 25;
            int leftPosition = 25;
            int addSpacingTop = 100;
            int addSpacingLeft = 100;

            for (int i = 0; i < r_BoardRows; i++)
            {
                for (int j = 0; j < r_BoardCols; j++)
                {
                    currentCard = new PictureBox
                    {
                        Name = i + "," + j,
                        Width = 80,
                        Height = 80,
                        BackColor = Color.LightBlue,
                        Location = new Point(leftPosition, topPosition),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true,
                        Margin = new Padding(15, 15, 25, 15),
                    };

                    currentCard.Click += currentCard_Click;
                    Controls.Add(currentCard);
                    m_MatrixOfPictureBoxes[i, j] = currentCard;
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

        private void currentCard_Click(object sender, EventArgs e)
        {
            OnClickCard(sender, e);
        }

        protected virtual void OnClickCard(object sender, EventArgs e)
        {
            if (Enabled && sender is PictureBox)
            {
                CardWasChosen?.Invoke(sender as PictureBox);
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
