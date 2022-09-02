using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowsAppUI
{
    public partial class SettingsForm : Form
    {
        public event Action<Player, Player, int, int, Card[,]> StartGame;

        private int m_BoardRows;
        private int m_BoardCols;
        private int m_BoardSizeIterator;
        private List<string> m_BoardSizeOptions;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private ePlayerType m_PlayerType;
        private eGameMode m_GameMode;
        private Card[,] m_CardBoard;
        private GameLogic m_GameLogic;

        public SettingsForm()
        {
            InitializeComponent();
            m_BoardRows = 4;
            m_BoardCols = 4;
            m_BoardSizeIterator = 0;
            m_BoardSizeOptions = new List<string> { "4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6", "4 x 4", "4 x 5" };
            FormClosed += SettingsForm_FormClosed;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
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
            if (UserInfoValidations.CheckIfValidName(sender.ToString()))
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
                }

                StartGame?.Invoke(
                    new Player(ePlayerType.Human, firstPlayerTextBox.Text),
                    new Player(m_PlayerType, secondPlayerTextBox.Text),
                    m_BoardRows,
                    m_BoardCols,
                    new Card[m_BoardRows, m_BoardCols]);
                FormClosed -= SettingsForm_FormClosed;
            }
        }
    }
}
