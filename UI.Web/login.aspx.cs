using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usuario = new UsuarioLogic();

            if (usuario.ValidarUser(txtUsuario.Text.ToLower(), this.txtClave.Text) == true)
            {
                Page.Response.Write("Ingreso OK");
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrectos");
            }
            
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Deberas crear otra cuenta");
        }
    }
}