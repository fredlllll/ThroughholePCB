namespace ThroughholePCB
{
    partial class TextToolDialog
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
            label1 = new Label();
            label2 = new Label();
            fontSizeNum = new NumericUpDown();
            text = new TextBox();
            okBtn = new Button();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)fontSizeNum).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Font Size(mm):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 39);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Text:";
            // 
            // fontSizeNum
            // 
            fontSizeNum.DecimalPlaces = 1;
            fontSizeNum.Increment = new decimal(new int[] { 3, 0, 0, 65536 });
            fontSizeNum.Location = new Point(105, 7);
            fontSizeNum.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            fontSizeNum.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            fontSizeNum.Name = "fontSizeNum";
            fontSizeNum.Size = new Size(120, 23);
            fontSizeNum.TabIndex = 2;
            fontSizeNum.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // text
            // 
            text.Location = new Point(105, 36);
            text.Name = "text";
            text.Size = new Size(683, 23);
            text.TabIndex = 3;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(713, 65);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(75, 23);
            okBtn.TabIndex = 4;
            okBtn.Text = "Ok";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(632, 65);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // TextToolDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 101);
            ControlBox = false;
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(text);
            Controls.Add(fontSizeNum);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TextToolDialog";
            Text = "TextToolDialog";
            ((System.ComponentModel.ISupportInitialize)fontSizeNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown fontSizeNum;
        private TextBox text;
        private Button okBtn;
        private Button cancelBtn;
    }
}