using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.WindowsAppUI
{
    public class MemoryCardGameUI
    {
        private SettingsForm m_SettingsForm;
        private GameForm m_GameForm;
        private GameLogic m_GameLogic;
        private eGameMode m_GameMode;
        private Player m_Player1;
        private Player m_Player2;
        private int m_BoardRows;
        private int m_BoardCols;
        private Card[,] m_GameBoard;
        private Button m_PrevButtonPick;

        public MemoryCardGameUI()
        {
            Application.EnableVisualStyles();
            m_SettingsForm = new SettingsForm();
            m_SettingsForm.StartedGame += buttonStart_Click;
            m_SettingsForm.ShowDialog();
        }

        private void buttonStart_Click(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            initNewGame(i_Player1, i_Player2, i_BoardRows, i_BoardCols, i_GameMode);
        }

        private void initNewGame(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            m_BoardRows = i_BoardRows;
            m_BoardCols = i_BoardCols;
            m_GameMode = i_GameMode;
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_GameBoard = new Card[m_BoardRows, m_BoardCols];
            m_GameForm = new GameForm(i_Player1, i_Player2, i_BoardRows, i_BoardCols, i_GameMode);
            generateRandomPicturesOnGameBoard();
            m_GameLogic = new GameLogic(i_Player1, i_Player2, i_BoardRows, i_BoardCols, m_GameBoard);
            runGame();
        }

        private void runGame()
        {
            m_GameForm.ButtonClicked += gameForm_ButtonClicked;
            m_GameForm.ShowDialog();

            if (m_GameForm.Focused)
            {
                m_GameForm.Dispose();
            }
        }

        private void gameForm_ButtonClicked(Button i_Button)
        {
            if (!i_Button.Enabled)
            {
                return;
            }
            else
            {
                i_Button.Enabled = false;
            }

            Card currentCard = getCorrespondingCardOfButton(i_Button);
            displayImageOnButton(currentCard, i_Button);
            commitTurn(currentCard);

            if (m_GameLogic.IsGameOver())
            {
                gameOver();
            }

            if (m_GameLogic.IsSecondCardSelection)
            {
                if (m_GameLogic.CardValuesMatch)
                {
                    updateScoreBoard();

                    if (m_GameLogic.CurrentPlayer.PlayerType == ePlayerType.Computer)
                    {
                        attemptComputerTurn();
                    }
                }
                else
                {
                    handlePairNotMatched(i_Button);
                    attemptComputerTurn();
                }
            }
            else
            {
                m_PrevButtonPick = i_Button;
            }
        }

        private Card getCorrespondingCardOfButton(Button i_Button)
        {
            int rowIndex = int.Parse(i_Button.Name[0].ToString());
            int colIndex = int.Parse(i_Button.Name[2].ToString());

            return m_GameBoard[rowIndex, colIndex];
        }

        private void displayImageOnButton(Card i_CurrentCard, Button i_CurrentButton)
        {
            PictureBox currentPicture = new PictureBox();
            currentPicture.Load(i_CurrentCard.CardValue);
            i_CurrentButton.BackgroundImage = currentPicture.Image;
            i_CurrentButton.BackgroundImageLayout = ImageLayout.Center;

            if (m_GameLogic.CurrentPlayer == m_Player1)
            {
                i_CurrentButton.BackColor = m_GameForm.FirstPlayerLabel.BackColor;
            }
            else
            {
                i_CurrentButton.BackColor = m_GameForm.SecondPlayerLabel.BackColor;
            }

            i_CurrentButton.Refresh();
        }

        private void commitTurn(Card i_CurrentCard)
        {
            const bool v_AreAllButtonsDisabled = true;
            changeAccessToAllButtons(v_AreAllButtonsDisabled);
            m_GameLogic.UpdateNextTurn(i_CurrentCard);
            changeAccessToAllButtons(!v_AreAllButtonsDisabled);
        }

        private void attemptComputerTurn()
        {
            if (m_GameMode == eGameMode.PlayerVsComputer && m_GameLogic.CurrentPlayer.PlayerType == ePlayerType.Computer)
            {
                wait(1000);
                List<Card> twoRandomPicks = m_GameLogic.GetTwoRandomPicksByComputer();
                computerMoveInvoker(twoRandomPicks[0]);
                computerMoveInvoker(twoRandomPicks[1]);
            }
        }

        private void computerMoveInvoker(Card i_RandomCardPick)
        {
            Button buttonPick = m_GameForm.MatrixOfButtons[i_RandomCardPick.RowIndex, i_RandomCardPick.ColIndex];
            gameForm_ButtonClicked(buttonPick);
            m_GameForm.Refresh();
            wait(500);
        }

        private void changeAccessToAllButtons(bool i_IsDisableAccessToAll)
        {
            foreach (Button button in m_GameForm.MatrixOfButtons)
            {
                if (i_IsDisableAccessToAll)
                {
                    button.Click -= m_GameForm.CurrentButton_Click;
                }
                else
                {
                    button.Click += m_GameForm.CurrentButton_Click;
                }
            }
        }

        private void updateScoreBoard()
        {
            if (m_GameLogic.CurrentPlayer.PlayerName == m_GameLogic.Player1.PlayerName)
            {
                m_GameForm.UpdateFirstPlayerPairs();
            }
            else
            {
                m_GameForm.UpdateSecondPlayerPairs();
            }
        }

        private void handlePairNotMatched(Button i_CurrentButtonPick)
        {
            wait(1000);
            m_PrevButtonPick.Enabled = true;
            i_CurrentButtonPick.Enabled = true;
            m_PrevButtonPick.BackgroundImage = null;
            i_CurrentButtonPick.BackgroundImage = null;
            m_PrevButtonPick.BackColor = Color.LightGray;
            i_CurrentButtonPick.BackColor = Color.LightGray;
            m_PrevButtonPick.Refresh();
            i_CurrentButtonPick.Refresh();
            m_GameForm.UpdateCurrentPlayer(m_GameLogic.CurrentPlayer.PlayerName);
        }

        private void generateRandomPicturesOnGameBoard()
        {
            List<string> io_PicturesUrlList = new List<string>(m_BoardRows * m_BoardCols);
            addPicturesUrlsToList(ref io_PicturesUrlList);
            shufflePictuesUrlsInList(ref io_PicturesUrlList);
            assignPictureUrlsFromListToBoard(ref io_PicturesUrlList);
        }

        private void addPicturesUrlsToList(ref List<string> io_ListOfPictureUrls)
        {
            for (int i = 0; i < io_ListOfPictureUrls.Capacity / 2; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://picsum.photos/80");
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                io_ListOfPictureUrls.Add(myResponse.ResponseUri.ToString());
                io_ListOfPictureUrls.Add(myResponse.ResponseUri.ToString());
                myResponse.Close();
            }
        }

        private void shufflePictuesUrlsInList(ref List<string> io_ListOfPictureUrls)
        {
            int indexInList = 0;
            Random randomValue = new Random();

            for (int i = io_ListOfPictureUrls.Count - 1; i > 1; i--)
            {
                indexInList = randomValue.Next(i + 1);
                string randomUrl = io_ListOfPictureUrls[indexInList];
                io_ListOfPictureUrls[indexInList] = io_ListOfPictureUrls[i];
                io_ListOfPictureUrls[i] = randomUrl;
            }
        }

        private void assignPictureUrlsFromListToBoard(ref List<string> io_ListOfPictureUrls)
        {
            int indexInList = 0;
            const bool v_DefineCardAsHidden = true;

            for (int i = 0; i < m_BoardRows; i++)
            {
                for (int j = 0; j < m_BoardCols; j++)
                {
                    m_GameBoard[i, j] = new Card(io_ListOfPictureUrls[indexInList], v_DefineCardAsHidden, i, j);
                    indexInList++;
                }
            }
        }

        private void gameOver()
        {
            StringBuilder endingMessage = new StringBuilder();

            if (m_GameLogic.IsGameTied(out string o_WinnerName))
            {
                endingMessage.Append("Game is tied!");
            }
            else
            {
                string winnerMessage = string.Format("{0} has won the game!", o_WinnerName);
                endingMessage.Append(winnerMessage);
            }

            endingMessage.Append(Environment.NewLine);
            endingMessage.Append(Environment.NewLine);
            endingMessage.Append("Play Again?");
            DialogResult dialogResult = MessageBox.Show(endingMessage.ToString(), "Game Over!", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                closeCurrentForms();
                m_Player1.PlayerScore = 0;
                m_Player2.PlayerScore = 0;
                initNewGame(m_Player1, m_Player2, m_BoardRows, m_BoardCols, m_GameMode);
            }
            else
            {
                closeCurrentForms();
            }
        }

        private void closeCurrentForms()
        {
            m_GameForm.Close();
            m_SettingsForm.Close();
            m_GameForm.Dispose();
            m_SettingsForm.Dispose();
        }

        private void wait(int i_TimeInMilliSeconds)
        {
            Thread.Sleep(i_TimeInMilliSeconds);
        }
    }
}
