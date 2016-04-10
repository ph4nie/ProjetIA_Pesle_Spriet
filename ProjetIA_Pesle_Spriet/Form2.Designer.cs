namespace ProjetIA_Pesle_Spriet
{
    partial class Form2
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
            this.checkedListBoxNoeuds = new System.Windows.Forms.CheckedListBox();
            this.labelChemin = new System.Windows.Forms.Label();
            this.labelCout = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalculeItineraire = new System.Windows.Forms.Button();
            this.labelAfficheChemin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxNoeuds
            // 
            this.checkedListBoxNoeuds.ColumnWidth = 50;
            this.checkedListBoxNoeuds.FormattingEnabled = true;
            this.checkedListBoxNoeuds.Items.AddRange(new object[] {
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W"});
            this.checkedListBoxNoeuds.Location = new System.Drawing.Point(26, 12);
            this.checkedListBoxNoeuds.MultiColumn = true;
            this.checkedListBoxNoeuds.Name = "checkedListBoxNoeuds";
            this.checkedListBoxNoeuds.Size = new System.Drawing.Size(109, 199);
            this.checkedListBoxNoeuds.TabIndex = 0;
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.Location = new System.Drawing.Point(329, 100);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(50, 13);
            this.labelChemin.TabIndex = 2;
            this.labelChemin.Text = "chemin : ";
            // 
            // labelCout
            // 
            this.labelCout.AutoSize = true;
            this.labelCout.Location = new System.Drawing.Point(372, 124);
            this.labelCout.Name = "labelCout";
            this.labelCout.Size = new System.Drawing.Size(13, 13);
            this.labelCout.TabIndex = 3;
            this.labelCout.Text = "¤";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "cout =";
            // 
            // buttonCalculeItineraire
            // 
            this.buttonCalculeItineraire.Location = new System.Drawing.Point(188, 56);
            this.buttonCalculeItineraire.Name = "buttonCalculeItineraire";
            this.buttonCalculeItineraire.Size = new System.Drawing.Size(82, 83);
            this.buttonCalculeItineraire.TabIndex = 5;
            this.buttonCalculeItineraire.Text = "Calculer le meilleur initnéraire";
            this.buttonCalculeItineraire.UseVisualStyleBackColor = true;
            this.buttonCalculeItineraire.Click += new System.EventHandler(this.CalculeItineraire);
            // 
            // labelAfficheChemin
            // 
            this.labelAfficheChemin.AutoSize = true;
            this.labelAfficheChemin.Location = new System.Drawing.Point(385, 100);
            this.labelAfficheChemin.Name = "labelAfficheChemin";
            this.labelAfficheChemin.Size = new System.Drawing.Size(13, 13);
            this.labelAfficheChemin.TabIndex = 6;
            this.labelAfficheChemin.Text = "¤";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "points selectionnés :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "¤";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 290);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAfficheChemin);
            this.Controls.Add(this.buttonCalculeItineraire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCout);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.checkedListBoxNoeuds);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxNoeuds;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.Label labelCout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalculeItineraire;
        private System.Windows.Forms.Label labelAfficheChemin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}