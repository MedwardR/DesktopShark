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
			ChompChance = new NumericUpDown();
			label5 = new Label();
			AlwaysOnTop = new CheckBox();
			FollowCursor = new CheckBox();
			EnableCursorChomping = new CheckBox();
			label3 = new Label();
			MoveSpeed = new NumericUpDown();
			label2 = new Label();
			MoveInterval = new NumericUpDown();
			label4 = new Label();
			FramesPerSecond = new NumericUpDown();
			ApplyButton = new Button();
			OkButton = new Button();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ChompChance).BeginInit();
			((System.ComponentModel.ISupportInitialize)MoveSpeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)MoveInterval).BeginInit();
			((System.ComponentModel.ISupportInitialize)FramesPerSecond).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			label1.AutoEllipsis = true;
			label1.Font = new Font("Disgusting Behavior", 40F);
			label1.Location = new Point(18, 20);
			label1.Margin = new Padding(3);
			label1.Name = "label1";
			label1.Size = new Size(287, 77);
			label1.TabIndex = 2;
			label1.Text = "Shark Settings";
			label1.TextAlign = ContentAlignment.TopCenter;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(ChompChance, 1, 5);
			tableLayoutPanel1.Controls.Add(label5, 1, 4);
			tableLayoutPanel1.Controls.Add(AlwaysOnTop, 0, 0);
			tableLayoutPanel1.Controls.Add(FollowCursor, 1, 0);
			tableLayoutPanel1.Controls.Add(EnableCursorChomping, 0, 1);
			tableLayoutPanel1.Controls.Add(label3, 1, 2);
			tableLayoutPanel1.Controls.Add(MoveSpeed, 1, 3);
			tableLayoutPanel1.Controls.Add(label2, 0, 2);
			tableLayoutPanel1.Controls.Add(MoveInterval, 0, 3);
			tableLayoutPanel1.Controls.Add(label4, 0, 4);
			tableLayoutPanel1.Controls.Add(FramesPerSecond, 0, 5);
			tableLayoutPanel1.Location = new Point(27, 103);
			tableLayoutPanel1.Margin = new Padding(12, 3, 12, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 6;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(269, 222);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// ChompChance
			// 
			ChompChance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ChompChance.Font = new Font("Aquifer", 12F);
			ChompChance.Location = new Point(137, 177);
			ChompChance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			ChompChance.Name = "ChompChance";
			ChompChance.Size = new Size(129, 27);
			ChompChance.TabIndex = 13;
			ChompChance.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F);
			label5.Location = new Point(137, 150);
			label5.Margin = new Padding(3);
			label5.Name = "label5";
			label5.Size = new Size(113, 21);
			label5.TabIndex = 12;
			label5.Text = "Chomp chance";
			// 
			// AlwaysOnTop
			// 
			AlwaysOnTop.AutoSize = true;
			AlwaysOnTop.Font = new Font("Segoe UI", 12F);
			AlwaysOnTop.Location = new Point(3, 3);
			AlwaysOnTop.Name = "AlwaysOnTop";
			AlwaysOnTop.Size = new Size(127, 25);
			AlwaysOnTop.TabIndex = 3;
			AlwaysOnTop.Text = "Always on top";
			AlwaysOnTop.UseVisualStyleBackColor = true;
			// 
			// FollowCursor
			// 
			FollowCursor.AutoSize = true;
			FollowCursor.Font = new Font("Segoe UI", 12F);
			FollowCursor.Location = new Point(137, 3);
			FollowCursor.Name = "FollowCursor";
			FollowCursor.Size = new Size(123, 25);
			FollowCursor.TabIndex = 4;
			FollowCursor.Text = "Follow cursor";
			FollowCursor.UseVisualStyleBackColor = true;
			// 
			// EnableCursorChomping
			// 
			EnableCursorChomping.AutoSize = true;
			tableLayoutPanel1.SetColumnSpan(EnableCursorChomping, 2);
			EnableCursorChomping.Font = new Font("Segoe UI", 12F);
			EnableCursorChomping.Location = new Point(3, 43);
			EnableCursorChomping.Name = "EnableCursorChomping";
			EnableCursorChomping.Size = new Size(197, 25);
			EnableCursorChomping.TabIndex = 5;
			EnableCursorChomping.Text = "Enable cursor chomping";
			EnableCursorChomping.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F);
			label3.Location = new Point(137, 83);
			label3.Margin = new Padding(3);
			label3.Name = "label3";
			label3.Size = new Size(94, 21);
			label3.TabIndex = 7;
			label3.Text = "Move speed";
			// 
			// MoveSpeed
			// 
			MoveSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			MoveSpeed.Font = new Font("Aquifer", 12F);
			MoveSpeed.Location = new Point(137, 110);
			MoveSpeed.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			MoveSpeed.Name = "MoveSpeed";
			MoveSpeed.Size = new Size(129, 27);
			MoveSpeed.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(3, 83);
			label2.Margin = new Padding(3);
			label2.Name = "label2";
			label2.Size = new Size(105, 21);
			label2.TabIndex = 6;
			label2.Text = "Move interval";
			// 
			// MoveInterval
			// 
			MoveInterval.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			MoveInterval.Font = new Font("Aquifer", 12F);
			MoveInterval.Location = new Point(3, 110);
			MoveInterval.Name = "MoveInterval";
			MoveInterval.Size = new Size(128, 27);
			MoveInterval.TabIndex = 9;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F);
			label4.Location = new Point(3, 150);
			label4.Margin = new Padding(3);
			label4.Name = "label4";
			label4.Size = new Size(36, 21);
			label4.TabIndex = 10;
			label4.Text = "FPS";
			// 
			// FramesPerSecond
			// 
			FramesPerSecond.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			FramesPerSecond.Font = new Font("Aquifer", 12F);
			FramesPerSecond.Location = new Point(3, 177);
			FramesPerSecond.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			FramesPerSecond.Name = "FramesPerSecond";
			FramesPerSecond.Size = new Size(128, 27);
			FramesPerSecond.TabIndex = 11;
			// 
			// ApplyButton
			// 
			ApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			ApplyButton.BackColor = Color.Black;
			ApplyButton.FlatStyle = FlatStyle.Flat;
			ApplyButton.Font = new Font("Segoe UI", 14F);
			ApplyButton.Location = new Point(155, 331);
			ApplyButton.Name = "ApplyButton";
			ApplyButton.Size = new Size(82, 40);
			ApplyButton.TabIndex = 12;
			ApplyButton.Text = "Apply";
			ApplyButton.UseVisualStyleBackColor = false;
			ApplyButton.Click += ApplyButton_Click;
			// 
			// OkButton
			// 
			OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			OkButton.BackColor = Color.Black;
			OkButton.FlatStyle = FlatStyle.Flat;
			OkButton.Font = new Font("Segoe UI", 14F);
			OkButton.Location = new Point(243, 331);
			OkButton.Name = "OkButton";
			OkButton.Size = new Size(53, 40);
			OkButton.TabIndex = 13;
			OkButton.Text = "OK";
			OkButton.UseVisualStyleBackColor = false;
			OkButton.Click += OkButton_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(40, 40, 40);
			ClientSize = new Size(323, 391);
			Controls.Add(OkButton);
			Controls.Add(label1);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(ApplyButton);
			Font = new Font("Segoe UI", 12F);
			ForeColor = Color.White;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MinimumSize = new Size(339, 430);
			Name = "MainForm";
			Padding = new Padding(15, 17, 15, 17);
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Settings";
			Load += MainForm_Load;
			VisibleChanged += MainForm_VisibleChanged;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ChompChance).EndInit();
			((System.ComponentModel.ISupportInitialize)MoveSpeed).EndInit();
			((System.ComponentModel.ISupportInitialize)MoveInterval).EndInit();
			((System.ComponentModel.ISupportInitialize)FramesPerSecond).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private TableLayoutPanel tableLayoutPanel1;
		private CheckBox AlwaysOnTop;
		private CheckBox FollowCursor;
		private CheckBox EnableCursorChomping;
		private Label label2;
		private Label label3;
		private NumericUpDown MoveSpeed;
		private NumericUpDown MoveInterval;
		private Label label4;
		private NumericUpDown FramesPerSecond;
		private Button ApplyButton;
		private Button OkButton;
		private Label label5;
		private NumericUpDown ChompChance;
	}
}