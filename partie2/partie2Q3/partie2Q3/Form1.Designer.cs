namespace partie2Q3
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTri = new System.Windows.Forms.Button();
            this.listBoxExemples = new System.Windows.Forms.ListBox();
            this.buttonExeAppr = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelW1init = new System.Windows.Forms.Label();
            this.labelW3init = new System.Windows.Forms.Label();
            this.labelW2init = new System.Windows.Forms.Label();
            this.labelW2fin = new System.Windows.Forms.Label();
            this.labelW3fin = new System.Windows.Forms.Label();
            this.labelW1fin = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_nbIterations = new System.Windows.Forms.Label();
            this.label_nbErreurs = new System.Windows.Forms.Label();
            this.pictBoxPlot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTri
            // 
            this.buttonTri.Location = new System.Drawing.Point(345, 48);
            this.buttonTri.Name = "buttonTri";
            this.buttonTri.Size = new System.Drawing.Size(75, 23);
            this.buttonTri.TabIndex = 1;
            this.buttonTri.Text = "Trier la liste";
            this.buttonTri.UseVisualStyleBackColor = true;
            this.buttonTri.Click += new System.EventHandler(this.buttonTri_Click);
            // 
            // listBoxExemples
            // 
            this.listBoxExemples.FormattingEnabled = true;
            this.listBoxExemples.Location = new System.Drawing.Point(29, 24);
            this.listBoxExemples.Name = "listBoxExemples";
            this.listBoxExemples.Size = new System.Drawing.Size(257, 472);
            this.listBoxExemples.TabIndex = 2;
            // 
            // buttonExeAppr
            // 
            this.buttonExeAppr.Location = new System.Drawing.Point(345, 168);
            this.buttonExeAppr.Name = "buttonExeAppr";
            this.buttonExeAppr.Size = new System.Drawing.Size(93, 39);
            this.buttonExeAppr.TabIndex = 3;
            this.buttonExeAppr.Text = "Executer l\'apprentissage";
            this.buttonExeAppr.UseVisualStyleBackColor = true;
            this.buttonExeAppr.Click += new System.EventHandler(this.buttonExeAppr_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(345, 103);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(75, 41);
            this.buttonInit.TabIndex = 4;
            this.buttonInit.Text = "Initialiser le réseau";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(587, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "poids initiaux : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(695, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "w1 = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(695, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "w3 = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(695, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "w2 = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(695, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "w2 = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(695, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "w3 = ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(695, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "w1 = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "poids finaux : ";
            // 
            // labelW1init
            // 
            this.labelW1init.AutoSize = true;
            this.labelW1init.Location = new System.Drawing.Point(735, 34);
            this.labelW1init.Name = "labelW1init";
            this.labelW1init.Size = new System.Drawing.Size(13, 13);
            this.labelW1init.TabIndex = 13;
            this.labelW1init.Text = "¤";
            // 
            // labelW3init
            // 
            this.labelW3init.AutoSize = true;
            this.labelW3init.Location = new System.Drawing.Point(734, 64);
            this.labelW3init.Name = "labelW3init";
            this.labelW3init.Size = new System.Drawing.Size(13, 13);
            this.labelW3init.TabIndex = 14;
            this.labelW3init.Text = "¤";
            // 
            // labelW2init
            // 
            this.labelW2init.AutoSize = true;
            this.labelW2init.Location = new System.Drawing.Point(735, 48);
            this.labelW2init.Name = "labelW2init";
            this.labelW2init.Size = new System.Drawing.Size(13, 13);
            this.labelW2init.TabIndex = 15;
            this.labelW2init.Text = "¤";
            // 
            // labelW2fin
            // 
            this.labelW2fin.AutoSize = true;
            this.labelW2fin.Location = new System.Drawing.Point(736, 117);
            this.labelW2fin.Name = "labelW2fin";
            this.labelW2fin.Size = new System.Drawing.Size(13, 13);
            this.labelW2fin.TabIndex = 18;
            this.labelW2fin.Text = "¤";
            // 
            // labelW3fin
            // 
            this.labelW3fin.AutoSize = true;
            this.labelW3fin.Location = new System.Drawing.Point(735, 133);
            this.labelW3fin.Name = "labelW3fin";
            this.labelW3fin.Size = new System.Drawing.Size(13, 13);
            this.labelW3fin.TabIndex = 17;
            this.labelW3fin.Text = "¤";
            // 
            // labelW1fin
            // 
            this.labelW1fin.AutoSize = true;
            this.labelW1fin.Location = new System.Drawing.Point(736, 103);
            this.labelW1fin.Name = "labelW1fin";
            this.labelW1fin.Size = new System.Drawing.Size(13, 13);
            this.labelW1fin.TabIndex = 16;
            this.labelW1fin.Text = "¤";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(590, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "nombre d\'itérations :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(590, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "nombre d\'erreurs :";
            // 
            // label_nbIterations
            // 
            this.label_nbIterations.AutoSize = true;
            this.label_nbIterations.Location = new System.Drawing.Point(715, 193);
            this.label_nbIterations.Name = "label_nbIterations";
            this.label_nbIterations.Size = new System.Drawing.Size(13, 13);
            this.label_nbIterations.TabIndex = 21;
            this.label_nbIterations.Text = "¤";
            // 
            // label_nbErreurs
            // 
            this.label_nbErreurs.AutoSize = true;
            this.label_nbErreurs.Location = new System.Drawing.Point(715, 229);
            this.label_nbErreurs.Name = "label_nbErreurs";
            this.label_nbErreurs.Size = new System.Drawing.Size(13, 13);
            this.label_nbErreurs.TabIndex = 22;
            this.label_nbErreurs.Text = "¤";
            // 
            // pictBoxPlot
            // 
            this.pictBoxPlot.Image = global::partie2Q3.Properties.Resources.blank1;
            this.pictBoxPlot.Location = new System.Drawing.Point(331, 274);
            this.pictBoxPlot.Name = "pictBoxPlot";
            this.pictBoxPlot.Size = new System.Drawing.Size(200, 200);
            this.pictBoxPlot.TabIndex = 23;
            this.pictBoxPlot.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 542);
            this.Controls.Add(this.pictBoxPlot);
            this.Controls.Add(this.label_nbErreurs);
            this.Controls.Add(this.label_nbIterations);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelW2fin);
            this.Controls.Add(this.labelW3fin);
            this.Controls.Add(this.labelW1fin);
            this.Controls.Add(this.labelW2init);
            this.Controls.Add(this.labelW3init);
            this.Controls.Add(this.labelW1init);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInit);
            this.Controls.Add(this.buttonExeAppr);
            this.Controls.Add(this.listBoxExemples);
            this.Controls.Add(this.buttonTri);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonTri;
        private System.Windows.Forms.ListBox listBoxExemples;
        private System.Windows.Forms.Button buttonExeAppr;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelW1init;
        private System.Windows.Forms.Label labelW3init;
        private System.Windows.Forms.Label labelW2init;
        private System.Windows.Forms.Label labelW2fin;
        private System.Windows.Forms.Label labelW3fin;
        private System.Windows.Forms.Label labelW1fin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_nbIterations;
        private System.Windows.Forms.Label label_nbErreurs;
        private System.Windows.Forms.PictureBox pictBoxPlot;
    }
}

