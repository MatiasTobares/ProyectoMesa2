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
    public partial class frmDepartamentos : Form
    {
        DepartamentosDAL oDepartamentosDAL;
        public frmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            llenarGrid();
            limpiarEntradas();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            // Clase DAL Departamentos.. objeto que tiene la informacion de la GUI
            oDepartamentosDAL.Agregar(recuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }
        //metodo privado devuelve un objeto
        private DepartamentoBLL recuperarInformacion()
        {
            DepartamentoBLL oDepartamentoBLL = new DepartamentoBLL(); //instancio el objeto departamento
            int ID = 0; int.TryParse(txtID.Text, out ID);//parseo(busco) mi elemento txtID.Text agarro la informacion y en caso que no la encuentre le pone el valor ID
          
            oDepartamentoBLL.ID = ID; // lo deposito en el objeto
            oDepartamentoBLL.Departamento = txtNombre.Text;
            return oDepartamentoBLL;
                }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            txtID.Text = dgvDepartamentos.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvDepartamentos.Rows[indice].Cells[1].Value.ToString();
            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(recuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(recuperarInformacion());
            llenarGrid();
            limpiarEntradas();
        }
        public void llenarGrid()
        {
            dgvDepartamentos.DataSource = oDepartamentosDAL.mostrarDepartamentos().Tables[0];

        }
        public void limpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
                
               

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
