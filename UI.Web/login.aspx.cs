using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class login : System.Web.UI.Page
    {
        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {            
            UsuarioLogic user = new UsuarioLogic();
            try
            {

                if (user.ValidarUser(txtUsuario.Text, txtClave.Text))
                {
                    UsuarioActual = user.GetOneByNombreUsuario(txtUsuario.Text);
                    if (UsuarioActual.Habilitado)
                    {
                        Session["UsuarioActual"] = UsuarioActual;
                        Page.Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Usuario no Habilitado";
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Usuario o Contraseña Incorrectos";
                    txtClave.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Page.Response.Write("Error");
            }

        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Deberas crear otra cuenta");
        }
    }
}