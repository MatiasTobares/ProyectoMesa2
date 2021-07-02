using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.DAL;
using AdminEmpleados.BLL;

namespace AdminEmpleados.PL
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            recolectarDatos();
        }


        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            DepartamentosDAL objDepartamentos = new DepartamentosDAL();
            cbxDepartamento.DataSource = objDepartamentos.mostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "ID";
        }
        private void recolectarDatos()
        {
            EmpleadosBLL objEmpleados = new EmpleadosBLL();
            int codigoEmpleado = 1;
            int.TryParse(txtID.Text, out codigoEmpleado);
            objEmpleados.ID = codigoEmpleado;
            objEmpleados.NombreEmpleado = txtNombre.Text;
            objEmpleados.PrimerApellido = txtPrimerApellido.Text;
            objEmpleados.SegundoApellido = txtSegundoApellido.Text;
            objEmpleados.Correo = txtCorreo.Text;
            int IDDEpartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDEpartamento);
            objEmpleados.Departamento = IDDEpartamento;
          
        }
    }
}
