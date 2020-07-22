using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private int id = -1;

        private void crearPersona()
        {
            using(VolviendoEntities db = new VolviendoEntities())
            {
                try
                {
                    Persona per = new Persona();
                  
                    per.Nombre = tbnombre.Text;
                    per.Apellido = tbapellido.Text;
                    per.DNI = Convert.ToInt32(tbdni.Text);

                    db.Persona.Add(per);
                    db.SaveChanges();

                    MessageBox.Show("Exito");

                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                

            }
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            crearPersona();
            mostrar();
        }

        private void mostrar()
        {
            VolviendoEntities db = new VolviendoEntities();
            dataGridView1.DataSource = db.Persona.ToList();
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(id != -1)
                {
                    using (VolviendoEntities db = new VolviendoEntities())
                    {
                        Persona per = new Persona();
                        per = db.Persona.Find(id);
                        db.Persona.Remove(per);
                        db.SaveChanges();

                        MessageBox.Show("Eliminado correctamente");
                        mostrar();
                    }
                }else
                {
                    MessageBox.Show("No se encontro el elemento");
                    MessageBox.Show(id.ToString());
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
               
            }
        }
    }
}
