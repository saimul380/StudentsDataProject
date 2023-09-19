using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentsDataProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //submit
        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=LAPTOP-Q7KTNQDN\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";
                SqlConnection sqlConnecton = new SqlConnection(connectionString);
                sqlConnecton.Open();

                var insertQuery = "insert into student2 values(@matrixID, @name, @session ,@cgpa) ";
                SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnecton);
                sqlCommand.Parameters.AddWithValue("@matrixID", MatrixidBox.Text);
                sqlCommand.Parameters.AddWithValue("@name", NameBox.Text);
                sqlCommand.Parameters.AddWithValue("@session", sessionBox.Text);
                sqlCommand.Parameters.AddWithValue("@cgpa", double.Parse(cgpaBox.Text));

                sqlCommand.ExecuteNonQuery();
                sqlConnecton.Close();

                MessageBox.Show("Data Inserted Successfully!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data Inserted Wrong!");

            }
        }
        //update
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=LAPTOP-Q7KTNQDN\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";
                SqlConnection sqlConnecton = new SqlConnection(connectionString);
                sqlConnecton.Open();

                string updateCommand = "update student2 set name=@name, session=@session, cgpa=@cgpa where matrixID=@matrixID";
                SqlCommand sqlCommand = new SqlCommand(updateCommand, sqlConnecton);
                sqlCommand.Parameters.AddWithValue("@matrixID", MatrixidBox.Text);
                sqlCommand.Parameters.AddWithValue("@name", NameBox.Text);
                sqlCommand.Parameters.AddWithValue("@session", sessionBox.Text);
                sqlCommand.Parameters.AddWithValue("@cgpa", double.Parse(cgpaBox.Text));
                
                sqlCommand.ExecuteNonQuery();
                sqlConnecton.Close();

                MessageBox.Show("Data Updated Successfully!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Error in Data Update.");
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=LAPTOP-Q7KTNQDN\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";
                SqlConnection sqlConnecton = new SqlConnection(connectionString);
                sqlConnecton.Open();
                if (MatrixidBox.Text.ToString() == "")
                {
                    string readCommand = "read * from student2 ";
                    SqlCommand sqlCommand = new SqlCommand(readCommand, sqlConnecton);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    string readCommand = "read * from student2 where matrixID= @matrixID ";
                    SqlCommand sqlCommand = new SqlCommand(readCommand, sqlConnecton);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Error in Data Search");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = "Data Source=LAPTOP-Q7KTNQDN\\SQLEXPRESS;Initial Catalog=UniversityDatabase;Integrated Security=True";
                SqlConnection sqlConnecton = new SqlConnection(connectionString);
                sqlConnecton.Open();

                string deleteCommand = "delete student2 where matrixID= @matrixID";
                SqlCommand sqlCommand = new SqlCommand(deleteCommand, sqlConnecton);
                sqlCommand.Parameters.AddWithValue("@matrixID", MatrixidBox.Text);
               

                sqlCommand.ExecuteNonQuery();
                sqlConnecton.Close();

                MessageBox.Show("Data Deleted Successfully!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Error in Data Delete");
            }
        }
    }
}
