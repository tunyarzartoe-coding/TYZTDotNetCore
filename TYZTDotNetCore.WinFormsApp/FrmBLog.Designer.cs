namespace ZackDotNet.WinFormsApp
{
    partial class FrmBLog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            txtTitle = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 39);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 1;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 103);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 2;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 167);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 3;
            label3.Text = "Content :";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(204, 126);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(387, 26);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(204, 190);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(387, 90);
            txtContent.TabIndex = 5;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(204, 62);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(387, 26);
            txtTitle.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(304, 302);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "&Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnSave_Click;

            // 
            // button2
            // 
            button2.BackColor = SystemColors.AppWorkspace;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(204, 302);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnCancel_Click;
            // 
            // FrmBLog
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtTitle);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmBLog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private TextBox txtTitle;
        private Button button1;
        private Button button2;
    }
}
