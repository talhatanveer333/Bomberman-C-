namespace Bomberman
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.movingtimer = new System.Windows.Forms.Timer(this.components);
            this.game_over = new System.Windows.Forms.Label();
            this.gate_pic = new System.Windows.Forms.PictureBox();
            this.sprite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gate_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprite)).BeginInit();
            this.SuspendLayout();
            // 
            // movingtimer
            // 
            this.movingtimer.Enabled = true;
            this.movingtimer.Tick += new System.EventHandler(this.movingtimer_Tick);
            // 
            // game_over
            // 
            this.game_over.AutoSize = true;
            this.game_over.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_over.ForeColor = System.Drawing.Color.Firebrick;
            this.game_over.Location = new System.Drawing.Point(274, 180);
            this.game_over.Name = "game_over";
            this.game_over.Size = new System.Drawing.Size(211, 33);
            this.game_over.TabIndex = 2;
            this.game_over.Text = "Game Over!!!";
            this.game_over.Visible = false;
            
            // 
            // gate_pic
            // 
            this.gate_pic.BackgroundImage = global::Bomberman.Properties.Resources.gate;
            this.gate_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gate_pic.Location = new System.Drawing.Point(772, 171);
            this.gate_pic.Name = "gate_pic";
            this.gate_pic.Size = new System.Drawing.Size(41, 42);
            this.gate_pic.TabIndex = 3;
            this.gate_pic.TabStop = false;
            this.gate_pic.Tag = "";
            // 
            // sprite
            // 
            this.sprite.BackgroundImage = global::Bomberman.Properties.Resources.fros;
            this.sprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sprite.Location = new System.Drawing.Point(36, 38);
            this.sprite.Name = "sprite";
            this.sprite.Size = new System.Drawing.Size(41, 42);
            this.sprite.TabIndex = 0;
            this.sprite.TabStop = false;
            this.sprite.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(805, 413);
            this.Controls.Add(this.gate_pic);
            this.Controls.Add(this.game_over);
            this.Controls.Add(this.sprite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gate_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sprite;
        public System.Windows.Forms.Timer movingtimer;
        private System.Windows.Forms.Label game_over;
        private System.Windows.Forms.PictureBox gate_pic;
    }
}

