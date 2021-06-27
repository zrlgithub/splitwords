namespace splitwords
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnOK = new System.Windows.Forms.Button();
            this.listWithFreq = new System.Windows.Forms.ListView();
            this.Frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Word = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pSODataSet = new splitwords.PSODataSet();
            this.wordsTableAdapter = new splitwords.PSODataSetTableAdapters.WordsTableAdapter();
            this.wordsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.searchWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSODataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(426, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 49);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // listWithFreq
            // 
            this.listWithFreq.AccessibleName = "search";
            this.listWithFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listWithFreq.BackColor = System.Drawing.SystemColors.Info;
            this.listWithFreq.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Frequency,
            this.Word});
            this.listWithFreq.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.wordsBindingSource, "frequency", true));
            this.listWithFreq.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listWithFreq.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listWithFreq.GridLines = true;
            this.listWithFreq.HideSelection = false;
            this.listWithFreq.Location = new System.Drawing.Point(114, 25);
            this.listWithFreq.Name = "listWithFreq";
            this.listWithFreq.Size = new System.Drawing.Size(254, 393);
            this.listWithFreq.TabIndex = 1;
            this.listWithFreq.UseCompatibleStateImageBehavior = false;
            this.listWithFreq.View = System.Windows.Forms.View.Details;
            this.listWithFreq.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listWithFreq_ColumnClick);
            this.listWithFreq.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Frequency
            // 
            this.Frequency.Text = "Frequency";
            this.Frequency.Width = 99;
            // 
            // Word
            // 
            this.Word.Text = "Word";
            this.Word.Width = 150;
            // 
            // wordsBindingSource
            // 
            this.wordsBindingSource.DataMember = "Words";
            this.wordsBindingSource.DataSource = this.pSODataSet;
            // 
            // pSODataSet
            // 
            this.pSODataSet.DataSetName = "PSODataSet";
            this.pSODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordsTableAdapter
            // 
            this.wordsTableAdapter.ClearBeforeFill = true;
            // 
            // wordsBindingSource1
            // 
            this.wordsBindingSource1.DataMember = "Words";
            this.wordsBindingSource1.DataSource = this.pSODataSet;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(720, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 27);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // searchWord
            // 
            this.searchWord.AccessibleName = "search";
            this.searchWord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchWord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchWord.Location = new System.Drawing.Point(564, 38);
            this.searchWord.Name = "searchWord";
            this.searchWord.Size = new System.Drawing.Size(149, 22);
            this.searchWord.TabIndex = 4;
            this.searchWord.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form2
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchWord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listWithFreq);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSODataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView listWithFreq;
        private System.Windows.Forms.ColumnHeader Frequency;
        private System.Windows.Forms.ColumnHeader Word;
        private PSODataSet pSODataSet;
        private System.Windows.Forms.BindingSource wordsBindingSource;
        private PSODataSetTableAdapters.WordsTableAdapter wordsTableAdapter;
        private System.Windows.Forms.BindingSource wordsBindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchWord;
    }
}