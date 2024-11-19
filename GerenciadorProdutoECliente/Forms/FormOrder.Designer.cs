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
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblProductTotalPrice = new System.Windows.Forms.Label();
            this.btnAddProductToOrder = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnRecalculateTotal = new System.Windows.Forms.Button();
            this.btnGoToCashier = new System.Windows.Forms.Button();
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
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Location = new System.Drawing.Point(371, 54);
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Size = new System.Drawing.Size(102, 23);
            this.btnSearchClient.TabIndex = 8;
            this.btnSearchClient.Text = "Buscar Cliente";
            this.btnSearchClient.UseVisualStyleBackColor = true;
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
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(27, 156);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(71, 13);
            this.lblProductId.TabIndex = 11;
            this.lblProductId.Text = "Id do Produto";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Location = new System.Drawing.Point(26, 187);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(122, 13);
            this.lblProductPrice.TabIndex = 12;
            this.lblProductPrice.Text = "Valor unitário do produto";
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
            // 
            // lblProductTotalPrice
            // 
            this.lblProductTotalPrice.AutoSize = true;
            this.lblProductTotalPrice.Location = new System.Drawing.Point(26, 200);
            this.lblProductTotalPrice.Name = "lblProductTotalPrice";
            this.lblProductTotalPrice.Size = new System.Drawing.Size(126, 13);
            this.lblProductTotalPrice.TabIndex = 15;
            this.lblProductTotalPrice.Text = "Valor total deste Produto:";
            // 
            // btnAddProductToOrder
            // 
            this.btnAddProductToOrder.Location = new System.Drawing.Point(29, 216);
            this.btnAddProductToOrder.Name = "btnAddProductToOrder";
            this.btnAddProductToOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddProductToOrder.TabIndex = 16;
            this.btnAddProductToOrder.Text = "Adicionar";
            this.btnAddProductToOrder.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(425, 250);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "Remover Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(426, 280);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(93, 23);
            this.btnEditItem.TabIndex = 18;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(30, 352);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(85, 13);
            this.lblTotalAmount.TabIndex = 20;
            this.lblTotalAmount.Text = "Total do Pedido:";
            // 
            // btnRecalculateTotal
            // 
            this.btnRecalculateTotal.Location = new System.Drawing.Point(29, 368);
            this.btnRecalculateTotal.Name = "btnRecalculateTotal";
            this.btnRecalculateTotal.Size = new System.Drawing.Size(100, 23);
            this.btnRecalculateTotal.TabIndex = 21;
            this.btnRecalculateTotal.Text = "Recalcular Total";
            this.btnRecalculateTotal.UseVisualStyleBackColor = true;
            // 
            // btnGoToCashier
            // 
            this.btnGoToCashier.Location = new System.Drawing.Point(241, 368);
            this.btnGoToCashier.Name = "btnGoToCashier";
            this.btnGoToCashier.Size = new System.Drawing.Size(99, 23);
            this.btnGoToCashier.TabIndex = 22;
            this.btnGoToCashier.Text = "Ir para Caixa";
            this.btnGoToCashier.UseVisualStyleBackColor = true;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoToCashier);
            this.Controls.Add(this.btnRecalculateTotal);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddProductToOrder);
            this.Controls.Add(this.lblProductTotalPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblProductId);
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
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblProductTotalPrice;
        private System.Windows.Forms.Button btnAddProductToOrder;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnRecalculateTotal;
        private System.Windows.Forms.Button btnGoToCashier;
    }
}