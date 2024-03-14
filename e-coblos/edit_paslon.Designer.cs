namespace e_coblos
{
    partial class edit_paslon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edit_paslon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_update_nama_paslon = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxFotoPaslon = new System.Windows.Forms.PictureBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_update_gambar = new System.Windows.Forms.Button();
            this.rich_txt_update_visi_misi_passlon = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoPaslon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 77);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(172, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edit Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama :";
            // 
            // txt_update_nama_paslon
            // 
            this.txt_update_nama_paslon.Location = new System.Drawing.Point(121, 61);
            this.txt_update_nama_paslon.Name = "txt_update_nama_paslon";
            this.txt_update_nama_paslon.Size = new System.Drawing.Size(251, 22);
            this.txt_update_nama_paslon.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBoxFotoPaslon);
            this.panel2.Controls.Add(this.btn_update);
            this.panel2.Controls.Add(this.btn_update_gambar);
            this.panel2.Controls.Add(this.rich_txt_update_visi_misi_passlon);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_update_nama_paslon);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 562);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Edit Foto :";
            // 
            // pictureBoxFotoPaslon
            // 
            this.pictureBoxFotoPaslon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFotoPaslon.Image")));
            this.pictureBoxFotoPaslon.Location = new System.Drawing.Point(179, 315);
            this.pictureBoxFotoPaslon.Name = "pictureBoxFotoPaslon";
            this.pictureBoxFotoPaslon.Size = new System.Drawing.Size(141, 128);
            this.pictureBoxFotoPaslon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFotoPaslon.TabIndex = 11;
            this.pictureBoxFotoPaslon.TabStop = false;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(209, 522);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 27);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_update_gambar
            // 
            this.btn_update_gambar.Location = new System.Drawing.Point(165, 464);
            this.btn_update_gambar.Name = "btn_update_gambar";
            this.btn_update_gambar.Size = new System.Drawing.Size(163, 41);
            this.btn_update_gambar.TabIndex = 8;
            this.btn_update_gambar.Text = "Upload Gambar Paslon";
            this.btn_update_gambar.UseVisualStyleBackColor = true;
            this.btn_update_gambar.Click += new System.EventHandler(this.btn_update_gambar_Click);
            // 
            // rich_txt_update_visi_misi_passlon
            // 
            this.rich_txt_update_visi_misi_passlon.Location = new System.Drawing.Point(121, 153);
            this.rich_txt_update_visi_misi_passlon.Name = "rich_txt_update_visi_misi_passlon";
            this.rich_txt_update_visi_misi_passlon.Size = new System.Drawing.Size(251, 96);
            this.rich_txt_update_visi_misi_passlon.TabIndex = 7;
            this.rich_txt_update_visi_misi_passlon.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(117, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Visi Misi :";
            // 
            // edit_paslon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "edit_paslon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.edit_paslon_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoPaslon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_update_nama_paslon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_update_gambar;
        private System.Windows.Forms.RichTextBox rich_txt_update_visi_misi_passlon;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.PictureBox pictureBoxFotoPaslon;
        private System.Windows.Forms.Label label5;
    }
}