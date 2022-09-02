
namespace Ex05.WindowsAppUI
{
    public partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_CurrentPlayer = new System.Windows.Forms.Label();
            this.m_FirstPlayerName = new System.Windows.Forms.Label();
            this.m_SecondPlayerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_CurrentPlayer
            // 
            this.m_CurrentPlayer.AutoSize = true;
            this.m_CurrentPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_CurrentPlayer.Location = new System.Drawing.Point(34, 417);
            this.m_CurrentPlayer.Name = "m_CurrentPlayer";
            this.m_CurrentPlayer.Size = new System.Drawing.Size(113, 20);
            this.m_CurrentPlayer.TabIndex = 0;
            this.m_CurrentPlayer.Text = "Current Player:";
            // 
            // m_FirstPlayerName
            // 
            this.m_FirstPlayerName.AutoSize = true;
            this.m_FirstPlayerName.BackColor = System.Drawing.Color.Gold;
            this.m_FirstPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_FirstPlayerName.Location = new System.Drawing.Point(34, 453);
            this.m_FirstPlayerName.Name = "m_FirstPlayerName";
            this.m_FirstPlayerName.Size = new System.Drawing.Size(55, 20);
            this.m_FirstPlayerName.TabIndex = 1;
            this.m_FirstPlayerName.Text = "Name:";
            // 
            // m_SecondPlayerName
            // 
            this.m_SecondPlayerName.AutoSize = true;
            this.m_SecondPlayerName.BackColor = System.Drawing.Color.MediumAquamarine;
            this.m_SecondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_SecondPlayerName.Location = new System.Drawing.Point(34, 488);
            this.m_SecondPlayerName.Name = "m_SecondPlayerName";
            this.m_SecondPlayerName.Size = new System.Drawing.Size(55, 20);
            this.m_SecondPlayerName.TabIndex = 2;
            this.m_SecondPlayerName.Text = "Name:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.m_SecondPlayerName);
            this.Controls.Add(this.m_FirstPlayerName);
            this.Controls.Add(this.m_CurrentPlayer);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_CurrentPlayer;
        private System.Windows.Forms.Label m_FirstPlayerName;
        private System.Windows.Forms.Label m_SecondPlayerName;
    }
}