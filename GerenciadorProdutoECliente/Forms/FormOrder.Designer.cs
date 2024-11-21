using MaterialSkin.Controls;
using System.Windows.Forms;

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
            this.lblClient = new MaterialSkin.Controls.MaterialLabel();
            this.txtClientIdentifier = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnNewOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lstOrderItems = new System.Windows.Forms.ListBox();
            this.lblClientName = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtProductSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSearchProduct = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSearchClient = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblProduct = new MaterialSkin.Controls.MaterialLabel();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.label6 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQuantity = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblProductTotalPrice = new MaterialSkin.Controls.MaterialLabel();
            this.btnAddProductToOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnRemoveItem = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnEditItem = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label = new MaterialSkin.Controls.MaterialLabel();
            this.btnGoToCashier = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblTotalAmount = new MaterialSkin.Controls.MaterialLabel();
            this.lblProductId = new MaterialSkin.Controls.MaterialLabel();
            this.lblProductPrice = new MaterialSkin.Controls.MaterialLabel();
            this.txtOrderIdSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSearchOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label4 = new MaterialSkin.Controls.MaterialLabel();
            this.btnUpdateOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnProduct = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnClient = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Depth = 0;
            this.lblClient.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClient.Location = new System.Drawing.Point(26, 81);
            this.lblClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(145, 19);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente (CPF/CNPJ):";
            // 
            // txtClientIdentifier
            // 
            this.txtClientIdentifier.Depth = 0;
            this.txtClientIdentifier.Hint = "";
            this.txtClientIdentifier.Location = new System.Drawing.Point(177, 81);
            this.txtClientIdentifier.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtClientIdentifier.Name = "txtClientIdentifier";
            this.txtClientIdentifier.PasswordChar = '\0';
            this.txtClientIdentifier.SelectedText = "";
            this.txtClientIdentifier.SelectionLength = 0;
            this.txtClientIdentifier.SelectionStart = 0;
            this.txtClientIdentifier.Size = new System.Drawing.Size(213, 23);
            this.txtClientIdentifier.TabIndex = 1;
            this.txtClientIdentifier.UseSystemPasswordChar = false;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Depth = 0;
            this.btnNewOrder.Location = new System.Drawing.Point(396, 110);
            this.btnNewOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Primary = true;
            this.btnNewOrder.Size = new System.Drawing.Size(162, 23);
            this.btnNewOrder.TabIndex = 2;
            this.btnNewOrder.Text = "Criar Pedido";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // lstOrderItems
            // 
            this.lstOrderItems.FormattingEnabled = true;
            this.lstOrderItems.Location = new System.Drawing.Point(29, 282);
            this.lstOrderItems.Name = "lstOrderItems";
            this.lstOrderItems.Size = new System.Drawing.Size(390, 95);
            this.lstOrderItems.TabIndex = 3;
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Depth = 0;
            this.lblClientName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblClientName.Location = new System.Drawing.Point(27, 106);
            this.lblClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(75, 19);
            this.lblClientName.TabIndex = 4;
            this.lblClientName.Text = "Pedido de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(26, 155);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome ou ID do Produto para busca:";
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Depth = 0;
            this.txtProductSearch.Hint = "";
            this.txtProductSearch.Location = new System.Drawing.Point(26, 173);
            this.txtProductSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.PasswordChar = '\0';
            this.txtProductSearch.SelectedText = "";
            this.txtProductSearch.SelectionLength = 0;
            this.txtProductSearch.SelectionStart = 0;
            this.txtProductSearch.Size = new System.Drawing.Size(248, 23);
            this.txtProductSearch.TabIndex = 6;
            this.txtProductSearch.UseSystemPasswordChar = false;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Depth = 0;
            this.btnSearchProduct.Location = new System.Drawing.Point(280, 173);
            this.btnSearchProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Primary = true;
            this.btnSearchProduct.Size = new System.Drawing.Size(162, 23);
            this.btnSearchProduct.TabIndex = 7;
            this.btnSearchProduct.Text = "Buscar Produto";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnSearchClient
            // 
            this.btnSearchClient.Depth = 0;
            this.btnSearchClient.Location = new System.Drawing.Point(396, 81);
            this.btnSearchClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearchClient.Name = "btnSearchClient";
            this.btnSearchClient.Primary = true;
            this.btnSearchClient.Size = new System.Drawing.Size(162, 23);
            this.btnSearchClient.TabIndex = 8;
            this.btnSearchClient.Text = "Buscar Cliente";
            this.btnSearchClient.UseVisualStyleBackColor = true;
            this.btnSearchClient.Click += new System.EventHandler(this.btnSearchClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(26, 130);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Deseja criar o pedido deste cliente?";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Depth = 0;
            this.lblProduct.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProduct.Location = new System.Drawing.Point(30, 234);
            this.lblProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(128, 19);
            this.lblProduct.TabIndex = 10;
            this.lblProduct.Text = "Nome do Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(30, 210);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Id do Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Font = new System.Drawing.Font("Roboto", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(214, 242);
            this.label6.MouseState = MaterialSkin.MouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Valor unitário do produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(448, 155);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Quantidade";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Depth = 0;
            this.txtQuantity.Hint = "";
            this.txtQuantity.Location = new System.Drawing.Point(449, 174);
            this.txtQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.SelectionLength = 0;
            this.txtQuantity.SelectionStart = 0;
            this.txtQuantity.Size = new System.Drawing.Size(100, 23);
            this.txtQuantity.TabIndex = 14;
            this.txtQuantity.UseSystemPasswordChar = false;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // lblProductTotalPrice
            // 
            this.lblProductTotalPrice.AutoSize = true;
            this.lblProductTotalPrice.Depth = 0;
            this.lblProductTotalPrice.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblProductTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProductTotalPrice.Location = new System.Drawing.Point(213, 260);
            this.lblProductTotalPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProductTotalPrice.Name = "lblProductTotalPrice";
            this.lblProductTotalPrice.Size = new System.Drawing.Size(182, 19);
            this.lblProductTotalPrice.TabIndex = 15;
            this.lblProductTotalPrice.Text = "Valor total deste Produto:";
            // 
            // btnAddProductToOrder
            // 
            this.btnAddProductToOrder.Depth = 0;
            this.btnAddProductToOrder.Location = new System.Drawing.Point(28, 256);
            this.btnAddProductToOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddProductToOrder.Name = "btnAddProductToOrder";
            this.btnAddProductToOrder.Primary = true;
            this.btnAddProductToOrder.Size = new System.Drawing.Size(162, 23);
            this.btnAddProductToOrder.TabIndex = 16;
            this.btnAddProductToOrder.Text = "Adicionar";
            this.btnAddProductToOrder.UseVisualStyleBackColor = true;
            this.btnAddProductToOrder.Click += new System.EventHandler(this.btnAddProductToOrder_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Depth = 0;
            this.btnRemoveItem.Location = new System.Drawing.Point(425, 281);
            this.btnRemoveItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Primary = true;
            this.btnRemoveItem.Size = new System.Drawing.Size(163, 23);
            this.btnRemoveItem.TabIndex = 17;
            this.btnRemoveItem.Text = "Remover Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Depth = 0;
            this.btnEditItem.Location = new System.Drawing.Point(426, 311);
            this.btnEditItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Primary = true;
            this.btnEditItem.Size = new System.Drawing.Size(162, 23);
            this.btnEditItem.TabIndex = 18;
            this.btnEditItem.Text = "Editar Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(29, 405);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(161, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Novo";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Depth = 0;
            this.label.Font = new System.Drawing.Font("Roboto", 11F);
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label.Location = new System.Drawing.Point(30, 383);
            this.label.MouseState = MaterialSkin.MouseState.HOVER;
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(119, 19);
            this.label.TabIndex = 20;
            this.label.Text = "Total do Pedido:";
            // 
            // btnGoToCashier
            // 
            this.btnGoToCashier.Depth = 0;
            this.btnGoToCashier.Location = new System.Drawing.Point(363, 405);
            this.btnGoToCashier.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGoToCashier.Name = "btnGoToCashier";
            this.btnGoToCashier.Primary = true;
            this.btnGoToCashier.Size = new System.Drawing.Size(163, 23);
            this.btnGoToCashier.TabIndex = 22;
            this.btnGoToCashier.Text = "Ir para Caixa";
            this.btnGoToCashier.UseVisualStyleBackColor = true;
            this.btnGoToCashier.Click += new System.EventHandler(this.btnGoToCashier_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Depth = 0;
            this.lblTotalAmount.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(144, 383);
            this.lblTotalAmount.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(57, 19);
            this.lblTotalAmount.TabIndex = 23;
            this.lblTotalAmount.Text = "R$ 0,00";
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Depth = 0;
            this.lblProductId.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblProductId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProductId.Location = new System.Drawing.Point(129, 210);
            this.lblProductId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(17, 19);
            this.lblProductId.TabIndex = 24;
            this.lblProductId.Text = "0";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Depth = 0;
            this.lblProductPrice.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblProductPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProductPrice.Location = new System.Drawing.Point(390, 242);
            this.lblProductPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(57, 19);
            this.lblProductPrice.TabIndex = 25;
            this.lblProductPrice.Text = "R$ 0,00";
            // 
            // txtOrderIdSearch
            // 
            this.txtOrderIdSearch.Depth = 0;
            this.txtOrderIdSearch.Hint = "";
            this.txtOrderIdSearch.Location = new System.Drawing.Point(596, 91);
            this.txtOrderIdSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOrderIdSearch.Name = "txtOrderIdSearch";
            this.txtOrderIdSearch.PasswordChar = '\0';
            this.txtOrderIdSearch.SelectedText = "";
            this.txtOrderIdSearch.SelectionLength = 0;
            this.txtOrderIdSearch.SelectionStart = 0;
            this.txtOrderIdSearch.Size = new System.Drawing.Size(148, 23);
            this.txtOrderIdSearch.TabIndex = 27;
            this.txtOrderIdSearch.UseSystemPasswordChar = false;
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.Depth = 0;
            this.btnSearchOrder.Location = new System.Drawing.Point(589, 120);
            this.btnSearchOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Primary = true;
            this.btnSearchOrder.Size = new System.Drawing.Size(162, 23);
            this.btnSearchOrder.TabIndex = 28;
            this.btnSearchOrder.Text = "Buscar Pedido";
            this.btnSearchOrder.UseVisualStyleBackColor = true;
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Roboto", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(596, 72);
            this.label4.MouseState = MaterialSkin.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Insira o ID do Pedido";
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Depth = 0;
            this.btnUpdateOrder.Location = new System.Drawing.Point(196, 405);
            this.btnUpdateOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Primary = true;
            this.btnUpdateOrder.Size = new System.Drawing.Size(161, 23);
            this.btnUpdateOrder.TabIndex = 30;
            this.btnUpdateOrder.Text = "Atualizar Pedido";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Depth = 0;
            this.btnOrder.Location = new System.Drawing.Point(196, 32);
            this.btnOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Primary = true;
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 35;
            this.btnOrder.Text = "Pedido";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Depth = 0;
            this.btnProduct.Location = new System.Drawing.Point(115, 32);
            this.btnProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Primary = true;
            this.btnProduct.Size = new System.Drawing.Size(75, 23);
            this.btnProduct.TabIndex = 34;
            this.btnProduct.Text = "Produto";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnClient
            // 
            this.btnClient.Depth = 0;
            this.btnClient.Location = new System.Drawing.Point(34, 32);
            this.btnClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClient.Name = "btnClient";
            this.btnClient.Primary = true;
            this.btnClient.Size = new System.Drawing.Size(75, 23);
            this.btnClient.TabIndex = 33;
            this.btnClient.Text = "Cliente";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
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

        private MaterialSkin.Controls.MaterialLabel lblClient;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtClientIdentifier;
        private MaterialSkin.Controls.MaterialRaisedButton btnNewOrder;
        private System.Windows.Forms.ListBox lstOrderItems;
        private MaterialSkin.Controls.MaterialLabel lblClientName;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtProductSearch;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearchProduct;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearchClient;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel lblProduct;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialLabel label6;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtQuantity;
        private MaterialSkin.Controls.MaterialLabel lblProductTotalPrice;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddProductToOrder;
        private MaterialSkin.Controls.MaterialRaisedButton btnRemoveItem;
        private MaterialSkin.Controls.MaterialRaisedButton btnEditItem;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialLabel label;
        private MaterialSkin.Controls.MaterialRaisedButton btnGoToCashier;
        private MaterialSkin.Controls.MaterialLabel lblTotalAmount;
        private MaterialSkin.Controls.MaterialLabel lblProductId;
        private MaterialSkin.Controls.MaterialLabel lblProductPrice;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOrderIdSearch;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearchOrder;
        private MaterialSkin.Controls.MaterialLabel label4;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdateOrder;
        private MaterialSkin.Controls.MaterialRaisedButton btnOrder;
        private MaterialSkin.Controls.MaterialRaisedButton btnProduct;
        private MaterialSkin.Controls.MaterialRaisedButton btnClient;

    }
}