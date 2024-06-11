using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agenda
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        


        public Form1()
        {
            InitializeComponent();

            // ======================================= TABELA =============================================================
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = pwd");
                strSQL = "SELECT * FROM CONTATO ORDER BY ID";

                Tabela();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // ===================================================== NOVO =============================================================================
        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                // Estabelece uma conexão com o banco de dados MySql
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");

                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrEmpty(txtEndereco.Text))
                {
                    MessageBox.Show("Campos vazios");
                    return;
                }

                strSQL = "INSERT INTO CONTATO (NOME, ENDERECO, TELEFONE, EMAIL) VALUES (@NOME, @ENDERECO, @TELEFONE, @EMAIL)";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@Nome", txtNome.Text);
                comando.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                comando.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@Email", txtEmail.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso");

                LimparCampos();

            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            finally 
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        // ================================================= LIMPAR ================================================================
        private void LimparCampos()
        {
            txtID.Text = null;
            txtNome.Text = null;
            txtEndereco.Text = null;
            txtTelefone.Text = null;
            txtEmail.Text = null;


        }
        // =========================================================== SALVAR =========================================================

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Estabelece uma conexão com o banco de dados MySql
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");

                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrEmpty(txtEndereco.Text))
                {
                    MessageBox.Show("Campos vazios");
                }

                strSQL = "UPDATE CONTATO SET NOME = @NOME, ENDERECO = @ENDERECO, TELEFONE = @TELEFONE, EMAIL = @EMAIL WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@Nome", txtNome.Text);
                comando.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                comando.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@Email", txtEmail.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Salvo com sucesso");

                LimparCampos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        // ================================================ ATUALIZAR TABELA ====================================================================
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");
                strSQL = "SELECT * FROM CONTATO ORDER BY ID";

                Tabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        // ======================================================== DELETAR ============================================================
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");

                // Checa se o campo esta vazio
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show("ID vazio");
                }

                strSQL = "DELETE FROM CONTATO WHERE ID = @ID";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Registro excluido com sucesso");

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        // ================================================= SAIR ========================================================================
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja fechar a janela ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Close();
            }    
        }

        private void dgvTabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvTabela_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
        // ============================================== SELECIONAR LINHA DA TABELA ==========================================================
        private void dgvTabela_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");
                comando = new MySqlCommand(strSQL, conexao);

                strSQL = "SELECT * FROM CONTATO WHERE ID = @ID OR NOME = @NOME OR ENDERECO = @ENDERECO OR TELEFONE = @TELEFONE OR EMAIL = @EMAIL";
                comando.Parameters.AddWithValue("@ID", txtID.Text = dgvTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                comando.Parameters.AddWithValue("@Nome", txtNome.Text = dgvTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                comando.Parameters.AddWithValue("@Endereco", txtEndereco.Text = dgvTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                comando.Parameters.AddWithValue("@Telefone", txtTelefone.Text = dgvTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                comando.Parameters.AddWithValue("@Email", txtEmail.Text = dgvTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());


                conexao.Open();

                // Executa o comando SQL para obter os resultados da consulta
                dr = comando.ExecuteReader();

                // Lê os dados da consulta e preenche os campos do texto na interface 
                while (dr.Read())
                {
                    txtID.Text = Convert.ToString(dr["id"]);
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    txtEndereco.Text = Convert.ToString(dr["endereco"]);
                    txtTelefone.Text = Convert.ToString(dr["telefone"]);
                    txtEmail.Text = Convert.ToString(dr["email"]);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        // ====================================================================== PESQUISAR =======================================================
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agenda; Uid = root; Pwd = admin123");
                comando = new MySqlCommand(strSQL, conexao);

                strSQL = "SELECT * FROM CONTATO WHERE NOME LIKE '%@NOME%'";
                comando.Parameters.AddWithValue("@Nome", txtNome.Text);

                Tabela();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void Tabela() 
        {
            da = new MySqlDataAdapter(strSQL, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTabela.DataSource = dt;
        }
    }
}
