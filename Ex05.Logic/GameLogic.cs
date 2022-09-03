using System;

namespace Ex05.Logic
{
    public class GameLogic
    {
        public event Action PairFound;

        private readonly int r_BoardCols;
        private readonly int r_BoardRows;
        private bool m_IsFirstCardSelection;
        private bool m_CardValuesMatch;
        private Card m_CurrentCardSelection;
        private Card m_PreviousCardSelection;
        private Card[,] m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;

        public GameLogic(Player i_Player1, Player i_Player2, int i_BoardRows, int i_BoardCols, Card[,] i_Board)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_CurrentPlayer = i_Player1;
            r_BoardRows = i_BoardRows;
            r_BoardCols = i_BoardCols;
            m_IsFirstCardSelection = true;
            m_GameBoard = i_Board;
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
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
            set { m_PreviousCardSelection = value; }
        }

        public Card CurrentCard
        {
            get { return m_CurrentCardSelection; }
        }

        public void UpdateNextTurn(Card i_UserCardSelection)
        {
            if (m_IsFirstCardSelection)
            {
                m_CurrentCardSelection = null;
                m_PreviousCardSelection = i_UserCardSelection;
                m_PreviousCardSelection.IsHidden = false;
                m_IsFirstCardSelection = false;
            }
            else
            {
                m_CurrentCardSelection = i_UserCardSelection;
                m_CurrentCardSelection.IsHidden = false;
                m_IsFirstCardSelection = true;
                m_CardValuesMatch = m_CurrentCardSelection.CardValue == m_PreviousCardSelection.CardValue;

                if (m_CardValuesMatch)
                {
                    m_CurrentPlayer.PlayerScore++;
                }
                else
                {
                    m_CurrentPlayer = m_CurrentPlayer == m_Player1 ? m_Player2 : m_Player1;
                }
            }
        }

        public void ComputerTurn()
        {
            Random random = new Random();
            Card currentComputerChoice = m_GameBoard[random.Next(r_BoardRows), random.Next(r_BoardCols)];

            while (!currentComputerChoice.IsHidden)
            {
                currentComputerChoice = m_GameBoard[random.Next(r_BoardRows), random.Next(r_BoardCols)];
            }

            UpdateNextTurn(currentComputerChoice);
        }

        //public bool IsCardAlreadyChosen(string i_UserCardInput)
        //{
        //    int colLetter = ConvertLetterToInt(i_UserCardInput[0]);
        //    int rowNum = ConvertNumberCharacterToInt(i_UserCardInput[1]);
        //    return !m_GameBoard[colLetter - 1, rowNum - 1].IsHidden;
        //}
    }
}