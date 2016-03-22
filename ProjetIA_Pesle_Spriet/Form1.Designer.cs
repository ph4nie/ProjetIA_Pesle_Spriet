namespace ProjetIA_Pesle_Spriet
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
            this.button_calculePlusCourtChemin = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox_noeudInit = new System.Windows.Forms.TextBox();
            this.textBox_noeudFinal = new System.Windows.Forms.TextBox();
            this.listBoxChemin = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelChemin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_calculePlusCourtChemin
            // 
            this.button_calculePlusCourtChemin.Location = new System.Drawing.Point(70, 101);
            this.button_calculePlusCourtChemin.Name = "button_calculePlusCourtChemin";
            this.button_calculePlusCourtChemin.Size = new System.Drawing.Size(86, 36);
            this.button_calculePlusCourtChemin.TabIndex = 0;
            this.button_calculePlusCourtChemin.Text = "Calculer le + court chemin";
            this.button_calculePlusCourtChemin.UseVisualStyleBackColor = true;
            this.button_calculePlusCourtChemin.Click += new System.EventHandler(this.buttonCourtChemin_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(342, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(276, 329);
            this.treeView1.TabIndex = 1;
            // 
            // textBox_noeudInit
            // 
            this.textBox_noeudInit.Location = new System.Drawing.Point(12, 52);
            this.textBox_noeudInit.Name = "textBox_noeudInit";
            this.textBox_noeudInit.Size = new System.Drawing.Size(86, 20);
            this.textBox_noeudInit.TabIndex = 2;
            // 
            // textBox_noeudFinal
            // 
            this.textBox_noeudFinal.Location = new System.Drawing.Point(143, 52);
            this.textBox_noeudFinal.Name = "textBox_noeudFinal";
            this.textBox_noeudFinal.Size = new System.Drawing.Size(86, 20);
            this.textBox_noeudFinal.TabIndex = 3;
            // 
            // listBoxChemin
            // 
            this.listBoxChemin.FormattingEnabled = true;
            this.listBoxChemin.Location = new System.Drawing.Point(13, 202);
            this.listBoxChemin.Name = "listBoxChemin";
            this.listBoxChemin.Size = new System.Drawing.Size(35, 95);
            this.listBoxChemin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "noeud initial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "noeud final";
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.Location = new System.Drawing.Point(16, 183);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(47, 13);
            this.labelChemin.TabIndex = 7;
            this.labelChemin.Text = "chemin :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "cout associé : ";
            // 
            // textBoxCout
            // 
            this.textBoxCout.Location = new System.Drawing.Point(102, 202);
            this.textBoxCout.Name = "textBoxCout";
            this.textBoxCout.Size = new System.Drawing.Size(100, 20);
            this.textBoxCout.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 353);
            this.Controls.Add(this.textBoxCout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxChemin);
            this.Controls.Add(this.textBox_noeudFinal);
            this.Controls.Add(this.textBox_noeudInit);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button_calculePlusCourtChemin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_calculePlusCourtChemin;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox_noeudInit;
        private System.Windows.Forms.TextBox textBox_noeudFinal;
        private System.Windows.Forms.ListBox listBoxChemin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCout;
    }
}

