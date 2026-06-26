namespace DesktopShark
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			label1 = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			checkBox1 = new CheckBox();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top;
			label1.AutoEllipsis = true;
			label1.AutoSize = true;
			label1.Font = new Font("Disgusting Behavior", 36F);
			label1.Location = new Point(21, 4);
			label1.Margin = new Padding(4, 4, 4, 4);
			label1.Name = "label1";
			label1.Size = new Size(254, 69);
			label1.TabIndex = 2;
			label1.Text = "Shark Settings";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(checkBox1, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(15, 17);
			tableLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(296, 357);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(4, 81);
			checkBox1.Margin = new Padding(4, 4, 4, 4);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(127, 25);
			checkBox1.TabIndex = 3;
			checkBox1.Text = "Always on top";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(40, 40, 40);
			ClientSize = new Size(326, 391);
			Controls.Add(tableLayoutPanel1);
			Font = new Font("Segoe UI", 12F);
			ForeColor = Color.White;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 4, 4, 4);
			Name = "MainForm";
			Padding = new Padding(15, 17, 15, 17);
			Text = "Settings";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private TableLayoutPanel tableLayoutPanel1;
		private CheckBox checkBox1;
	}
}