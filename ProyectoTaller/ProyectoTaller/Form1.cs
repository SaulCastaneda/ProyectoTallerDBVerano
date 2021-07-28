using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoTaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ConexionSQL();

        }
        public static void ConexionSQL()
        {
            try
            {

                SqlConnection connection = new SqlConnection("Data Source= SAUL\\SQLEXPRESS;Initial Catalog=AgroquimicosVersion2; Integrated Security=TRUE;");
                connection.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source= SAUL\\SQLEXPRESS;Initial Catalog=AgroquimicosVersion2; Integrated Security=TRUE;");
            connection.Open();

            SqlCommand Comando = new SqlCommand("exec SP_ClientesBox", connection);
          
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = Comando;
            DataTable tabla = new DataTable();
            Adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            

            

        }

        public void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection connection3 = new SqlConnection("Data Source= SAUL\\SQLEXPRESS;Initial Catalog=AgroquimicosVersion2; Integrated Security=TRUE;");
            connection3.Open();
            try
            {
                String Query = "Delete From Cliente where  ID_Cliente=@ID_Cliente";
                
                SqlCommand Comando = new SqlCommand(Query, connection3);
                Comando.Parameters.AddWithValue("@ID_Cliente", textBox1.Text);
                Comando.ExecuteNonQuery();
                connection3.Close();
                MessageBox.Show("Elimino El Regristro Con Exito :D");

                textBox1.Text = "";
            }
            catch (Exception asd) {
                MessageBox.Show(asd.ToString());
            }

           

           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection("Data Source= SAUL\\SQLEXPRESS;Initial Catalog=AgroquimicosVersion2; Integrated Security=TRUE;");
            connection1.Open();
            String ID_Cliente = textBox1.Text;
            String Nombre = textBox2.Text;
            String Ocupacion = textBox3.Text;
            String Telefono = textBox4.Text;
            String Direccion = textBox5.Text;

            SqlCommand cmd = new SqlCommand();
            try{ 
            cmd.Connection = connection1;
            cmd.CommandText = "insert into Cliente (ID_Cliente,Nombre,Ocupacion,Telefono,Direccion)Values (@ID_Cliente,@Nombre,@Ocupacion,@Telefono,@Direccion)";

            cmd.Parameters.AddWithValue("@ID_Cliente", ID_Cliente);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Ocupacion", Ocupacion);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Direccion", Direccion);   
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insertado Con Exito :D");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
            catch (Exception ex) {

                MessageBox.Show("Error Al Ingresar");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }
    }

          
       
    
}
