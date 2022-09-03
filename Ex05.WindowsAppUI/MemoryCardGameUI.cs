using System;
using System.Collections.Generic;
using System.Net;
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
        private Card m_FirstPlayerChoice;
        private Card m_SecondPlayerChoice;
        private bool m_SecondCardPick;
        private PictureBox m_PrevPicturePick;

        public MemoryCardGameUI()
        {
            m_SecondCardPick = false;
            m_SettingsForm = new SettingsForm();
            m_SettingsForm.StartedGame += buttonStart_Click;
            m_SettingsForm.ShowDialog();
        }

        private void buttonStart_Click(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_BoardRows = i_BoardRows;
            m_BoardCols = i_BoardCols;
            m_GameMode = i_GameMode;
            m_GameBoard = new Card[m_BoardRows, m_BoardCols];
            generateRandomPicturesToGameBoard();
            m_GameLogic = new GameLogic(i_Player1, i_Player2, i_BoardRows, i_BoardCols, m_GameBoard);
            m_GameForm = new GameForm(i_Player1, i_Player2, i_BoardRows, i_BoardCols, i_GameMode);
            runGame();
        }

        private void runGame()
        {
            m_GameForm.CardWasChosen += gameForm_CardWasChosen;
            m_GameForm.ShowDialog();
            int totalPossibleScore = (m_BoardRows * m_BoardCols) / 2;

            while (m_GameLogic.Player1.PlayerScore + m_GameLogic.Player2.PlayerScore != totalPossibleScore)
            {
                if (m_GameMode == eGameMode.PlayerVsComputer)
                {
                    if (m_GameLogic.CurrentPlayer.PlayerType == ePlayerType.Computer)
                    {
                        // computerPlayerTurn();
                    }
                    else
                    {
                        // humanPlayerTurn();
                    }
                }
                else
                {
                    // humanPlayerTurn();

                    // m_GameForm.CardsMatch += gameForm_CardsMatched;
                }
            }

            // gameOver();
        }

        private void gameForm_CardWasChosen(PictureBox i_PictureBox)
        {
            m_GameForm.CardWasChosen -= gameForm_CardWasChosen;
            int rowIndex = int.Parse(i_PictureBox.Name[0].ToString());
            int colIndex = int.Parse(i_PictureBox.Name[2].ToString());
            Card currentCard = m_GameBoard[rowIndex, colIndex];
            string imageUrl = currentCard.CardValue;
            m_GameLogic.UpdateNextTurn(currentCard);

            if (!currentCard.IsHidden)
            {
                i_PictureBox.Load(imageUrl);
                //i_PictureBox.BorderStyle.
            }

            i_PictureBox.Refresh();

            if (m_GameLogic.CurrentCard == null)
            {
                m_PrevPicturePick = i_PictureBox;
            }
            else
            {
                if (!m_GameLogic.CurrentCard.IsHidden && m_GameLogic.CardValuesMatch)
                {
                    updateScores();
                }
                else if (!m_GameLogic.CurrentCard.IsHidden && !m_GameLogic.CardValuesMatch)
                {
                    Thread.Sleep(1000);
                    m_GameLogic.PreviousCard.IsHidden = true;
                    m_GameLogic.CurrentCard.IsHidden = true;
                    m_GameForm.UpdateCurrentPlayer(m_GameLogic.CurrentPlayer.PlayerName);
                    i_PictureBox.Image = null;
                    m_PrevPicturePick.Image = null;
                    i_PictureBox.Refresh();
                    m_PrevPicturePick.Refresh();
                }
            }

            m_GameForm.CardWasChosen += gameForm_CardWasChosen;

            //if (!m_SecondCardPick)
            //{
            //    m_FirstPlayerChoice = m_GameBoard[rowIndex, colIndex];
            //    m_PrevPicturePick = i_PictureBox;
            //    m_SecondCardPick = true;
            //}
            //else
            //{
            //    m_SecondCardPick = false;
            //    m_SecondPlayerChoice = m_GameBoard[rowIndex, colIndex];

            //    if (m_FirstPlayerChoice.CardValue == m_SecondPlayerChoice.CardValue)
            //    {
            //        gameForm_CardsMatched(i_PictureBox);
            //    }
            //    else
            //    {
            //        m_GameLogic.CurrentPlayer = m_GameLogic.CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
            //        m_GameForm.UpdateCurrentPlayer(m_GameLogic.CurrentPlayer.PlayerName);
            //        Thread.Sleep(1000);
            //        i_PictureBox.Image = null;
            //        m_PrevPicturePick.Image = null;
            //        i_PictureBox.Refresh();
            //        m_PrevPicturePick.Refresh();
            //    }
            //}
        }


        private void disableAccessToAllPictureBoxes(PictureBox i_PictureBox)
        {
            foreach (PictureBox pictureBox in m_GameForm.MatrixOfPictureBoxes)
            {
                if (pictureBox != i_PictureBox)
                {
                    pictureBox.Enabled = false;
                }
            }
        }

        private void enableAccessToAllPictureBoxes(PictureBox i_PictureBox)
        {
            foreach (PictureBox pictureBox in m_GameForm.MatrixOfPictureBoxes)
            {
                if (pictureBox != i_PictureBox)
                {
                    pictureBox.Enabled = true;
                }
            }
        }

        private void updateScores()
        {
            if (m_GameLogic.CurrentPlayer.PlayerName == m_Player1.PlayerName)
            {
                m_GameForm.UpdateFirstPlayerPairs();
            }
            else
            {
                m_GameForm.UpdateSecondPlayerPairs();
            }
        }

        private void generateRandomPicturesToGameBoard()
        {
            List<string> io_PicturesUrlList = new List<string>(m_BoardRows * m_BoardCols);
            addPicturesUrlsToList(ref io_PicturesUrlList);
            shufflePictuesUrlsInList(ref io_PicturesUrlList);
            assignPictureUrlsFromListToBoard(ref io_PicturesUrlList);
        }

        private void addPicturesUrlsToList(ref List<string> io_ListOfUrls)
        {
            for (int i = 0; i < io_ListOfUrls.Capacity / 2; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://picsum.photos/80");
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                io_ListOfUrls.Add(myResponse.ResponseUri.ToString());
                io_ListOfUrls.Add(myResponse.ResponseUri.ToString());
                myResponse.Close();
            }
        }

        private void shufflePictuesUrlsInList(ref List<string> io_ListOfUrls)
        {
            int indexInList = 0;
            Random randomValue = new Random();

            for (int i = io_ListOfUrls.Count - 1; i > 1; i--)
            {
                indexInList = randomValue.Next(i + 1);
                string randomUrl = io_ListOfUrls[indexInList];
                io_ListOfUrls[indexInList] = io_ListOfUrls[i];
                io_ListOfUrls[i] = randomUrl;
            }
        }

        private void assignPictureUrlsFromListToBoard(ref List<string> io_ListOfUrls)
        {
            int indexInList = 0;
            const bool v_DefineCardAsHidden = true;

            for (int i = 0; i < m_BoardRows; i++)
            {
                for (int j = 0; j < m_BoardCols; j++)
                {
                    m_GameBoard[i, j] = new Card(indexInList, io_ListOfUrls[indexInList], v_DefineCardAsHidden);
                    indexInList++;
                }
            }
        }
    }
}
