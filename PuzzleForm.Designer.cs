namespace TimeSaver
{
    partial class PuzzleForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuzzleForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddNodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLinkBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLokoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTargetBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.DelNodeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DelLinkBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DelCarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DelLokoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DelTargetBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkBtn = new System.Windows.Forms.ToolStripButton();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.timerUpdateView = new System.Windows.Forms.Timer(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.WorkBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(887, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNodeBtn,
            this.AddLinkBtn,
            this.AddCarBtn,
            this.AddLokoBtn,
            this.AddTargetBtn});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(81, 22);
            this.toolStripDropDownButton1.Text = "Добавить...";
            // 
            // AddNodeBtn
            // 
            this.AddNodeBtn.Name = "AddNodeBtn";
            this.AddNodeBtn.Size = new System.Drawing.Size(182, 22);
            this.AddNodeBtn.Text = "Вершину";
            this.AddNodeBtn.Click += new System.EventHandler(this.AddNodeBtn_Click);
            // 
            // AddLinkBtn
            // 
            this.AddLinkBtn.Name = "AddLinkBtn";
            this.AddLinkBtn.Size = new System.Drawing.Size(182, 22);
            this.AddLinkBtn.Text = "Связь";
            this.AddLinkBtn.Click += new System.EventHandler(this.AddLinkBtn_Click);
            // 
            // AddCarBtn
            // 
            this.AddCarBtn.Name = "AddCarBtn";
            this.AddCarBtn.Size = new System.Drawing.Size(182, 22);
            this.AddCarBtn.Text = "Вагон";
            this.AddCarBtn.Click += new System.EventHandler(this.AddCarBtn_Click);
            // 
            // AddLokoBtn
            // 
            this.AddLokoBtn.Name = "AddLokoBtn";
            this.AddLokoBtn.Size = new System.Drawing.Size(182, 22);
            this.AddLokoBtn.Text = "Локомотив";
            this.AddLokoBtn.Click += new System.EventHandler(this.AddLokoBtn_Click);
            // 
            // AddTargetBtn
            // 
            this.AddTargetBtn.Name = "AddTargetBtn";
            this.AddTargetBtn.Size = new System.Drawing.Size(182, 22);
            this.AddTargetBtn.Text = "Конечную станцию";
            this.AddTargetBtn.Click += new System.EventHandler(this.AddTargetBtn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelNodeBtn,
            this.DelLinkBtn,
            this.DelCarBtn,
            this.DelLokoBtn,
            this.DelTargetBtn});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(73, 22);
            this.toolStripDropDownButton2.Text = "Удалить...";
            // 
            // DelNodeBtn
            // 
            this.DelNodeBtn.Name = "DelNodeBtn";
            this.DelNodeBtn.Size = new System.Drawing.Size(182, 22);
            this.DelNodeBtn.Text = "Вершину";
            this.DelNodeBtn.Click += new System.EventHandler(this.DelNodeBtn_Click);
            // 
            // DelLinkBtn
            // 
            this.DelLinkBtn.Name = "DelLinkBtn";
            this.DelLinkBtn.Size = new System.Drawing.Size(182, 22);
            this.DelLinkBtn.Text = "Связь";
            this.DelLinkBtn.Click += new System.EventHandler(this.DelLinkBtn_Click);
            // 
            // DelCarBtn
            // 
            this.DelCarBtn.Name = "DelCarBtn";
            this.DelCarBtn.Size = new System.Drawing.Size(182, 22);
            this.DelCarBtn.Text = "Вагон";
            this.DelCarBtn.Click += new System.EventHandler(this.DelCarBtn_Click);
            // 
            // DelLokoBtn
            // 
            this.DelLokoBtn.Name = "DelLokoBtn";
            this.DelLokoBtn.Size = new System.Drawing.Size(182, 22);
            this.DelLokoBtn.Text = "Локомотив";
            this.DelLokoBtn.Click += new System.EventHandler(this.DelLokoBtn_Click);
            // 
            // DelTargetBtn
            // 
            this.DelTargetBtn.Name = "DelTargetBtn";
            this.DelTargetBtn.Size = new System.Drawing.Size(182, 22);
            this.DelTargetBtn.Text = "Конечную станцию";
            this.DelTargetBtn.Click += new System.EventHandler(this.DelTargetBtn_Click);
            // 
            // WorkBtn
            // 
            this.WorkBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.WorkBtn.Image = ((System.Drawing.Image)(resources.GetObject("WorkBtn.Image")));
            this.WorkBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WorkBtn.Name = "WorkBtn";
            this.WorkBtn.Size = new System.Drawing.Size(73, 22);
            this.WorkBtn.Text = "Выполнить";
            this.WorkBtn.Click += new System.EventHandler(this.WorkBtn_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageLabel.Location = new System.Drawing.Point(0, 25);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(887, 23);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerUpdateView
            // 
            this.timerUpdateView.Interval = 600;
            this.timerUpdateView.Tick += new System.EventHandler(this.timerUpdateView_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.ToolStripButton WorkBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem AddNodeBtn;
        private System.Windows.Forms.ToolStripMenuItem AddLinkBtn;
        private System.Windows.Forms.ToolStripMenuItem AddCarBtn;
        private System.Windows.Forms.ToolStripMenuItem AddLokoBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem DelNodeBtn;
        private System.Windows.Forms.ToolStripMenuItem DelLinkBtn;
        private System.Windows.Forms.ToolStripMenuItem DelCarBtn;
        private System.Windows.Forms.ToolStripMenuItem DelLokoBtn;
        private System.Windows.Forms.Timer timerUpdateView;
        private System.Windows.Forms.ToolStripMenuItem AddTargetBtn;
        private System.Windows.Forms.ToolStripMenuItem DelTargetBtn;
    }
}

