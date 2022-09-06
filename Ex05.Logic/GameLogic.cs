using System;
using System.Collections.Generic;

namespace Ex05.Logic
{
    public class GameLogic
    {
        private readonly int r_BoardCols;
        private readonly int r_BoardRows;
        private bool m_IsSecondCardSelection;
        private bool m_CardValuesMatch;
        private Card m_CurrentCardSelection;
        private Card m_PreviousCardSelection;
        private Card[,] m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private int m_CurrentScore;
        private int m_TotalPossibleScore;

        public GameLogic(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, Card[,] i_Board)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_CurrentPlayer = i_Player1;
            r_BoardRows = i_BoardRows;
            r_BoardCols = i_BoardCols;
            m_IsSecondCardSelection = true;
            m_CardValuesMatch = false;
            m_GameBoard = i_Board;
            m_CurrentScore = 0;
            m_TotalPossibleScore = (r_BoardRows * r_BoardCols) / 2;
        }

        public bool IsSecondCardSelection
        {
            get { return m_IsSecondCardSelection; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public bool CardValuesMatch
        {
            get { return m_CardValuesMatch; }
        }

        public Card PreviousCard
        {
            get { return m_PreviousCardSelection; }
        }

        public Card CurrentCard
        {
            get { return m_CurrentCardSelection; }
        }

        public void UpdateNextTurn(Card i_PlayerCardSelection)
        {
            if (m_IsSecondCardSelection)
            {
                m_CurrentCardSelection = null;
                m_PreviousCardSelection = i_PlayerCardSelection;
                m_PreviousCardSelection.IsHidden = false;
                m_IsSecondCardSelection = false;
            }
            else
            {
                m_CurrentCardSelection = i_PlayerCardSelection;
                m_CurrentCardSelection.IsHidden = false;
                m_IsSecondCardSelection = true;
                m_CardValuesMatch = m_CurrentCardSelection.CardValue == m_PreviousCardSelection.CardValue;

                if (m_CardValuesMatch)
                {
                    m_CurrentPlayer.PlayerScore++;
                    m_CurrentScore++;
                }
                else
                {
                    m_PreviousCardSelection.IsHidden = true;
                    m_CurrentCardSelection.IsHidden = true;
                    m_CurrentPlayer = m_CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
                }
            }
        }

        public List<Card> GetTwoRandomPicksByComputer()
        {
            Random random = new Random();
            Card currentComputerChoice;
            List<Card> twoRandomPicks = new List<Card>(2);

            for (int i = 0; i < 2; i++)
            {
                currentComputerChoice = m_GameBoard[random.Next(r_BoardRows), random.Next(r_BoardCols)];

                while (!currentComputerChoice.IsHidden)
                {
                    currentComputerChoice = m_GameBoard[random.Next(r_BoardRows), random.Next(r_BoardCols)];
                }

                twoRandomPicks.Add(currentComputerChoice);
            }

            return twoRandomPicks;
        }

        public bool IsGameTied(out string o_WinnerName)
        {
            bool gameTied = false;

            if (m_Player1.PlayerScore > m_Player2.PlayerScore)
            {
                o_WinnerName = m_Player1.PlayerName;
            }
            else if (m_Player1.PlayerScore < m_Player2.PlayerScore)
            {
                o_WinnerName = m_Player2.PlayerName;
            }
            else
            {
                gameTied = true;
                o_WinnerName = m_Player1.PlayerName;
            }

            return gameTied;
        }

        public bool IsGameOver()
        {
            return m_CurrentScore == m_TotalPossibleScore;
        }
    }
}