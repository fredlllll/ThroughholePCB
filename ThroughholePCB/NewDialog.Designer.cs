namespace ThroughholePCB
{
    partial class NewDialog
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
            widthTxt = new TextBox();
            heightTxt = new TextBox();
            okBtn = new Button();
            cancelBtn = new Button();
            printerDropdown = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Width (mm)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 1;
            label2.Text = "Height (mm)";
            // 
            // widthTxt
            // 
            widthTxt.Location = new Point(93, 6);
            widthTxt.Name = "widthTxt";
            widthTxt.Size = new Size(111, 23);
            widthTxt.TabIndex = 2;
            widthTxt.Text = "50.0";
            widthTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // heightTxt
            // 
            heightTxt.Location = new Point(93, 35);
            heightTxt.Name = "heightTxt";
            heightTxt.Size = new Size(111, 23);
            heightTxt.TabIndex = 3;
            heightTxt.Text = "50.0";
            heightTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // okBtn
            // 
            okBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            okBtn.Location = new Point(12, 102);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(75, 23);
            okBtn.TabIndex = 4;
            okBtn.Text = "Ok";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelBtn.Location = new Point(93, 102);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // printerDropdown
            // 
            printerDropdown.FormattingEnabled = true;
            printerDropdown.Location = new Point(60, 68);
            printerDropdown.Name = "printerDropdown";
            printerDropdown.Size = new Size(144, 23);
            printerDropdown.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Printer";
            // 
            // NewDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(216, 137);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(printerDropdown);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(heightTxt);
            Controls.Add(widthTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "NewDialog";
            Text = "New PCB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox widthTxt;
        private TextBox heightTxt;
        private Button okBtn;
        private Button cancelBtn;
        private ComboBox printerDropdown;
        private Label label3;
    }
}