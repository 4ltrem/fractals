namespace Fractals
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.topPanel = new System.Windows.Forms.Panel();
            this.paletteComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zoomUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.itérationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.goJuliaButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.goMandelbrotButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.canevasPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itérationsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(467, 5);
            this.progressBar.Maximum = 599;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(102, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.paletteComboBox);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.zoomUpDown);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.itérationsUpDown);
            this.topPanel.Controls.Add(this.goJuliaButton);
            this.topPanel.Controls.Add(this.stopButton);
            this.topPanel.Controls.Add(this.goMandelbrotButton);
            this.topPanel.Controls.Add(this.progressBar);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(600, 33);
            this.topPanel.TabIndex = 2;
            // 
            // paletteComboBox
            // 
            this.paletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paletteComboBox.FormattingEnabled = true;
            this.paletteComboBox.Items.AddRange(new object[] {
            "Aléatoire",
            "Binaire",
            "Modulée"});
            this.paletteComboBox.Location = new System.Drawing.Point(210, 6);
            this.paletteComboBox.Name = "paletteComboBox";
            this.paletteComboBox.Size = new System.Drawing.Size(88, 21);
            this.paletteComboBox.TabIndex = 8;
            this.toolTip.SetToolTip(this.paletteComboBox, "Palette de couleurs");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zoom";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zoomUpDown
            // 
            this.zoomUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.zoomUpDown.Location = new System.Drawing.Point(164, 7);
            this.zoomUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.zoomUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomUpDown.Name = "zoomUpDown";
            this.zoomUpDown.Size = new System.Drawing.Size(40, 20);
            this.zoomUpDown.TabIndex = 7;
            this.toolTip.SetToolTip(this.zoomUpDown, "Facteur d\'agrandissement");
            this.zoomUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Itérations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // itérationsUpDown
            // 
            this.itérationsUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.itérationsUpDown.Location = new System.Drawing.Point(59, 7);
            this.itérationsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.itérationsUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.itérationsUpDown.Name = "itérationsUpDown";
            this.itérationsUpDown.Size = new System.Drawing.Size(58, 20);
            this.itérationsUpDown.TabIndex = 5;
            this.toolTip.SetToolTip(this.itérationsUpDown, "Itérations maximales de fractal");
            this.itérationsUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // goJuliaButton
            // 
            this.goJuliaButton.Location = new System.Drawing.Point(386, 5);
            this.goJuliaButton.Name = "goJuliaButton";
            this.goJuliaButton.Size = new System.Drawing.Size(75, 23);
            this.goJuliaButton.TabIndex = 4;
            this.goJuliaButton.Text = "Julia";
            this.toolTip.SetToolTip(this.goJuliaButton, "Générer un fractal Julia");
            this.goJuliaButton.UseVisualStyleBackColor = true;
            this.goJuliaButton.Click += new System.EventHandler(this.goJuliaButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.Location = new System.Drawing.Point(571, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(26, 23);
            this.stopButton.TabIndex = 3;
            this.toolTip.SetToolTip(this.stopButton, "Annuler la construction de fractal en cours");
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // goMandelbrotButton
            // 
            this.goMandelbrotButton.Location = new System.Drawing.Point(304, 5);
            this.goMandelbrotButton.Name = "goMandelbrotButton";
            this.goMandelbrotButton.Size = new System.Drawing.Size(75, 23);
            this.goMandelbrotButton.TabIndex = 2;
            this.goMandelbrotButton.Text = "Mandelbrot";
            this.toolTip.SetToolTip(this.goMandelbrotButton, "Générer un fractal Mandelbrot");
            this.goMandelbrotButton.UseVisualStyleBackColor = true;
            this.goMandelbrotButton.Click += new System.EventHandler(this.goMandelBrotButton_Click);
            // 
            // canevasPanel
            // 
            this.canevasPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canevasPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canevasPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.canevasPanel.Location = new System.Drawing.Point(0, 34);
            this.canevasPanel.Name = "canevasPanel";
            this.canevasPanel.Size = new System.Drawing.Size(600, 600);
            this.canevasPanel.TabIndex = 3;
            this.canevasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasPanel_Paint);
            this.canevasPanel.MouseLeave += new System.EventHandler(this.canvasPanel_MouseLeave);
            this.canevasPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseMove);
            this.canevasPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 635);
            this.Controls.Add(this.canevasPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractals";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itérationsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button goMandelbrotButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button goJuliaButton;
        private System.Windows.Forms.NumericUpDown itérationsUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown zoomUpDown;
        private System.Windows.Forms.ComboBox paletteComboBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel canevasPanel;
    }
}

