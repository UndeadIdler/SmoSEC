using System;
using Smobiler.Core;
namespace SMOSEC.UI.Layout
{
    partial class frmAssTypeChooseLayout : Smobiler.Core.Controls.MobileUserControl
    {
        #region "SmobilerUserControl generated code "

        public frmAssTypeChooseLayout()
            : base()
        {
            //This call is required by the SmobilerUserControl.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
        }

        //SmobilerUserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerUserControl
        //It can be modified using the SmobilerUserControl.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.plButton = new Smobiler.Core.Controls.Panel();
            this.btnCancel = new Smobiler.Core.Controls.Button();
            this.btnSave = new Smobiler.Core.Controls.Button();
            this.label1 = new Smobiler.Core.Controls.Label();
            this.plContent = new Smobiler.Core.Controls.Panel();
            this.treeAssetsType = new Smobiler.Core.Controls.TreeView();
            // 
            // plButton
            // 
            this.plButton.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.btnCancel,
            this.btnSave});
            this.plButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButton.Name = "plButton";
            this.plButton.Size = new System.Drawing.Size(300, 35);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Border = new Smobiler.Core.Controls.Border(0F, 1F, 1F, 0F);
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 35);
            this.btnCancel.Text = "取消";
            this.btnCancel.Press += new System.EventHandler(this.btnCancel_Press);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Border = new Smobiler.Core.Controls.Border(0F, 1F, 0F, 0F);
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnSave.BorderRadius = 0;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(140, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.Text = "确定";
            this.btnSave.Press += new System.EventHandler(this.btnSave_Press);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(164)))), ((int)(((byte)(229)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.Text = "类型选择";
            // 
            // plContent
            // 
            this.plContent.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.treeAssetsType});
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 335);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(300, 305);
            // 
            // treeAssetsType
            // 
            this.treeAssetsType.BackColor = System.Drawing.Color.White;
            this.treeAssetsType.Name = "treeAssetsType";
            this.treeAssetsType.NodeCollapseIcon = "plus-square-o";
            this.treeAssetsType.NodeCollapseIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.NodeExpandIcon = "minus-square-o";
            this.treeAssetsType.NodeExpandIconColor = System.Drawing.Color.DimGray;
            this.treeAssetsType.Size = new System.Drawing.Size(280, 305);
            this.treeAssetsType.NodePress += new Smobiler.Core.Controls.TreeViewNodeClickEventHandler(this.treeAssetsType_NodePress);
            // 
            // frmAssTypeChooseLayout
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.label1,
            this.plButton,
            this.plContent});
            this.Size = new System.Drawing.Size(280, 370);
            this.Load += new System.EventHandler(this.frmAssTypeChooseLayout_Load);
            this.Name = "frmAssTypeChooseLayout";

        }
        #endregion
        private Smobiler.Core.Controls.Panel plButton;
        internal Smobiler.Core.Controls.Button btnCancel;
        internal Smobiler.Core.Controls.Button btnSave;
        private Smobiler.Core.Controls.Label label1;
        private Smobiler.Core.Controls.Panel plContent;
        internal Smobiler.Core.Controls.TreeView treeAssetsType;
    }
}