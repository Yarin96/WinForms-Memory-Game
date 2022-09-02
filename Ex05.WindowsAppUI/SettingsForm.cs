using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowsAppUI
{
    public partial class SettingsForm : Form
    {
        public event Action<Player, Player, int, int, eGameMode> StartedGame;

        private int m_BoardRows;
        private int m_BoardCols;
        private int m_BoardSizeIterator;
        private List<string> m_BoardSizeOptions;
        private ePlayerType m_PlayerType;
        private eGameMode m_GameMode;

        public SettingsForm()
        {
            InitializeComponent();
            m_BoardRows = 4;
            m_BoardCols = 4;
            m_BoardSizeIterator = 0;
            m_BoardSizeOptions = new List<string> { "4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6" };
            FormClosed += settingsForm_FormClosed;
        }

        private void settingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                firstPlayerTextBox.Text = firstPlayerTextBox.Text == string.Empty ? "Player One" : firstPlayerTextBox.Text;
                secondPlayerTextBox.Text = secondPlayerTextBox.Text == string.Empty ? "Player Two" : secondPlayerTextBox.Text;
            }

            startButton_Click(sender, e);
        }

        private void gameModeButton_Click(object sender, EventArgs e)
        {
            if (gameModeButton.Text == "Against Computer")
            {
                secondPlayerTextBox.Enabled = false;
                secondPlayerTextBox.Text = "- Computer -";
                gameModeButton.Text = "Against a Friend";
                m_PlayerType = ePlayerType.Computer;
                m_GameMode = eGameMode.PlayerVsComputer;
            }
            else
            {
                secondPlayerTextBox.Enabled = true;
                secondPlayerTextBox.Text = string.Empty;
                gameModeButton.Text = "Against Computer";
                m_PlayerType = ePlayerType.Human;
                m_GameMode = eGameMode.PlayerVsPlayer;
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            m_BoardSizeIterator = m_BoardSizeIterator < m_BoardSizeOptions.Count - 1 ? m_BoardSizeIterator + 1 : 0;
            boardSizeButton.Text = m_BoardSizeOptions[m_BoardSizeIterator];
            m_BoardRows = int.Parse(boardSizeButton.Text[0].ToString());
            m_BoardCols = int.Parse(boardSizeButton.Text[boardSizeButton.Text.Length - 1].ToString());
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!checkIfValidName(firstPlayerTextBox.Text) || !checkIfValidName(secondPlayerTextBox.Text))
            {
                MessageBox.Show("Names should not contain symbols or numbers.");
            }
            else
            {
                if (firstPlayerTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter the first player name.");
                }
                else
                {
                    if (secondPlayerTextBox.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter the second player name.");
                    }
                    else
                    {
                        OnStartGame();
                    }
                }
            }
        }

        protected virtual void OnStartGame()
        {
            StartedGame?.Invoke(new Player(ePlayerType.Human, firstPlayerTextBox.Text), new Player(m_PlayerType, secondPlayerTextBox.Text), m_BoardRows, m_BoardCols, m_GameMode);
            FormClosed -= settingsForm_FormClosed;
            Close();
        }

        private bool checkIfValidName(string i_PlayerName)
        {
            bool isValidFlag = true;

            if (i_PlayerName != string.Empty)
            {
                for (int i = 0; i < i_PlayerName.Length; i++)
                {
                    if (!char.IsLetter(i_PlayerName[i]))
                    {
                        isValidFlag = false;
                        break;
                    }
                }
            }

            return isValidFlag;
        }
    }
}
