using System;
using System.Collections.Generic;
using System.Net;
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
        private int m_BoardRows;
        private int m_BoardCols;
        private Card[,] m_GameBoard;

        public MemoryCardGameUI()
        {
            m_SettingsForm = new SettingsForm();
            m_SettingsForm.ShowDialog();
            m_SettingsForm.StartedGame += buttonStart_Click;
        }

        private void buttonStart_Click(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, eGameMode i_GameMode)
        {
            
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
            DialogResult gameForm;
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
                    m_GameForm.CardsMatch += gameForm_CardsMatched;
                }
            }

            // gameOver();
        }

        private void gameForm_CardsMatched(PictureBox i_PictureBox)
        {
            int rowIndex = int.Parse(i_PictureBox.Name[0].ToString());
            int colIndex = int.Parse(i_PictureBox.Name[2].ToString());
        }

        //private void humanPlayerTurn()
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        m_GameLogic.UpdateNextTurn();
        //    }

        //    if (!m_GameLogic.CardValuesMatch)
        //    {
        //        m_GameLogic.PreviousCard.IsHidden = true;
        //        m_GameLogic.CurrentCard.IsHidden = true;
        //    }
        //    else
        //    {
        //    }
        //}

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
                    m_GameBoard[i, j] = new Card(io_ListOfUrls[indexInList], v_DefineCardAsHidden);
                    m_GameBoard[i, j].Clicked += memoryCard_Click;
                    indexInList++;
                }
            }
        }

        private void memoryCard_Click(Card i_MemoryCard)
        {
            i_MemoryCard.IsHidden = false;
        }
    }
}
