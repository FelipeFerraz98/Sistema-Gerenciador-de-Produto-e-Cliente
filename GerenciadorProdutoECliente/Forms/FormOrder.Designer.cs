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
            this.txtOrderIdSearch = new System.Windows.Forms.TextBox();
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(26, 81);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(103, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente (CPF/CNPJ):";
            this.lblClient.Click += new System.EventHandler(this.lblClient_Click);
            // 
            // txtClientIdentifier
            // 
            this.txtClientIdentifier.Location = new System.Drawing.Point(136, 81);
            this.txtClientIdentifier.Name = "txtClientIdentifier";
            this.txtClientIdentifier.Size = new System.Drawing.Size(193, 20);
            this.txtClientIdentifier.TabIndex = 1;
            this.txtClientIdentifier.TextChanged += new System.EventHandler(this.txtClientIdentifier_TextChanged);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(371, 112);
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
            this.lstOrderItems.Location = new System.Drawing.Point(29, 272);
            this.lstOrderItems.Name = "lstOrderItems";
            this.lstOrderItems.Size = new System.Drawing.Size(390, 95);
            this.lstOrderItems.TabIndex = 3;
            this.lstOrderItems.SelectedIndexChanged += new System.EventHandler(this.lstOrderItems_SelectedIndexChanged);
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(26, 116);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(55, 13);
            this.lblClientName.TabIndex = 4;
            this.lblClientName.Text = "Pedido de";
            this.lblClientName.Click += new System.EventHandler(this.lblClientName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome ou ID do Produto para busca:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(211, 155);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(143, 20);
            this.txtProductSearch.TabIndex = 6;
            this.txtProductSearch.TextChanged += new System.EventHandler(this.txtProductSearch_TextChanged);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(371, 152);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(102, 23);
            this.btnSearchProduct.TabIndex = 7;
            this.btnSearchProduct.Text = "Buscar Produto";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Location = new System.Drawing.Point(371, 76);
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
            this.label2.Location = new System.Drawing.Point(26, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Deseja criar o pedido deste cliente?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(26, 193);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(90, 13);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Nome do Produto";
            this.lblProduct.Click += new System.EventHandler(this.lblProduct_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id do Produto";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Valor unitário do produto";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Quantidade";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(302, 206);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 14;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // lblProductTotalPrice
            // 
            this.lblProductTotalPrice.AutoSize = true;
            this.lblProductTotalPrice.Location = new System.Drawing.Point(26, 225);
            this.lblProductTotalPrice.Name = "lblProductTotalPrice";
            this.lblProductTotalPrice.Size = new System.Drawing.Size(126, 13);
            this.lblProductTotalPrice.TabIndex = 15;
            this.lblProductTotalPrice.Text = "Valor total deste Produto:";
            this.lblProductTotalPrice.Click += new System.EventHandler(this.lblProductTotalPrice_Click);
            // 
            // btnAddProductToOrder
            // 
            this.btnAddProductToOrder.Location = new System.Drawing.Point(29, 242);
            this.btnAddProductToOrder.Name = "btnAddProductToOrder";
            this.btnAddProductToOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddProductToOrder.TabIndex = 16;
            this.btnAddProductToOrder.Text = "Adicionar";
            this.btnAddProductToOrder.UseVisualStyleBackColor = true;
            this.btnAddProductToOrder.Click += new System.EventHandler(this.btnAddProductToOrder_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(425, 272);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "Remover Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(426, 302);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 18;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Novo";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(30, 374);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(85, 13);
            this.label.TabIndex = 20;
            this.label.Text = "Total do Pedido:";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // btnGoToCashier
            // 
            this.btnGoToCashier.Location = new System.Drawing.Point(238, 390);
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
            this.lblTotalAmount.Location = new System.Drawing.Point(121, 374);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(28, 13);
            this.lblTotalAmount.TabIndex = 23;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.Click += new System.EventHandler(this.lblTotalAmount_Click);
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(104, 178);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(0, 13);
            this.lblProductId.TabIndex = 24;
            this.lblProductId.Click += new System.EventHandler(this.lblProductId_Click);
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(154, 209);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(28, 13);
            this.lblProductPrice.TabIndex = 25;
            this.lblProductPrice.Text = "0.00";
            this.lblProductPrice.Click += new System.EventHandler(this.lblProductPrice_Click);
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(293, 374);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(13, 13);
            this.lblOrderId.TabIndex = 26;
            this.lblOrderId.Text = "0";
            this.lblOrderId.Click += new System.EventHandler(this.lblOrderId_Click);
            // 
            // txtOrderIdSearch
            // 
            this.txtOrderIdSearch.Location = new System.Drawing.Point(492, 78);
            this.txtOrderIdSearch.Name = "txtOrderIdSearch";
            this.txtOrderIdSearch.Size = new System.Drawing.Size(131, 20);
            this.txtOrderIdSearch.TabIndex = 27;
            this.txtOrderIdSearch.TextChanged += new System.EventHandler(this.txtOrderIdSearch_TextChanged);
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Location = new System.Drawing.Point(649, 78);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(102, 23);
            this.btnSearchOrder.TabIndex = 28;
            this.btnSearchOrder.Text = "Buscar Pedido";
            this.btnSearchOrder.UseVisualStyleBackColor = true;
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Insira o ID do Pedido";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(136, 390);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(96, 23);
            this.btnUpdateOrder.TabIndex = 30;
            this.btnUpdateOrder.Text = "Atualizar Pedido";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(227, 12);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 35;
            this.btnOrder.Text = "Pedido";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(129, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(75, 23);
            this.btnProduct.TabIndex = 34;
            this.btnProduct.Text = "Produto";
            this.btnProduct.UseVisualStyleBackColor = true;
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(41, 12);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(75, 23);
            this.btnClient.TabIndex = 33;
            this.btnClient.Text = "Cliente";
            this.btnClient.UseVisualStyleBackColor = true;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearchOrder);
            this.Controls.Add(this.txtOrderIdSearch);
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
        private System.Windows.Forms.TextBox txtOrderIdSearch;
        private System.Windows.Forms.Button btnSearchOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnClient;
    }
}