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
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblOrderId = new MaterialSkin.Controls.MaterialLabel();
            this.lblAmountDue = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPaid = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.lblChange = new MaterialSkin.Controls.MaterialLabel();
            this.btnFinalizePayment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label6 = new MaterialSkin.Controls.MaterialLabel();
            this.lblDataOrder = new MaterialSkin.Controls.MaterialLabel();
            this.lstOrderItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(32, 72);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido ID:";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Depth = 0;
            this.lblOrderId.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblOrderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOrderId.Location = new System.Drawing.Point(105, 72);
            this.lblOrderId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(17, 19);
            this.lblOrderId.TabIndex = 1;
            this.lblOrderId.Text = "0";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Depth = 0;
            this.lblAmountDue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAmountDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAmountDue.Location = new System.Drawing.Point(112, 97);
            this.lblAmountDue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(17, 19);
            this.lblAmountDue.TabIndex = 2;
            this.lblAmountDue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor a Pagar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(35, 132);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor Pago:";
            // 
            // txtPaid
            // 
            this.txtPaid.Depth = 0;
            this.txtPaid.Hint = "";
            this.txtPaid.Location = new System.Drawing.Point(35, 151);
            this.txtPaid.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.PasswordChar = '\0';
            this.txtPaid.SelectedText = "";
            this.txtPaid.SelectionLength = 0;
            this.txtPaid.SelectionStart = 0;
            this.txtPaid.Size = new System.Drawing.Size(139, 23);
            this.txtPaid.TabIndex = 5;
            this.txtPaid.UseSystemPasswordChar = false;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(249, 134);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Forma de Pagamento";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(407, 134);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbPaymentMethod.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(35, 180);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Troco: ";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Depth = 0;
            this.lblChange.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChange.Location = new System.Drawing.Point(83, 180);
            this.lblChange.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(57, 19);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "R$ 0,00";
            // 
            // btnFinalizePayment
            // 
            this.btnFinalizePayment.Depth = 0;
            this.btnFinalizePayment.Location = new System.Drawing.Point(35, 330);
            this.btnFinalizePayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFinalizePayment.Name = "btnFinalizePayment";
            this.btnFinalizePayment.Primary = true;
            this.btnFinalizePayment.Size = new System.Drawing.Size(195, 23);
            this.btnFinalizePayment.TabIndex = 10;
            this.btnFinalizePayment.Text = "Finalizar Pagamento";
            this.btnFinalizePayment.UseVisualStyleBackColor = true;
            this.btnFinalizePayment.Click += new System.EventHandler(this.btnFinalizePayment_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Font = new System.Drawing.Font("Roboto", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(249, 72);
            this.label6.MouseState = MaterialSkin.MouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Data do Pedido:";
            // 
            // lblDataOrder
            // 
            this.lblDataOrder.AutoSize = true;
            this.lblDataOrder.Depth = 0;
            this.lblDataOrder.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDataOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDataOrder.Location = new System.Drawing.Point(362, 72);
            this.lblDataOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDataOrder.Name = "lblDataOrder";
            this.lblDataOrder.Size = new System.Drawing.Size(17, 19);
            this.lblDataOrder.TabIndex = 12;
            this.lblDataOrder.Text = "0";
            // 
            // lstOrderItems
            // 
            this.lstOrderItems.FormattingEnabled = true;
            this.lstOrderItems.Location = new System.Drawing.Point(35, 210);
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

        // Definindo os controles MaterialSkin
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel lblOrderId;
        private MaterialSkin.Controls.MaterialLabel lblAmountDue;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPaid;
        private MaterialSkin.Controls.MaterialLabel label4;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialLabel lblChange;
        private MaterialSkin.Controls.MaterialRaisedButton btnFinalizePayment;
        private MaterialSkin.Controls.MaterialLabel label6;
        private MaterialSkin.Controls.MaterialLabel lblDataOrder;
        private System.Windows.Forms.ListBox lstOrderItems;


    }
}