using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class ModuloUsuarioAdapter :Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulousuario = new List<ModuloUsuario>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuarios = new SqlCommand("select * from modulos_usuarios", sqlConn);

                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                while (drModuloUsuarios.Read())
                {
                    ModuloUsuario mod = new ModuloUsuario();

                    mod.ID = (int)drModuloUsuarios["id_modulo_usuario"];
                    mod.IDModulo = (int)drModuloUsuarios["id_modulo"];
                    mod.IDUsuario = (int)drModuloUsuarios["id_usuario"];
                    mod.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    mod.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    mod.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    mod.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];

                    modulousuario.Add(mod);
                }

                drModuloUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Modulos_USuarios", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return modulousuario;
        }


        //public int GetOneByDesc(string descripcion)

        //{
        //    int Id;
        //    try
        //    {
        //        this.OpenConnection();

        //        SqlCommand cmdMateria = new SqlCommand("select id_materia from MATERIAS where desc_materia = @descripcion ", sqlConn);
        //        cmdMateria.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

        //        Id = Convert.ToInt32(cmdMateria.ExecuteScalar());




        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada =
        //            new Exception("Erro al recuperar lista de Materias", Ex);

        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return Id;

        //}


        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario mod = new ModuloUsuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuarios = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", sqlConn);
                cmdModuloUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                if (drModuloUsuarios.Read())
                {
                    mod.ID = (int)drModuloUsuarios["id_modulo_usuario"];
                    mod.IDModulo = (int)drModuloUsuarios["id_modulo"];
                    mod.IDUsuario = (int)drModuloUsuarios["id_usuario"];
                    mod.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    mod.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    mod.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    mod.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];
                }
                drModuloUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Modulos_Usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mod;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete modulos_usuarios where id_modulo_usuarios = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar modulo_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(ModuloUsuario modulousuario)
        {
            try
            {
                this.OpenConnection();
                //CAPAS QUE HAY ERROR ACA NO ESTA REVISADO
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE modulos_usuarios SET id_modulo = @id_modulo, id_usuario = @id_usuario, alta = @alta, baja = @baja, modificacion  = @modificacion, consulta = @consulta" +
                    "WHERE id_modulo_usuario = @id" + sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulousuario.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modulousuario.IDModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modulousuario.IDUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modulousuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modulousuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modulousuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modulousuario.PermiteConsulta;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de Modulo_Usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modulousuario)
        {
            try
            {
                this.OpenConnection();
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta)" +
                    "values (@id_modulo,@id_usuario,@alta,@baja,@modificacion,@consulta)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modulousuario.IDModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modulousuario.IDUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modulousuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modulousuario.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modulousuario.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modulousuario.PermiteConsulta;
                modulousuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear modulo_usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modulousuario)
        {
            if (modulousuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulousuario.ID);
            }
            else if (modulousuario.State == BusinessEntity.States.New)
            {
                this.Insert(modulousuario);
            }
            else if (modulousuario.State == BusinessEntity.States.Modified)
            {
                this.Update(modulousuario);
            }
            modulousuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
