using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ListenerWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvTopics = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvSubscribe = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvListener = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mQTTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTopicListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListenerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoginUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMQTTStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnUnsubsribe = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvTopics);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(10, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Topics";
            // 
            // lvTopics
            // 
            this.lvTopics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTopics.FullRowSelect = true;
            this.lvTopics.Location = new System.Drawing.Point(3, 78);
            this.lvTopics.Name = "lvTopics";
            this.lvTopics.Size = new System.Drawing.Size(251, 306);
            this.lvTopics.TabIndex = 0;
            this.lvTopics.UseCompatibleStateImageBehavior = false;
            this.lvTopics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lref";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Topic Name";
            this.columnHeader2.Width = 146;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvSubscribe);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(270, 34);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subscribe";
            // 
            // lvSubscribe
            // 
            this.lvSubscribe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSubscribe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubscribe.FullRowSelect = true;
            this.lvSubscribe.Location = new System.Drawing.Point(3, 16);
            this.lvSubscribe.MultiSelect = false;
            this.lvSubscribe.Name = "lvSubscribe";
            this.lvSubscribe.Size = new System.Drawing.Size(696, 81);
            this.lvSubscribe.TabIndex = 1;
            this.lvSubscribe.UseCompatibleStateImageBehavior = false;
            this.lvSubscribe.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Lref";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Subscribe Name";
            this.columnHeader4.Width = 167;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Subscribe Date/ Time";
            this.columnHeader5.Width = 129;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvListener);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(270, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 265);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listener";
            // 
            // lvListener
            // 
            this.lvListener.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvListener.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvListener.Location = new System.Drawing.Point(3, 16);
            this.lvListener.MultiSelect = false;
            this.lvListener.Name = "lvListener";
            this.lvListener.Size = new System.Drawing.Size(696, 246);
            this.lvListener.TabIndex = 1;
            this.lvListener.UseCompatibleStateImageBehavior = false;
            this.lvListener.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Topic";
            this.columnHeader7.Width = 77;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Client ID";
            this.columnHeader8.Width = 130;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "QoS";
            this.columnHeader9.Width = 41;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Retain";
            this.columnHeader10.Width = 43;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Message";
            this.columnHeader11.Width = 323;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mQTTToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mQTTToolStripMenuItem
            // 
            this.mQTTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.mQTTToolStripMenuItem.Name = "mQTTToolStripMenuItem";
            this.mQTTToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mQTTToolStripMenuItem.Text = "MQTT";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshTopicListToolStripMenuItem,
            this.clearListenerListToolStripMenuItem});
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.quitToolStripMenuItem.Text = "Topics";
            // 
            // refreshTopicListToolStripMenuItem
            // 
            this.refreshTopicListToolStripMenuItem.Name = "refreshTopicListToolStripMenuItem";
            this.refreshTopicListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.refreshTopicListToolStripMenuItem.Text = "Refresh Topic";
            this.refreshTopicListToolStripMenuItem.Click += new System.EventHandler(this.refreshTopicListToolStripMenuItem_Click);
            // 
            // clearListenerListToolStripMenuItem
            // 
            this.clearListenerListToolStripMenuItem.Name = "clearListenerListToolStripMenuItem";
            this.clearListenerListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearListenerListToolStripMenuItem.Text = "Clear Listener";
            this.clearListenerListToolStripMenuItem.Click += new System.EventHandler(this.clearListenerListToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblLoginUser,
            this.toolStripStatusLabel2,
            this.lblMQTTStatus});
            this.statusStrip1.Location = new System.Drawing.Point(270, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(702, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Login User: ";
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(12, 17);
            this.lblLoginUser.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel2.Text = " - MQTT Status:";
            // 
            // lblMQTTStatus
            // 
            this.lblMQTTStatus.Name = "lblMQTTStatus";
            this.lblMQTTStatus.Size = new System.Drawing.Size(12, 17);
            this.lblMQTTStatus.Text = "-";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 23);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.Location = new System.Drawing.Point(128, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(116, 23);
            this.btnDisconnect.TabIndex = 10;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(267, 34);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 387);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(270, 134);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(702, 3);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscribe.Location = new System.Drawing.Point(3, 32);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(119, 23);
            this.btnSubscribe.TabIndex = 13;
            this.btnSubscribe.Text = "Subsribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnUnsubsribe
            // 
            this.btnUnsubsribe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnsubsribe.Location = new System.Drawing.Point(128, 32);
            this.btnUnsubsribe.Name = "btnUnsubsribe";
            this.btnUnsubsribe.Size = new System.Drawing.Size(116, 23);
            this.btnUnsubsribe.TabIndex = 14;
            this.btnUnsubsribe.Text = "Unsubsribe";
            this.btnUnsubsribe.UseVisualStyleBackColor = true;
            this.btnUnsubsribe.Click += new System.EventHandler(this.btnUnsubsribe_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnUnsubsribe);
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Controls.Add(this.btnSubscribe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 62);
            this.panel1.TabIndex = 15;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(982, 431);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Listener";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ListView lvSubscribe;
        private ListView lvListener;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mQTTToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem refreshTopicListToolStripMenuItem;
        private ToolStripMenuItem clearListenerListToolStripMenuItem;
        private ListView lvTopics;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblLoginUser;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblMQTTStatus;
        private Button btnConnect;
        private Button btnDisconnect;
        private Splitter splitter1;
        private Splitter splitter2;
        private Button btnSubscribe;
        private Button btnUnsubsribe;
        private Panel panel1;
    }
}

