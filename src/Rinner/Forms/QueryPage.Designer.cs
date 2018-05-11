namespace Rinner.Forms
{
    partial class QueryPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dvKeys = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(3, 11);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(29, 12);
            this.lblKey.TabIndex = 0;
            this.lblKey.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(38, 8);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(478, 21);
            this.txtKey.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(522, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(5, 35);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dvKeys);
            this.splitContainer.Size = new System.Drawing.Size(592, 359);
            this.splitContainer.SplitterDistance = 161;
            this.splitContainer.TabIndex = 4;
            // 
            // dvKeys
            // 
            this.dvKeys.AllowUserToAddRows = false;
            this.dvKeys.AllowUserToDeleteRows = false;
            this.dvKeys.AllowUserToResizeRows = false;
            this.dvKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmTTL,
            this.clmType,
            this.clmPos});
            this.dvKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvKeys.Location = new System.Drawing.Point(0, 0);
            this.dvKeys.Name = "dvKeys";
            this.dvKeys.ReadOnly = true;
            this.dvKeys.RowHeadersVisible = false;
            this.dvKeys.RowTemplate.Height = 23;
            this.dvKeys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvKeys.Size = new System.Drawing.Size(592, 161);
            this.dvKeys.TabIndex = 0;
            // 
            // clmName
            // 
            this.clmName.FillWeight = 60F;
            this.clmName.HeaderText = "键";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.Width = 200;
            // 
            // clmTTL
            // 
            this.clmTTL.FillWeight = 10F;
            this.clmTTL.HeaderText = "存活时间";
            this.clmTTL.Name = "clmTTL";
            this.clmTTL.ReadOnly = true;
            this.clmTTL.Width = 80;
            // 
            // clmType
            // 
            this.clmType.FillWeight = 10F;
            this.clmType.HeaderText = "类型";
            this.clmType.Name = "clmType";
            this.clmType.ReadOnly = true;
            // 
            // clmPos
            // 
            this.clmPos.FillWeight = 20F;
            this.clmPos.HeaderText = "数据位置";
            this.clmPos.Name = "clmPos";
            this.clmPos.ReadOnly = true;
            this.clmPos.Width = 200;
            // 
            // QueryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Name = "QueryPage";
            this.Size = new System.Drawing.Size(600, 400);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvKeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dvKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPos;
    }
}
