namespace Chess
{
    partial class PieceSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PieceSelector));
            this.pcQueen = new System.Windows.Forms.PictureBox();
            this.pcBishop = new System.Windows.Forms.PictureBox();
            this.pcKnight = new System.Windows.Forms.PictureBox();
            this.pcRock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRock)).BeginInit();
            this.SuspendLayout();
            // 
            // pcQueen
            // 
            this.pcQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcQueen.Location = new System.Drawing.Point(12, 12);
            this.pcQueen.Name = "pcQueen";
            this.pcQueen.Size = new System.Drawing.Size(100, 100);
            this.pcQueen.TabIndex = 0;
            this.pcQueen.TabStop = false;
            this.pcQueen.Click += new System.EventHandler(this.pcQueen_Click);
            // 
            // pcBishop
            // 
            this.pcBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcBishop.Location = new System.Drawing.Point(118, 12);
            this.pcBishop.Name = "pcBishop";
            this.pcBishop.Size = new System.Drawing.Size(100, 100);
            this.pcBishop.TabIndex = 0;
            this.pcBishop.TabStop = false;
            this.pcBishop.Click += new System.EventHandler(this.pcBishop_Click);
            // 
            // pcKnight
            // 
            this.pcKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcKnight.Location = new System.Drawing.Point(224, 12);
            this.pcKnight.Name = "pcKnight";
            this.pcKnight.Size = new System.Drawing.Size(100, 100);
            this.pcKnight.TabIndex = 0;
            this.pcKnight.TabStop = false;
            this.pcKnight.Click += new System.EventHandler(this.pcKnight_Click);
            // 
            // pcRock
            // 
            this.pcRock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcRock.Location = new System.Drawing.Point(330, 12);
            this.pcRock.Name = "pcRock";
            this.pcRock.Size = new System.Drawing.Size(100, 100);
            this.pcRock.TabIndex = 0;
            this.pcRock.TabStop = false;
            this.pcRock.Click += new System.EventHandler(this.pcRock_Click);
            // 
            // PieceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 118);
            this.Controls.Add(this.pcRock);
            this.Controls.Add(this.pcKnight);
            this.Controls.Add(this.pcBishop);
            this.Controls.Add(this.pcQueen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PieceSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Piece Selector";
            ((System.ComponentModel.ISupportInitialize)(this.pcQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcQueen;
        private System.Windows.Forms.PictureBox pcBishop;
        private System.Windows.Forms.PictureBox pcKnight;
        private System.Windows.Forms.PictureBox pcRock;
    }
}