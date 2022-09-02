using System;

namespace Ex05.Logic
{
    public class Card
    {
        public event Action<Card> Clicked;

        private string m_CardValue;
        private bool m_IsHidden;

        public Card(string i_CardValue, bool i_IsHidden)
        {
            m_CardValue = i_CardValue;
            m_IsHidden = i_IsHidden;
        }

        public string CardValue
        {
            get { return m_CardValue; }
            set { m_CardValue = value; }
        }

        public bool IsHidden
        {
            get { return m_IsHidden; }
            set { m_IsHidden = value; }
        }

        internal void FlipCard()
        {
            OnClickedCard();
        }

        protected virtual void OnClickedCard()
        {
            Clicked?.Invoke(this);
        }
    }
}
