
namespace server
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
            this.OnOff = new System.Windows.Forms.Button();
            this.state = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OnOff
            // 
            this.OnOff.Location = new System.Drawing.Point(423, 154);
            this.OnOff.Name = "OnOff";
            this.OnOff.Size = new System.Drawing.Size(75, 23);
            this.OnOff.TabIndex = 0;
            this.OnOff.Text = "Accendi";
            this.OnOff.UseVisualStyleBackColor = true;
            this.OnOff.Click += new System.EventHandler(this.OnOff_Click);
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.state.Location = new System.Drawing.Point(90, 144);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(305, 31);
            this.state.TabIndex = 1;
            this.state.Text = "Stato del server: Spento";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 351);
            this.Controls.Add(this.state);
            this.Controls.Add(this.OnOff);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OnOff;
        public static System.Windows.Forms.Label state;
    }
}

