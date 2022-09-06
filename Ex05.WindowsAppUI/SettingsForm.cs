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
                m_FirstPlayerTextBox.Text = m_FirstPlayerTextBox.Text == string.Empty ? "Player One" : m_FirstPlayerTextBox.Text;
                m_SecondPlayerTextBox.Text = m_SecondPlayerTextBox.Text == string.Empty ? "Player Two" : m_SecondPlayerTextBox.Text;
                OnStartGame();
            }
        }

        private void gameModeButton_Click(object sender, EventArgs e)
        {
            if (m_GameModeButton.Text == "Against Computer")
            {
                m_SecondPlayerTextBox.Enabled = false;
                m_SecondPlayerTextBox.Text = "- Computer -";
                m_GameModeButton.Text = "Against a Friend";
                m_PlayerType = ePlayerType.Computer;
                m_GameMode = eGameMode.PlayerVsComputer;
            }
            else
            {
                m_SecondPlayerTextBox.Enabled = true;
                m_SecondPlayerTextBox.Text = string.Empty;
                m_GameModeButton.Text = "Against Computer";
                m_PlayerType = ePlayerType.Human;
                m_GameMode = eGameMode.PlayerVsPlayer;
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            m_BoardSizeIterator = m_BoardSizeIterator < m_BoardSizeOptions.Count - 1 ? m_BoardSizeIterator + 1 : 0;
            m_BoardSizeButton.Text = m_BoardSizeOptions[m_BoardSizeIterator];
            m_BoardRows = int.Parse(m_BoardSizeButton.Text[0].ToString());
            m_BoardCols = int.Parse(m_BoardSizeButton.Text[m_BoardSizeButton.Text.Length - 1].ToString());
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!checkIfValidName(m_FirstPlayerTextBox.Text) || (!checkIfValidName(m_SecondPlayerTextBox.Text) && m_GameMode == eGameMode.PlayerVsPlayer))
            {
                MessageBox.Show("Names should not contain symbols or numbers.");
            }
            else
            {
                if (m_FirstPlayerTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter the first player name.");
                }
                else
                {
                    if (m_SecondPlayerTextBox.Text == string.Empty)
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
            if (StartedGame != null)
            {
                Hide();
                StartedGame.Invoke(
                    new Player(ePlayerType.Human, m_FirstPlayerTextBox.Text),
                    new Player(m_PlayerType, m_SecondPlayerTextBox.Text),
                    m_BoardRows,
                    m_BoardCols,
                    m_GameMode);
                FormClosed -= settingsForm_FormClosed;
                Close();
            }
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
