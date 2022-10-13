namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.send = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.messages = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(317, 203);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(52, 23);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(108, 203);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(128, 20);
            this.name.TabIndex = 1;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(104, 138);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(265, 44);
            this.title.TabIndex = 2;
            this.title.Text = "Write your name and suraname,\r\nno spaces all lower";
            // 
            // messages
            // 
            this.messages.Location = new System.Drawing.Point(416, 95);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(231, 131);
            this.messages.TabIndex = 3;
            this.messages.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 381);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.title);
            this.Controls.Add(this.name);
            this.Controls.Add(this.send);
            this.MaximumSize = new System.Drawing.Size(700, 420);
            this.MinimumSize = new System.Drawing.Size(700, 420);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label messages;
    }
}

