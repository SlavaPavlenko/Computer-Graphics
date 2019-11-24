namespace Image_processing
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.alg2_pictureBox = new System.Windows.Forms.PictureBox();
            this.alg1_pictureBox = new System.Windows.Forms.PictureBox();
            this.grey_label = new System.Windows.Forms.Label();
            this.grey_pictureBox = new System.Windows.Forms.PictureBox();
            this.process_button = new System.Windows.Forms.Button();
            this.original_label = new System.Windows.Forms.Label();
            this.original_pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edge_textBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alg2_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alg1_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grey_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.original_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edge_textBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.alg2_pictureBox);
            this.panel1.Controls.Add(this.alg1_pictureBox);
            this.panel1.Controls.Add(this.grey_label);
            this.panel1.Controls.Add(this.grey_pictureBox);
            this.panel1.Controls.Add(this.process_button);
            this.panel1.Controls.Add(this.original_label);
            this.panel1.Controls.Add(this.original_pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 242);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "градиентный метод";
            // 
            // alg2_pictureBox
            // 
            this.alg2_pictureBox.Location = new System.Drawing.Point(482, 47);
            this.alg2_pictureBox.Name = "alg2_pictureBox";
            this.alg2_pictureBox.Size = new System.Drawing.Size(150, 150);
            this.alg2_pictureBox.TabIndex = 7;
            this.alg2_pictureBox.TabStop = false;
            // 
            // alg1_pictureBox
            // 
            this.alg1_pictureBox.Location = new System.Drawing.Point(325, 47);
            this.alg1_pictureBox.Name = "alg1_pictureBox";
            this.alg1_pictureBox.Size = new System.Drawing.Size(150, 150);
            this.alg1_pictureBox.TabIndex = 6;
            this.alg1_pictureBox.TabStop = false;
            // 
            // grey_label
            // 
            this.grey_label.AutoSize = true;
            this.grey_label.Location = new System.Drawing.Point(171, 28);
            this.grey_label.Name = "grey_label";
            this.grey_label.Size = new System.Drawing.Size(85, 13);
            this.grey_label.TabIndex = 5;
            this.grey_label.Text = "оттенки серого";
            // 
            // grey_pictureBox
            // 
            this.grey_pictureBox.Location = new System.Drawing.Point(168, 47);
            this.grey_pictureBox.Name = "grey_pictureBox";
            this.grey_pictureBox.Size = new System.Drawing.Size(150, 150);
            this.grey_pictureBox.TabIndex = 4;
            this.grey_pictureBox.TabStop = false;
            // 
            // process_button
            // 
            this.process_button.Location = new System.Drawing.Point(12, 208);
            this.process_button.Name = "process_button";
            this.process_button.Size = new System.Drawing.Size(93, 23);
            this.process_button.TabIndex = 3;
            this.process_button.Text = "Обработать";
            this.process_button.UseVisualStyleBackColor = true;
            this.process_button.Click += new System.EventHandler(this.Process_button_Click);
            // 
            // original_label
            // 
            this.original_label.AutoSize = true;
            this.original_label.Location = new System.Drawing.Point(13, 28);
            this.original_label.Name = "original_label";
            this.original_label.Size = new System.Drawing.Size(54, 13);
            this.original_label.TabIndex = 2;
            this.original_label.Text = "оригинал";
            // 
            // original_pictureBox
            // 
            this.original_pictureBox.Location = new System.Drawing.Point(12, 47);
            this.original_pictureBox.Name = "original_pictureBox";
            this.original_pictureBox.Size = new System.Drawing.Size(150, 150);
            this.original_pictureBox.TabIndex = 0;
            this.original_pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Граница:";
            // 
            // edge_textBox
            // 
            this.edge_textBox.Location = new System.Drawing.Point(384, 204);
            this.edge_textBox.Name = "edge_textBox";
            this.edge_textBox.Size = new System.Drawing.Size(91, 20);
            this.edge_textBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 242);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alg2_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alg1_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grey_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.original_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label grey_label;
        private System.Windows.Forms.PictureBox grey_pictureBox;
        private System.Windows.Forms.Button process_button;
        private System.Windows.Forms.Label original_label;
        private System.Windows.Forms.PictureBox original_pictureBox;
        private System.Windows.Forms.PictureBox alg1_pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox alg2_pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edge_textBox;
        private System.Windows.Forms.Label label3;
    }
}

