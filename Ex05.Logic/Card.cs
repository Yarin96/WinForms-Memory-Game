using System;

namespace Ex05.Logic
{
    public class Card
    {
        public event Action CardClicked;

        private string m_CardValue;
        private bool m_IsHidden;
        private int m_RowIndex;
        private int m_ColIndex;

        public Card(string i_CardValue, bool i_IsHidden, int i_RowIndex, int i_ColIndex)
        {
            m_CardValue = i_CardValue;
            m_IsHidden = i_IsHidden;
            m_RowIndex = i_RowIndex;
            m_ColIndex = i_ColIndex;
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

        public int RowIndex
        {
            get { return m_RowIndex; }
        }

        public int ColIndex
        {
            get { return m_ColIndex; }
        }

        internal void CurrentCard_Click(object sender, EventArgs e)
        {
            OnClickCard(sender, e);
        }

        protected virtual void OnClickCard(object sender, EventArgs e)
        {
            CardClicked?.Invoke();
        }
    }
}
