
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.gameModeButton = new System.Windows.Forms.Button();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Player Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Player Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // firstPlayerTextBox
            // 
            this.firstPlayerTextBox.Location = new System.Drawing.Point(131, 18);
            this.firstPlayerTextBox.Name = "firstPlayerTextBox";
            this.firstPlayerTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstPlayerTextBox.TabIndex = 0;
            // 
            // secondPlayerTextBox
            // 
            this.secondPlayerTextBox.Location = new System.Drawing.Point(131, 54);
            this.secondPlayerTextBox.Name = "secondPlayerTextBox";
            this.secondPlayerTextBox.Size = new System.Drawing.Size(100, 20);
            this.secondPlayerTextBox.TabIndex = 1;
            // 
            // gameModeButton
            // 
            this.gameModeButton.AutoSize = true;
            this.gameModeButton.Location = new System.Drawing.Point(249, 52);
            this.gameModeButton.Name = "gameModeButton";
            this.gameModeButton.Size = new System.Drawing.Size(101, 23);
            this.gameModeButton.TabIndex = 2;
            this.gameModeButton.Text = "Against Computer";
            this.gameModeButton.UseVisualStyleBackColor = true;
            this.gameModeButton.Click += new System.EventHandler(this.gameModeButton_Click);
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.BackColor = System.Drawing.Color.MediumPurple;
            this.boardSizeButton.Location = new System.Drawing.Point(12, 116);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(141, 68);
            this.boardSizeButton.TabIndex = 3;
            this.boardSizeButton.Text = "4 x 4";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.startButton.Location = new System.Drawing.Point(260, 154);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(84, 30);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Board Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 196);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.gameModeButton);
            this.Controls.Add(this.secondPlayerTextBox);
            this.Controls.Add(this.firstPlayerTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstPlayerTextBox;
        private System.Windows.Forms.TextBox secondPlayerTextBox;
        private System.Windows.Forms.Button gameModeButton;
        private System.Windows.Forms.Button boardSizeButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label3;
    }
}