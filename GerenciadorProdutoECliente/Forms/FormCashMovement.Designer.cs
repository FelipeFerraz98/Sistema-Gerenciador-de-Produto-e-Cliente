namespace GerenciadorProdutoECliente.Forms
{
    partial class FormCashMovement
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnFinalizePayment = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDataOrder = new System.Windows.Forms.Label();
            this.lstOrderItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido ID:";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(96, 36);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(13, 13);
            this.lblOrderId.TabIndex = 1;
            this.lblOrderId.Text = "0";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Location = new System.Drawing.Point(112, 61);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(13, 13);
            this.lblAmountDue.TabIndex = 2;
            this.lblAmountDue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor a Pagar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor Pago:";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(103, 93);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(139, 20);
            this.txtPaid.TabIndex = 5;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forma de Pagamento";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(405, 96);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbPaymentMethod.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Troco: ";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Location = new System.Drawing.Point(83, 138);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(37, 13);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "$ 0.00";
            // 
            // btnFinalizePayment
            // 
            this.btnFinalizePayment.Location = new System.Drawing.Point(35, 294);
            this.btnFinalizePayment.Name = "btnFinalizePayment";
            this.btnFinalizePayment.Size = new System.Drawing.Size(139, 23);
            this.btnFinalizePayment.TabIndex = 10;
            this.btnFinalizePayment.Text = "Finalizar Pagamento";
            this.btnFinalizePayment.UseVisualStyleBackColor = true;
            this.btnFinalizePayment.Click += new System.EventHandler(this.btnFinalizePayment_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Data do Pedido:";
            // 
            // lblDataOrder
            // 
            this.lblDataOrder.AutoSize = true;
            this.lblDataOrder.Location = new System.Drawing.Point(340, 36);
            this.lblDataOrder.Name = "lblDataOrder";
            this.lblDataOrder.Size = new System.Drawing.Size(13, 13);
            this.lblDataOrder.TabIndex = 12;
            this.lblDataOrder.Text = "0";
            // 
            // lstOrderItems
            // 
            this.lstOrderItems.FormattingEnabled = true;
            this.lstOrderItems.Location = new System.Drawing.Point(35, 174);
            this.lstOrderItems.Name = "lstOrderItems";
            this.lstOrderItems.Size = new System.Drawing.Size(550, 108);
            this.lstOrderItems.TabIndex = 13;
            // 
            // FormCashMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstOrderItems);
            this.Controls.Add(this.lblDataOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFinalizePayment);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAmountDue);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.label1);
            this.Name = "FormCashMovement";
            this.Text = "FormCashMovement";
            this.Load += new System.EventHandler(this.FormCashMovement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnFinalizePayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDataOrder;
        private System.Windows.Forms.ListBox lstOrderItems;
    }
}