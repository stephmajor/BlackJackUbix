namespace Ubix.BlackJack
{
    partial class GameBoard
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
            this.deal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Probabilities = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.win = new System.Windows.Forms.Label();
            this.push = new System.Windows.Forms.Label();
            this.lose = new System.Windows.Forms.Label();
            this.hit = new System.Windows.Forms.Button();
            this.stand = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.outcome = new System.Windows.Forms.Label();
            this.playersCards = new System.Windows.Forms.ListBox();
            this.dealersCards = new System.Windows.Forms.ListBox();
            this.value_p = new System.Windows.Forms.Label();
            this.value_d = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deal
            // 
            this.deal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deal.Location = new System.Drawing.Point(144, 297);
            this.deal.Name = "deal";
            this.deal.Size = new System.Drawing.Size(68, 23);
            this.deal.TabIndex = 0;
            this.deal.Text = "Deal Cards";
            this.deal.UseVisualStyleBackColor = true;
            this.deal.Click += new System.EventHandler(this.deal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player\'s cards:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dealer\'s cards:";
            // 
            // Probabilities
            // 
            this.Probabilities.AutoSize = true;
            this.Probabilities.Location = new System.Drawing.Point(226, 13);
            this.Probabilities.Name = "Probabilities";
            this.Probabilities.Size = new System.Drawing.Size(66, 13);
            this.Probabilities.TabIndex = 4;
            this.Probabilities.Text = "Probabilities:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Winning:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Push:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Losing:";
            // 
            // win
            // 
            this.win.AutoSize = true;
            this.win.Location = new System.Drawing.Point(285, 40);
            this.win.Name = "win";
            this.win.Size = new System.Drawing.Size(24, 13);
            this.win.TabIndex = 8;
            this.win.Text = "n/a";
            // 
            // push
            // 
            this.push.AutoSize = true;
            this.push.Location = new System.Drawing.Point(285, 63);
            this.push.Name = "push";
            this.push.Size = new System.Drawing.Size(24, 13);
            this.push.TabIndex = 9;
            this.push.Text = "n/a";
            // 
            // lose
            // 
            this.lose.AutoSize = true;
            this.lose.Location = new System.Drawing.Point(285, 85);
            this.lose.Name = "lose";
            this.lose.Size = new System.Drawing.Size(24, 13);
            this.lose.TabIndex = 10;
            this.lose.Text = "n/a";
            // 
            // hit
            // 
            this.hit.Location = new System.Drawing.Point(14, 56);
            this.hit.Name = "hit";
            this.hit.Size = new System.Drawing.Size(75, 23);
            this.hit.TabIndex = 12;
            this.hit.Text = "Hit";
            this.hit.UseVisualStyleBackColor = true;
            this.hit.Click += new System.EventHandler(this.hit_Click);
            // 
            // stand
            // 
            this.stand.Location = new System.Drawing.Point(14, 85);
            this.stand.Name = "stand";
            this.stand.Size = new System.Drawing.Size(75, 23);
            this.stand.TabIndex = 13;
            this.stand.Text = "Stand";
            this.stand.UseVisualStyleBackColor = true;
            this.stand.Click += new System.EventHandler(this.stand_Click);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(12, 200);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 14;
            this.next.Text = "Next Card";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // outcome
            // 
            this.outcome.AutoSize = true;
            this.outcome.Location = new System.Drawing.Point(226, 205);
            this.outcome.Name = "outcome";
            this.outcome.Size = new System.Drawing.Size(0, 13);
            this.outcome.TabIndex = 15;
            // 
            // playersCards
            // 
            this.playersCards.FormattingEnabled = true;
            this.playersCards.Location = new System.Drawing.Point(95, 13);
            this.playersCards.Name = "playersCards";
            this.playersCards.Size = new System.Drawing.Size(120, 121);
            this.playersCards.TabIndex = 16;
            // 
            // dealersCards
            // 
            this.dealersCards.FormattingEnabled = true;
            this.dealersCards.Location = new System.Drawing.Point(95, 146);
            this.dealersCards.Name = "dealersCards";
            this.dealersCards.Size = new System.Drawing.Size(120, 134);
            this.dealersCards.TabIndex = 17;
            // 
            // value_p
            // 
            this.value_p.AutoSize = true;
            this.value_p.Location = new System.Drawing.Point(14, 26);
            this.value_p.Name = "value_p";
            this.value_p.Size = new System.Drawing.Size(39, 13);
            this.value_p.TabIndex = 18;
            this.value_p.Text = "value: ";
            // 
            // value_d
            // 
            this.value_d.AutoSize = true;
            this.value_d.Location = new System.Drawing.Point(14, 159);
            this.value_d.Name = "value_d";
            this.value_d.Size = new System.Drawing.Size(36, 13);
            this.value_d.TabIndex = 19;
            this.value_d.Text = "value:";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 332);
            this.Controls.Add(this.value_d);
            this.Controls.Add(this.value_p);
            this.Controls.Add(this.dealersCards);
            this.Controls.Add(this.playersCards);
            this.Controls.Add(this.outcome);
            this.Controls.Add(this.next);
            this.Controls.Add(this.stand);
            this.Controls.Add(this.hit);
            this.Controls.Add(this.lose);
            this.Controls.Add(this.push);
            this.Controls.Add(this.win);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Probabilities);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deal);
            this.Name = "GameBoard";
            this.Text = "BlackJack Game Board";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Probabilities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label win;
        private System.Windows.Forms.Label push;
        private System.Windows.Forms.Label lose;
        private System.Windows.Forms.Button hit;
        private System.Windows.Forms.Button stand;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label outcome;
        private System.Windows.Forms.ListBox playersCards;
        private System.Windows.Forms.ListBox dealersCards;
        private System.Windows.Forms.Label value_p;
        private System.Windows.Forms.Label value_d;
    }
}

