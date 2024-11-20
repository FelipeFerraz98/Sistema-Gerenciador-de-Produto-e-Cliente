namespace GerenciadorProdutoECliente.Forms
{
    partial class FormOrder
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
            this.lblClient = new System.Windows.Forms.Label();
            this.txtClientIdentifier = new System.Windows.Forms.TextBox();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.lstOrderItems = new System.Windows.Forms.ListBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.btnSearchClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblProductTotalPrice = new System.Windows.Forms.Label();
            this.btnAddProductToOrder = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.btnGoToCashier = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(26, 59);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(103, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente (CPF/CNPJ):";
            // 
            // txtClientIdentifier
            // 
            this.txtClientIdentifier.Location = new System.Drawing.Point(136, 59);
            this.txtClientIdentifier.Name = "txtClientIdentifier";
            this.txtClientIdentifier.Size = new System.Drawing.Size(193, 20);
            this.txtClientIdentifier.TabIndex = 1;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(371, 90);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(102, 23);
            this.btnNewOrder.TabIndex = 2;
            this.btnNewOrder.Text = "Criar Pedido";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // lstOrderItems
            // 
            this.lstOrderItems.FormattingEnabled = true;
            this.lstOrderItems.Location = new System.Drawing.Point(29, 250);
            this.lstOrderItems.Name = "lstOrderItems";
            this.lstOrderItems.Size = new System.Drawing.Size(390, 95);
            this.lstOrderItems.TabIndex = 3;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(26, 94);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(55, 13);
            this.lblClientName.TabIndex = 4;
            this.lblClientName.Text = "Pedido de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome ou ID do Produto para busca:";
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(211, 133);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(143, 20);
            this.txtProductSearch.TabIndex = 6;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(371, 130);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(102, 23);
            this.btnSearchProduct.TabIndex = 7;
            this.btnSearchProduct.Text = "Buscar Produto";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Location = new System.Drawing.Point(371, 54);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(102, 23);
            this.btnSearchClient.TabIndex = 8;
            this.btnSearchClient.Text = "Buscar Cliente";
            this.btnSearchClient.UseVisualStyleBackColor = true;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Deseja criar o pedido deste cliente?";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(26, 171);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(90, 13);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Nome do Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id do Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Valor unitário do produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Quantidade";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(302, 184);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 14;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // lblProductTotalPrice
            // 
            this.lblProductTotalPrice.AutoSize = true;
            this.lblProductTotalPrice.Location = new System.Drawing.Point(26, 203);
            this.lblProductTotalPrice.Name = "lblProductTotalPrice";
            this.lblProductTotalPrice.Size = new System.Drawing.Size(126, 13);
            this.lblProductTotalPrice.TabIndex = 15;
            this.lblProductTotalPrice.Text = "Valor total deste Produto:";
            // 
            // btnAddProductToOrder
            // 
            this.btnAddProductToOrder.Location = new System.Drawing.Point(29, 220);
            this.btnAddProductToOrder.Name = "btnAddProductToOrder";
            this.btnAddProductToOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddProductToOrder.TabIndex = 16;
            this.btnAddProductToOrder.Text = "Adicionar";
            this.btnAddProductToOrder.UseVisualStyleBackColor = true;
            this.btnAddProductToOrder.Click += new System.EventHandler(this.btnAddProductToOrder_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(425, 250);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "Remover Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(426, 280);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 18;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(30, 352);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(85, 13);
            this.label.TabIndex = 20;
            this.label.Text = "Total do Pedido:";
            // 
            // btnGoToCashier
            // 
            this.btnGoToCashier.Location = new System.Drawing.Point(135, 368);
            this.btnGoToCashier.Name = "btnGoToCashier";
            this.btnGoToCashier.Size = new System.Drawing.Size(99, 23);
            this.btnGoToCashier.TabIndex = 22;
            this.btnGoToCashier.Text = "Ir para Caixa";
            this.btnGoToCashier.UseVisualStyleBackColor = true;
            this.btnGoToCashier.Click += new System.EventHandler(this.btnGoToCashier_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(121, 352);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(28, 13);
            this.lblTotalAmount.TabIndex = 23;
            this.lblTotalAmount.Text = "0.00";
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(104, 156);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(0, 13);
            this.lblProductId.TabIndex = 24;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(154, 187);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(28, 13);
            this.lblProductPrice.TabIndex = 25;
            this.lblProductPrice.Text = "0.00";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(293, 352);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(13, 13);
            this.lblOrderId.TabIndex = 26;
            this.lblOrderId.Text = "0";
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnGoToCashier);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddProductToOrder);
            this.Controls.Add(this.lblProductTotalPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchClient);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.txtProductSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.lstOrderItems);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.txtClientIdentifier);
            this.Controls.Add(this.lblClient);
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtClientIdentifier;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.ListBox lstOrderItems;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblProductTotalPrice;
        private System.Windows.Forms.Button btnAddProductToOrder;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnGoToCashier;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblOrderId;
    }
}