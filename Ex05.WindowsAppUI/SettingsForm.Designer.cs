
namespace Ex05.WindowsAppUI
{
    public partial class SettingsForm
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
            this.m_FirstPlayerNameLabel = new System.Windows.Forms.Label();
            this.m_SecondPlayerNameLabel = new System.Windows.Forms.Label();
            this.m_FirstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.m_SecondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.m_GameModeButton = new System.Windows.Forms.Button();
            this.m_BoardSizeButton = new System.Windows.Forms.Button();
            this.m_StartButton = new System.Windows.Forms.Button();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_FirstPlayerNameLabel
            // 
            this.m_FirstPlayerNameLabel.AutoSize = true;
            this.m_FirstPlayerNameLabel.Location = new System.Drawing.Point(12, 21);
            this.m_FirstPlayerNameLabel.Name = "m_FirstPlayerNameLabel";
            this.m_FirstPlayerNameLabel.Size = new System.Drawing.Size(92, 13);
            this.m_FirstPlayerNameLabel.TabIndex = 0;
            this.m_FirstPlayerNameLabel.Text = "First Player Name:";
            this.m_FirstPlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_SecondPlayerNameLabel
            // 
            this.m_SecondPlayerNameLabel.AutoSize = true;
            this.m_SecondPlayerNameLabel.Location = new System.Drawing.Point(12, 57);
            this.m_SecondPlayerNameLabel.Name = "m_SecondPlayerNameLabel";
            this.m_SecondPlayerNameLabel.Size = new System.Drawing.Size(110, 13);
            this.m_SecondPlayerNameLabel.TabIndex = 1;
            this.m_SecondPlayerNameLabel.Text = "Second Player Name:";
            this.m_SecondPlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_FirstPlayerTextBox
            // 
            this.m_FirstPlayerTextBox.Location = new System.Drawing.Point(131, 18);
            this.m_FirstPlayerTextBox.Name = "m_FirstPlayerTextBox";
            this.m_FirstPlayerTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_FirstPlayerTextBox.TabIndex = 0;
            // 
            // m_SecondPlayerTextBox
            // 
            this.m_SecondPlayerTextBox.Location = new System.Drawing.Point(131, 54);
            this.m_SecondPlayerTextBox.Name = "m_SecondPlayerTextBox";
            this.m_SecondPlayerTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_SecondPlayerTextBox.TabIndex = 1;
            // 
            // m_GameModeButton
            // 
            this.m_GameModeButton.AutoSize = true;
            this.m_GameModeButton.Location = new System.Drawing.Point(249, 52);
            this.m_GameModeButton.Name = "m_GameModeButton";
            this.m_GameModeButton.Size = new System.Drawing.Size(101, 23);
            this.m_GameModeButton.TabIndex = 2;
            this.m_GameModeButton.Text = "Against Computer";
            this.m_GameModeButton.UseVisualStyleBackColor = true;
            this.m_GameModeButton.Click += new System.EventHandler(this.gameModeButton_Click);
            // 
            // m_BoardSizeButton
            // 
            this.m_BoardSizeButton.BackColor = System.Drawing.Color.MediumPurple;
            this.m_BoardSizeButton.Location = new System.Drawing.Point(12, 116);
            this.m_BoardSizeButton.Name = "m_BoardSizeButton";
            this.m_BoardSizeButton.Size = new System.Drawing.Size(141, 68);
            this.m_BoardSizeButton.TabIndex = 3;
            this.m_BoardSizeButton.Text = "4 x 4";
            this.m_BoardSizeButton.UseVisualStyleBackColor = false;
            this.m_BoardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // m_StartButton
            // 
            this.m_StartButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.m_StartButton.Location = new System.Drawing.Point(260, 154);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(84, 30);
            this.m_StartButton.TabIndex = 4;
            this.m_StartButton.Text = "Start!";
            this.m_StartButton.UseVisualStyleBackColor = false;
            this.m_StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(12, 89);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(110, 24);
            this.m_BoardSizeLabel.TabIndex = 7;
            this.m_BoardSizeLabel.Text = "Board Size:";
            this.m_BoardSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 196);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_BoardSizeButton);
            this.Controls.Add(this.m_GameModeButton);
            this.Controls.Add(this.m_SecondPlayerTextBox);
            this.Controls.Add(this.m_FirstPlayerTextBox);
            this.Controls.Add(this.m_SecondPlayerNameLabel);
            this.Controls.Add(this.m_FirstPlayerNameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_FirstPlayerNameLabel;
        private System.Windows.Forms.Label m_SecondPlayerNameLabel;
        private System.Windows.Forms.TextBox m_FirstPlayerTextBox;
        private System.Windows.Forms.TextBox m_SecondPlayerTextBox;
        private System.Windows.Forms.Button m_GameModeButton;
        private System.Windows.Forms.Button m_BoardSizeButton;
        private System.Windows.Forms.Button m_StartButton;
        private System.Windows.Forms.Label m_BoardSizeLabel;
    }
}