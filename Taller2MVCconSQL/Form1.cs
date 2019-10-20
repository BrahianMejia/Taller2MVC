using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Taller2MVCconSQL
{
    public partial class Form1 : Form
    {
           
        CLSEmpleado objEmpleado = null;
        CLSEmpleadoMgr objEmpleadoMgr = null;
        DataTable Dtt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            objEmpleado = new CLSEmpleado();
            objEmpleado.opc = 3;
            objEmpleadoMgr = new CLSEmpleadoMgr(objEmpleado);

            Dtt = new DataTable();
            Dtt = objEmpleadoMgr.Listar();

            if (Dtt.Rows.Count > 0)
            {
                dgvdatos.DataSource = Dtt;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btmeliminar.Enabled = true;
            Listar();
            btncancelar.Enabled = false;
            txtcedula.Focus();
        }

        private void Guardar()
        {
            objEmpleado = new CLSEmpleado();
            objEmpleado.opc = 1;
            objEmpleado.Cedula = Convert.ToInt32(txtcedula.Text);
            objEmpleado.Nombre = txtnombre.Text;
            objEmpleado.Apellido = txtapellido.Text;
            objEmpleado.FNacimiendo = dtpfecha.Value;
            objEmpleado.Cargo = Convert.ToInt32(txtcargo.Text);

            objEmpleadoMgr = new CLSEmpleadoMgr(objEmpleado);
            objEmpleadoMgr.GuardarDatos();
            MessageBox.Show("Contacto guardado exitosamente.", "¡Mensaje de comprobación!");
        }

        public void Eliminar()
        {
            objEmpleado = new CLSEmpleado();
            objEmpleado.opc = 2;
            objEmpleado.Cedula = Convert.ToInt32(txtcedula.Text);
            objEmpleadoMgr = new CLSEmpleadoMgr(objEmpleado);

            objEmpleadoMgr.EliminarDatos();
            MessageBox.Show("Contacto eliminado exitosamente.", "¡Mensaje de comprobación!");
         
        }

        private void bntguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void btmeliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            LimpiarCampos();
            btncancelar.Enabled = false;
            txtnombre.Enabled = true;
            txtcargo.Enabled = true;
            txtapellido.Enabled = true;
            dtpfecha.Enabled = true;
            Listar();
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcedula.Text = dgvdatos.Rows[dgvdatos.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dgvdatos.Rows[dgvdatos.CurrentRow.Index].Cells[1].Value.ToString();
            txtapellido.Text = dgvdatos.Rows[dgvdatos.CurrentRow.Index].Cells[2].Value.ToString();
            txtcargo.Text = dgvdatos.Rows[dgvdatos.CurrentRow.Index].Cells[4].Value.ToString();
            btncancelar.Enabled = true;

            txtnombre.Enabled = false;
            txtcargo.Enabled = false;
            txtapellido.Enabled = false;
            dtpfecha.Enabled = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btncancelar.Enabled = false;
            Listar();
            btncancelar.Enabled = false;
            txtnombre.Enabled = true;
            txtcargo.Enabled = true;
            txtapellido.Enabled = true;
            dtpfecha.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txtapellido.Clear();
            txtcargo.Clear();
            txtcedula.Clear();
            txtnombre.Clear();
            txtcedula.Focus();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            
            DialogResult pregunta = MessageBox.Show("¿Estás seguro?", "Mensaje", MessageBoxButtons.YesNoCancel);

            if (pregunta == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
    }
}
