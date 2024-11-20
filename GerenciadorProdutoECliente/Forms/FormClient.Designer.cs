namespace GerenciadorProdutoECliente.Forms
{
    partial class FormClient
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
        // Definindo os controles com os tipos do MaterialSkin
        private void InitializeComponent()
        {
            this.txtSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCpfCnpj = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPhone = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtZipCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtStreet = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtComplement = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtState = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNeighborhood = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCity = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblState = new MaterialSkin.Controls.MaterialLabel();
            this.lblCity = new MaterialSkin.Controls.MaterialLabel();
            this.lblNeighborhood = new MaterialSkin.Controls.MaterialLabel();
            this.lblComplement = new MaterialSkin.Controls.MaterialLabel();
            this.lblNumber = new MaterialSkin.Controls.MaterialLabel();
            this.lblStreet = new MaterialSkin.Controls.MaterialLabel();
            this.lblZipCode = new MaterialSkin.Controls.MaterialLabel();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.lblCpfCnpj = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.lblPhone = new MaterialSkin.Controls.MaterialLabel();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblSearch = new MaterialSkin.Controls.MaterialLabel();
            this.btnNew = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnUpdate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.rbtnIndividual = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnLegalEntity = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnClient = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnProduct = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOrder = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Depth = 0;
            this.txtSearch.Hint = "";
            this.txtSearch.Location = new System.Drawing.Point(151, 103);
            this.txtSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.Size = new System.Drawing.Size(329, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.UseSystemPasswordChar = false;
            // 
            // txtName
            // 
            this.txtName.Depth = 0;
            this.txtName.Hint = "";
            this.txtName.Location = new System.Drawing.Point(45, 154);
            this.txtName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.Size = new System.Drawing.Size(275, 23);
            this.txtName.TabIndex = 1;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Depth = 0;
            this.txtCpfCnpj.Hint = "";
            this.txtCpfCnpj.Location = new System.Drawing.Point(341, 154);
            this.txtCpfCnpj.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.PasswordChar = '\0';
            this.txtCpfCnpj.SelectedText = "";
            this.txtCpfCnpj.SelectionLength = 0;
            this.txtCpfCnpj.SelectionStart = 0;
            this.txtCpfCnpj.Size = new System.Drawing.Size(135, 23);
            this.txtCpfCnpj.TabIndex = 2;
            this.txtCpfCnpj.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Depth = 0;
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(45, 197);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(275, 23);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Depth = 0;
            this.txtPhone.Hint = "";
            this.txtPhone.Location = new System.Drawing.Point(339, 197);
            this.txtPhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.SelectedText = "";
            this.txtPhone.SelectionLength = 0;
            this.txtPhone.SelectionStart = 0;
            this.txtPhone.Size = new System.Drawing.Size(137, 23);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.UseSystemPasswordChar = false;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Depth = 0;
            this.txtZipCode.Hint = "";
            this.txtZipCode.Location = new System.Drawing.Point(48, 253);
            this.txtZipCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.PasswordChar = '\0';
            this.txtZipCode.SelectedText = "";
            this.txtZipCode.SelectionLength = 0;
            this.txtZipCode.SelectionStart = 0;
            this.txtZipCode.Size = new System.Drawing.Size(100, 23);
            this.txtZipCode.TabIndex = 5;
            this.txtZipCode.UseSystemPasswordChar = false;
            this.txtZipCode.TextChanged += new System.EventHandler(this.txtZipCode_TextChanged);
            // 
            // txtStreet
            // 
            this.txtStreet.Depth = 0;
            this.txtStreet.Hint = "";
            this.txtStreet.Location = new System.Drawing.Point(155, 254);
            this.txtStreet.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.PasswordChar = '\0';
            this.txtStreet.SelectedText = "";
            this.txtStreet.SelectionLength = 0;
            this.txtStreet.SelectionStart = 0;
            this.txtStreet.Size = new System.Drawing.Size(238, 23);
            this.txtStreet.TabIndex = 6;
            this.txtStreet.UseSystemPasswordChar = false;
            // 
            // txtNumber
            // 
            this.txtNumber.Depth = 0;
            this.txtNumber.Hint = "";
            this.txtNumber.Location = new System.Drawing.Point(399, 254);
            this.txtNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.PasswordChar = '\0';
            this.txtNumber.SelectedText = "";
            this.txtNumber.SelectionLength = 0;
            this.txtNumber.SelectionStart = 0;
            this.txtNumber.Size = new System.Drawing.Size(63, 23);
            this.txtNumber.TabIndex = 7;
            this.txtNumber.UseSystemPasswordChar = false;
            // 
            // txtComplement
            // 
            this.txtComplement.Depth = 0;
            this.txtComplement.Hint = "";
            this.txtComplement.Location = new System.Drawing.Point(468, 255);
            this.txtComplement.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtComplement.Name = "txtComplement";
            this.txtComplement.PasswordChar = '\0';
            this.txtComplement.SelectedText = "";
            this.txtComplement.SelectionLength = 0;
            this.txtComplement.SelectionStart = 0;
            this.txtComplement.Size = new System.Drawing.Size(147, 23);
            this.txtComplement.TabIndex = 8;
            this.txtComplement.UseSystemPasswordChar = false;
            // 
            // txtState
            // 
            this.txtState.Depth = 0;
            this.txtState.Hint = "";
            this.txtState.Location = new System.Drawing.Point(468, 303);
            this.txtState.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtState.Name = "txtState";
            this.txtState.PasswordChar = '\0';
            this.txtState.SelectedText = "";
            this.txtState.SelectionLength = 0;
            this.txtState.SelectionStart = 0;
            this.txtState.Size = new System.Drawing.Size(27, 23);
            this.txtState.TabIndex = 9;
            this.txtState.UseSystemPasswordChar = false;
            // 
            // txtNeighborhood
            // 
            this.txtNeighborhood.Depth = 0;
            this.txtNeighborhood.Hint = "";
            this.txtNeighborhood.Location = new System.Drawing.Point(48, 303);
            this.txtNeighborhood.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNeighborhood.Name = "txtNeighborhood";
            this.txtNeighborhood.PasswordChar = '\0';
            this.txtNeighborhood.SelectedText = "";
            this.txtNeighborhood.SelectionLength = 0;
            this.txtNeighborhood.SelectionStart = 0;
            this.txtNeighborhood.Size = new System.Drawing.Size(232, 23);
            this.txtNeighborhood.TabIndex = 9;
            this.txtNeighborhood.UseSystemPasswordChar = false;
            // 
            // txtCity
            // 
            this.txtCity.Depth = 0;
            this.txtCity.Hint = "";
            this.txtCity.Location = new System.Drawing.Point(286, 303);
            this.txtCity.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCity.Name = "txtCity";
            this.txtCity.PasswordChar = '\0';
            this.txtCity.SelectedText = "";
            this.txtCity.SelectionLength = 0;
            this.txtCity.SelectionStart = 0;
            this.txtCity.Size = new System.Drawing.Size(176, 23);
            this.txtCity.TabIndex = 10;
            this.txtCity.UseSystemPasswordChar = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Depth = 0;
            this.lblState.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblState.Location = new System.Drawing.Point(468, 285);
            this.lblState.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(27, 19);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "UF";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Depth = 0;
            this.lblCity.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCity.Location = new System.Drawing.Point(286, 284);
            this.lblCity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(55, 19);
            this.lblCity.TabIndex = 12;
            this.lblCity.Text = "Cidade";
            // 
            // lblNeighborhood
            // 
            this.lblNeighborhood.AutoSize = true;
            this.lblNeighborhood.Depth = 0;
            this.lblNeighborhood.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNeighborhood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNeighborhood.Location = new System.Drawing.Point(48, 286);
            this.lblNeighborhood.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNeighborhood.Name = "lblNeighborhood";
            this.lblNeighborhood.Size = new System.Drawing.Size(49, 19);
            this.lblNeighborhood.TabIndex = 13;
            this.lblNeighborhood.Text = "Bairro";
            // 
            // lblComplement
            // 
            this.lblComplement.AutoSize = true;
            this.lblComplement.Depth = 0;
            this.lblComplement.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblComplement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblComplement.Location = new System.Drawing.Point(468, 236);
            this.lblComplement.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblComplement.Name = "lblComplement";
            this.lblComplement.Size = new System.Drawing.Size(104, 19);
            this.lblComplement.TabIndex = 14;
            this.lblComplement.Text = "Complemento";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Depth = 0;
            this.lblNumber.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumber.Location = new System.Drawing.Point(399, 236);
            this.lblNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(63, 19);
            this.lblNumber.TabIndex = 15;
            this.lblNumber.Text = "Numero";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Depth = 0;
            this.lblStreet.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblStreet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStreet.Location = new System.Drawing.Point(155, 237);
            this.lblStreet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(34, 19);
            this.lblStreet.TabIndex = 16;
            this.lblStreet.Text = "Rua";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Depth = 0;
            this.lblZipCode.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblZipCode.Location = new System.Drawing.Point(48, 235);
            this.lblZipCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(37, 19);
            this.lblZipCode.TabIndex = 17;
            this.lblZipCode.Text = "CEP";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(45, 135);
            this.lblName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 19);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Nome Completo";
            // 
            // lblCpfCnpj
            // 
            this.lblCpfCnpj.AutoSize = true;
            this.lblCpfCnpj.Depth = 0;
            this.lblCpfCnpj.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCpfCnpj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCpfCnpj.Location = new System.Drawing.Point(341, 135);
            this.lblCpfCnpj.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCpfCnpj.Name = "lblCpfCnpj";
            this.lblCpfCnpj.Size = new System.Drawing.Size(80, 19);
            this.lblCpfCnpj.TabIndex = 19;
            this.lblCpfCnpj.Text = "CPF/CNPJ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmail.Location = new System.Drawing.Point(45, 181);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 19);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Depth = 0;
            this.lblPhone.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPhone.Location = new System.Drawing.Point(340, 181);
            this.lblPhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(68, 19);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Telefone";
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(500, 103);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(93, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Busar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Depth = 0;
            this.lblSearch.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSearch.Location = new System.Drawing.Point(151, 87);
            this.lblSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(269, 19);
            this.lblSearch.TabIndex = 23;
            this.lblSearch.Text = "Insira Nome, CPF ou CNPJ para busca:";
            // 
            // btnNew
            // 
            this.btnNew.Depth = 0;
            this.btnNew.Location = new System.Drawing.Point(507, 300);
            this.btnNew.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNew.Name = "btnNew";
            this.btnNew.Primary = true;
            this.btnNew.Size = new System.Drawing.Size(93, 23);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "Novo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Depth = 0;
            this.btnUpdate.Location = new System.Drawing.Point(602, 299);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Primary = true;
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Depth = 0;
            this.btnDelete.Location = new System.Drawing.Point(701, 300);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Primary = true;
            this.btnDelete.Size = new System.Drawing.Size(93, 23);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Location = new System.Drawing.Point(51, 336);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(694, 95);
            this.lstClients.TabIndex = 27;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // rbtnIndividual
            // 
            this.rbtnIndividual.AutoSize = true;
            this.rbtnIndividual.Depth = 0;
            this.rbtnIndividual.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnIndividual.Location = new System.Drawing.Point(497, 147);
            this.rbtnIndividual.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnIndividual.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnIndividual.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnIndividual.Name = "rbtnIndividual";
            this.rbtnIndividual.Ripple = true;
            this.rbtnIndividual.Size = new System.Drawing.Size(114, 30);
            this.rbtnIndividual.TabIndex = 28;
            this.rbtnIndividual.TabStop = true;
            this.rbtnIndividual.Text = "Pessoa Fisica   ";
            this.rbtnIndividual.UseVisualStyleBackColor = true;
            // 
            // rbtnLegalEntity
            // 
            this.rbtnLegalEntity.AutoSize = true;
            this.rbtnLegalEntity.Depth = 0;
            this.rbtnLegalEntity.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnLegalEntity.Location = new System.Drawing.Point(628, 147);
            this.rbtnLegalEntity.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnLegalEntity.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnLegalEntity.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnLegalEntity.Name = "rbtnLegalEntity";
            this.rbtnLegalEntity.Ripple = true;
            this.rbtnLegalEntity.Size = new System.Drawing.Size(127, 30);
            this.rbtnLegalEntity.TabIndex = 29;
            this.rbtnLegalEntity.TabStop = true;
            this.rbtnLegalEntity.Text = "Pessoa Juridica";
            this.rbtnLegalEntity.UseVisualStyleBackColor = true;
            // 
            // btnClient
            // 
            this.btnClient.Depth = 0;
            this.btnClient.Location = new System.Drawing.Point(48, 33);
            this.btnClient.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClient.Name = "btnClient";
            this.btnClient.Primary = true;
            this.btnClient.Size = new System.Drawing.Size(75, 23);
            this.btnClient.TabIndex = 30;
            this.btnClient.Text = "Cliente";
            this.btnClient.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Depth = 0;
            this.btnProduct.Location = new System.Drawing.Point(136, 33);
            this.btnProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Primary = true;
            this.btnProduct.Size = new System.Drawing.Size(75, 23);
            this.btnProduct.TabIndex = 31;
            this.btnProduct.Text = "Produto";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Depth = 0;
            this.btnOrder.Location = new System.Drawing.Point(234, 33);
            this.btnOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Primary = true;
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 32;
            this.btnOrder.Text = "Pedido";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // FormClient
            // 
            this.ClientSize = new System.Drawing.Size(934, 496);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtComplement);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtNeighborhood);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblNeighborhood);
            this.Controls.Add(this.lblComplement);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCpfCnpj);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.rbtnIndividual);
            this.Controls.Add(this.rbtnLegalEntity);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnOrder);
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearch;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCpfCnpj;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPhone;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtZipCode;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtStreet;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNumber;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtComplement;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtState;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNeighborhood;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCity;
        private MaterialSkin.Controls.MaterialLabel lblState;
        private MaterialSkin.Controls.MaterialLabel lblCity;
        private MaterialSkin.Controls.MaterialLabel lblNeighborhood;
        private MaterialSkin.Controls.MaterialLabel lblComplement;
        private MaterialSkin.Controls.MaterialLabel lblNumber;
        private MaterialSkin.Controls.MaterialLabel lblStreet;
        private MaterialSkin.Controls.MaterialLabel lblZipCode;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private MaterialSkin.Controls.MaterialLabel lblCpfCnpj;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel lblPhone;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearch;
        private MaterialSkin.Controls.MaterialLabel lblSearch;
        private MaterialSkin.Controls.MaterialRaisedButton btnNew;
        private MaterialSkin.Controls.MaterialRaisedButton btnUpdate;
        private MaterialSkin.Controls.MaterialRaisedButton btnDelete;
        private System.Windows.Forms.ListBox lstClients;
        private MaterialSkin.Controls.MaterialRadioButton rbtnIndividual;
        private MaterialSkin.Controls.MaterialRadioButton rbtnLegalEntity;
        private MaterialSkin.Controls.MaterialRaisedButton btnClient;
        private MaterialSkin.Controls.MaterialRaisedButton btnProduct;
        private MaterialSkin.Controls.MaterialRaisedButton btnOrder;

    }
}